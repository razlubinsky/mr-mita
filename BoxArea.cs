using Godot;
using System;
using System.Threading.Tasks;


public partial class BoxArea : InterctableAria
{
	[Export] public bool isCorrectdwaawdsawddw;
	private AnimatedSprite2D _animatedSprite;

	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();
		_animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		//_animatedSprite.Play("Idle");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public override  void interactWith()
	{
	
		DerstroyBox();
		
	}
	
	private async void DerstroyBox(){
		_animatedSprite.Play("interact");

		 await ToSignal(GetTree().CreateTimer(0.75), "timeout"); // non-blocking wait

		GetParent().QueueFree();
	}

}
