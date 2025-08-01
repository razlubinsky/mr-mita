using Godot;
using System;

public partial class ClosetArea : Area2D
{
	 public override void _Ready()
	{
		this.BodyEntered += OnBodyEntered;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	private void OnBodyEntered(Node2D body)
	{
		GD.Print("1");
		//var parentSprite = GetParent() as Sprite2D;
		//if (parentSprite != null)
		//{
		//	parentSprite.Modulate = new Color(1, 0, 0);  // tint red
		//	GD.Print("2");
		//}
	}
}
