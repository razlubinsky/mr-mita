using Godot;
using System;
using System.Collections.Generic;


public partial class Player : CharacterBody2D
{
	private float speed = 200f;
	private float gravity = 800f;
	private float jumpForce = -400f;
	private Vector2 velocity = Vector2.Zero;
	private AudioStreamPlayer2D jumpfx;

	private Vector2 center;
	private Interactives interactives;
	
	
	//private static InterctableAria currInteractive = null;
	private static List<InterctableAria> currInteractive;


	private AnimatedSprite2D _animatedSprite;

	
	public override void _Ready()
	{
		center = GetViewportRect().Size / 2;
		GlobalPosition = center;

		interactives = GetNode<Interactives>("../../Interactives");
		interactives.SignMeUp(this);
		_animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		currInteractive = new List<InterctableAria>();
		jumpfx = GetNode<AudioStreamPlayer2D>("jumpSEF");



	}

	public override void _PhysicsProcess(double delta)
	{
		float dt = (float)delta;
		bool idel = true;
		velocity.X = 0;

		if (Input.IsActionPressed("move_left")){
			 _animatedSprite.FlipH = false;

			_animatedSprite.Play("run");
			idel = false;
			velocity.X = -speed;

		}
		else if (Input.IsActionPressed("move_right")){
					_animatedSprite.FlipH = true;

			_animatedSprite.Play("run");
			idel = false;
			velocity.X = speed;

		}


		if (IsOnFloor())
		{
			if (Input.IsActionJustPressed("jump"))
			{
				_animatedSprite.Play("jump");
				jumpfx.Play();
				idel = false;
				velocity.Y = jumpForce;
			}
			else if (Input.IsActionPressed("move_up"))
			{
				
				velocity.Y = -speed;
			}
			else if (Input.IsActionPressed("move_down"))
			{
				velocity.Y = speed;
			}
			
			else
			{
			if(idel)
				_animatedSprite.Play("idel");
				velocity.Y = 0;
			}			
		}
		else
		{
			velocity.Y += gravity * dt;
		}
		if (Input.IsActionJustPressed("interact"))
			{
				if (currInteractive != null && currInteractive.Count != 0)
				{
					//currInteractive.interactWith();
					
				
				InterctableAria inreract = currInteractive[0];
				inreract.interactWith();

				if (currInteractive.Remove(inreract))
					currInteractive.Add(inreract);	
				}
			}

	Velocity = velocity;
	MoveAndSlide(); // Godot 4 handles the internal velocity
	velocity = Velocity;

	if (Input.IsActionJustPressed("escape"))
		interactives.ResetInteractives();

	}

	public void Genesis()
	{
		GlobalPosition = center;
	}
	
	public  void setInteract(InterctableAria o){
			//currInteractive = o;
		currInteractive.Add(o);
	}
		public  void DeclareNotCollide(InterctableAria o){
		//if(currInteractive == o)
				//currInteractive = null;
				currInteractive.Remove(o);
	}
	
	
}
