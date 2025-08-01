using Godot;
using System;

public partial class Closet : Node2D
{
	private Sprite2D sprite;
	private Vector2 originalPosition;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		originalPosition = GlobalPosition;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public void Genesis()
	{
		GlobalPosition = originalPosition;
	}

}
