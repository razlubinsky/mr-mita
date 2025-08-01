using Godot;
using System;

public partial class CharacterBody2d : CharacterBody2D
{
	public const float Speed = 300.0f;
	public const float JumpVelocity = -400.0f;
	private Vector2 center;
		public override void _Ready()
	{
		//center = GetViewportRect().Size / 2;
		//GlobalPosition = center;
 
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}

		// Handle Jump.
		if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
		}

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();

		
			  int collisionCount = GetSlideCollisionCount();
		
		for (int i = 0; i < collisionCount; i++)
		{
			KinematicCollision2D col = GetSlideCollision(i);
			Node collider = col.GetCollider() as Node;
			//GD.Print($"Collided with: {collider?.Name}");
			// You can inspect normal, position, etc.: col.GetNormal()
		}
	}
	
	

	
		
}
