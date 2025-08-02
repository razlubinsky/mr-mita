using Godot;
using System;

public partial class ClosetArea : InterctableAria // Area2D
{
	 public override void _Ready()
	{
		//this.BodyEntered += OnBodyEntered;
		//this.BodyExited += OnBodyExited;
		base._Ready();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public override  void interactWith(){
		GD.Print("Closed Destroyed!");
		GetParent().QueueFree();
	}
	

}
