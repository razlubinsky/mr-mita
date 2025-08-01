using Godot;
using System;

public partial class test : Sprite2D
{
	private float angle = 0f;
	private float radius = 100f;
	private Vector2 center;

	public override void _Ready()
	{
		// Center the sprite on the screen
		center = GetViewportRect().Size / 2;
		GlobalPosition = center;
	}

	public override void _Process(double delta)
	{
		angle += (float)delta;

		float x = Mathf.Cos(angle) * radius;
		float y = Mathf.Sin(angle) * radius;

		GlobalPosition = center + new Vector2(x, y);
	}
}
