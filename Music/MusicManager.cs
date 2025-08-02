using Godot;
using System;

public partial class MusicManager : Node2D
{
	private static MusicManager _instance;

	public override void _Ready()
	{
		if (_instance != null && _instance != this)
		{
			QueueFree(); // Avoid duplicates
		}
		else
		{
			_instance = this;
			GetNode<AudioStreamPlayer2D>("AudioStreamPlayer2D").Play();
			GetTree().Root.AddChild(this); // Move to root to persist
			this.Owner = null;
		}
	}
}
