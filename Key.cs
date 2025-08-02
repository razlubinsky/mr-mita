using Godot;
using System;

public partial class Key : InterctableAria
{
	private AnimatedSprite2D _animatedSprite;
	private OpenDoorManager openDoorManager;
	public override void _Ready()
	{
		_animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		_animatedSprite.Play("Spin");
	}
	public override void interactWith()
	{
		DestroyKey();
	}
	private void DestroyKey()
	{
		GetParent().QueueFree();
	}
}
