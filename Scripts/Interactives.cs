using Godot;
using System;
using System.Collections.Generic; // Important!

public partial class Interactives : Node
{
	private List<Node> interactivesList = new List<Node>();

	public override void _Ready()
	{

	}

	public void SignMeUp(Node interactiveObject)
	{
		interactivesList.Add(interactiveObject);
		foreach (Node interactive in interactivesList)
		{
			GD.Print(interactive.Name); // Or just GD.Print(interactive);
		}
	}
	public void ResetInteractives()
	{
		foreach (test interactive in interactivesList)
		{
			interactive.Genesis();
		}
	}

}
