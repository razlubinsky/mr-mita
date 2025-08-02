using Godot;
using System;

public partial class Timer : Node2D
{
	[Export] public Label TimerLabel; // Optional: Assign in editor
	[Export] public int StartMinutes = 0;
	[Export] public int StartSeconds = 10;

	private float timeLeft;
	private bool isRunning = false;
	private Interactives interactives;

	public override void _Ready()
	{
		ResetTimer(); // Start immediately or call it manually
		interactives = GetNode<Interactives>("../Interactives");
	}

	public override void _Process(double delta)
	{
		if (!isRunning) return;

		timeLeft -= (float)delta;

		if (timeLeft <= 0)
		{
			timeLeft = 0;
			isRunning = false;
			OnTimerFinished();
		}

		UpdateLabel();
	}

	private void UpdateLabel()
	{
		int totalSeconds = Mathf.CeilToInt(timeLeft);
		int minutes = totalSeconds / 60;
		int seconds = totalSeconds % 60;
		int hours = minutes / 60;
		minutes = minutes % 60;

		string timeFormatted = $"{hours:D2}:{minutes:D2}:{seconds:D2}";

		if (TimerLabel != null)
			TimerLabel.Text = timeFormatted;
		else
			GD.Print(timeFormatted); // fallback to console
	}

	private void OnTimerFinished()
	{
		ResetTimer();
		interactives.ResetInteractives();
		GD.Print("Timer Finished!");
		// Call any custom logic here
	}

	public void ResetTimer()
	{
		timeLeft = StartMinutes * 60 + StartSeconds;
		isRunning = true;
		UpdateLabel();
	}
}
