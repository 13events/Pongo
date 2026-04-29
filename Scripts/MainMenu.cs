using Godot;
using System;

public partial class MainMenu : CanvasLayer
{
	private Button _startButton;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_startButton = GetNode<Button>("StartButton");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void OnStartButtonPressed()
	{
		GetTree().ChangeSceneToFile("res://Scenes/Main.tscn");
	}
}
