using Godot;
using System;


public partial class DoorArea : InterctableAria
{
	private bool isOpen = false;
	private Vector2 velocity = Vector2.Zero;
	private float jumpForce = -400f;
	private AnimatedSprite2D _animatedSprite;

	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();
		_animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		_animatedSprite.Play("Idle");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public override  void interactWith()
	{
		if(isOpen) 
		{
			_animatedSprite.Stop();
			_animatedSprite.Play("Close");
			isOpen = false;
		}
		else
		{
			GD.Print("door is oppning");
			_animatedSprite.Stop();
			_animatedSprite.Play("Open");
			isOpen = true;
		}			
	}
}
