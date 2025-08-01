using Godot;
using System;

public  abstract partial class InterctableAria : Area2D
{
	public abstract void   interactWith();
		 public override void _Ready()
	{
		this.BodyEntered += OnBodyEntered;
		this.BodyExited += OnBodyExited;
	}

	public override void _Process(double delta)
	{
	}
	private void OnBodyEntered(Node2D body)
	{
		
	if (body is test testInstance)
	{
		//GD.Print("Collide with player");
		testInstance.setInteract( this);
	}
	else
	{
		GD.PrintErr("Passed node is not a Tesr, cannot call CustomAction.");
	}
	}
		private void OnBodyExited(Node2D body)
	{
	if (body is test testInstance)
	{
		//GD.Print("Stop ollide with player");

		testInstance.DeclareNotCollide(this);
	}
	}
	
	
	
}
