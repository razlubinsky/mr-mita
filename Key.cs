using Godot;
using System;

public partial class Key : InterctableAria
{
	private AnimatedSprite2D _animatedSprite;
	private OpenDoorManager openDoorManager;
	private AudioStreamPlayer2D collectfx;

	public override void _Ready()
	{
		base._Ready();
		_animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		_animatedSprite.Play("Spin");
		collectfx = GetNode<AudioStreamPlayer2D>("keyFX");
	}
	public override void interactWith()
	{
		var openDoorManager = GetParent().GetParent() as OpenDoorManager;
		openDoorManager.GotTheKey();
		collectfx.Play();
		DestroyKey();
		
	}
	private void DestroyKey()
	{
		GetParent().QueueFree();
	}
}
