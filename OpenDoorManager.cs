using Godot;
using System;

public partial class OpenDoorManager : Node2D
{
	private bool isKeyFound;
	public void GotTheKey()
	{
		GD.Print("key found");
		isKeyFound = true;
	} 
	public bool DoesGotKey()
	{
		return isKeyFound;
	}
}
