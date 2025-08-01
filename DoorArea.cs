using Godot;
using System;


public partial class DoorArea : InterctableAria
{
	private Vector2 velocity = Vector2.Zero;
	private float jumpForce = -400f;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

		public override  void interactWith(){
			
		//velocity.Y = jumpForce;
		//Velocity = velocity;
		//MoveAndSlide(); // Godot 4 handles the internal velocity
		//velocity = Velocity;
		GD.Print("Dorr Destroyed!");
		GetParent().QueueFree();
		
	}
}
