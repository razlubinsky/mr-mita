using Godot;
using System;

public partial class test : Sprite2D
{
	private float speed = 200f;

	private float gravity = 800f;
	private float jumpForce = -400f; // negative because y+ is down in Godot
	private float verticalVelocity = 0f;

	private bool isOnGround = true;

	private Vector2 center;

	public override void _Ready()
	{
		center = GetViewportRect().Size / 2;
		GlobalPosition = center;
	}

	public override void _Process(double delta)
	{
		float dt = (float)delta;

		// Horizontal movement
		if (Input.IsActionPressed("move_left"))
			GlobalPosition += new Vector2(-1, 0) * speed * dt;

		if (Input.IsActionPressed("move_right"))
			GlobalPosition += new Vector2(1, 0) * speed * dt;

		// Vertical movement (up/down)
		if (Input.IsActionPressed("move_up") && isOnGround)
			GlobalPosition += new Vector2(0, -1) * speed * dt;

		if (Input.IsActionPressed("move_down") && isOnGround)
			GlobalPosition += new Vector2(0, 1) * speed * dt;

		// Jump input (space key), only if on the ground
		if (isOnGround && Input.IsActionJustPressed("jump"))
		{
			verticalVelocity = jumpForce;
			isOnGround = false;
		}

		// Gravity and vertical jump/fall
		if (!isOnGround)
		{
			verticalVelocity += gravity * dt;
			GlobalPosition += new Vector2(0, verticalVelocity * dt);

			// Check if sprite landed (back to ground level)
			if (GlobalPosition.Y >= center.Y)
			{
				GlobalPosition = new Vector2(GlobalPosition.X, center.Y);
				verticalVelocity = 0f;
				isOnGround = true;
			}
		}
	}
}
