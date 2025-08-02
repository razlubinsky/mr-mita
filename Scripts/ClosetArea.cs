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
//
	//// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	//private void OnBodyEntered(Node2D body)
	//{
		//
	//if (body is test testInstance)
	//{
		//GD.Print("Collide with player");
		//testInstance.setInteract( GetParent());
	//}
	//else
	//{
		//GD.PrintErr("Passed node is not a Tesr, cannot call CustomAction.");
	//}
	//}
		//private void OnBodyExited(Node2D body)
	//{
		//// Code to execute when a body exits collision with this RigidBody2D
	//if (body is test testInstance)
	//{
		//GD.Print("Stop ollide with player");
//
		//testInstance.DeclareNotCollide( GetParent());
	//}
	//}
	
	public override  void interactWith(){
		GD.Print("Closed Destroyed!");
		GetParent().QueueFree();
	}
	

}
