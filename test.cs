using Godot;
using System;

public partial class test : CharacterBody2D
{
	private float speed = 200f;
	private float gravity = 800f;
	private float jumpForce = -400f;
	private Vector2 velocity = Vector2.Zero;

	private Vector2 center;
	private Interactives interactives;
	
	private static Node currInteractive = null;
	
	public override void _Ready()
	{
		center = GetViewportRect().Size / 2;
		GlobalPosition = center;

		interactives = GetNode<Interactives>("../Interactives");
		interactives.SignMeUp(this);
	}

	public override void _PhysicsProcess(double delta)
	{
		float dt = (float)delta;

		velocity.X = 0;

		if (Input.IsActionPressed("move_left"))
			velocity.X = -speed;
		else if (Input.IsActionPressed("move_right"))
			velocity.X = speed;

		if (IsOnFloor())
		{
			if (Input.IsActionJustPressed("jump"))
			{
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
				velocity.Y = 0;
			}
			if (Input.IsActionJustPressed("interact"))
			{
		
				currInteractive.QueueFree();
			}
			
			
		}
		else
		{
			velocity.Y += gravity * dt;
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
	
	public  void setInteract(Node o){
		currInteractive = o;
	}
		public  void DeclareNotCollide(Node o){
			if(currInteractive == o)
				currInteractive = null;
	}
	
	
}
