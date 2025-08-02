using Godot;
using System;

public partial class MusicManager : Node2D
{
	public override void _Ready()
	{
		GetNode<AudioStreamPlayer2D>("AudioStreamPlayer2D").Play();
	}
}
