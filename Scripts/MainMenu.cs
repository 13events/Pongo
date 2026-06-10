using Godot;
using System;
using Pongo.Scripts;

public partial class MainMenu : CanvasLayer
{
	private Button _startButton;
	private Button _1PlayerButton;
	private Button _2PlayerButton;
	private Button _howToButton;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_startButton = GetNode<Button>("StartButton");
		_1PlayerButton = GetNode<Button>("1PlayerButton");
		_2PlayerButton = GetNode<Button>("2PlayerButton");
		_howToButton = GetNode<Button>("HowToButton");
	}
	

	public void OnStartButtonPressed()
	{
		GetTree().ChangeSceneToFile("res://Scenes/main.tscn");

	}

	public void On1PlayerButtonPressed()
	{
		if (GameSettings.isMultiPlayer())
		{
			GameSettings.SetMultiPlayer();
			_2PlayerButton.ButtonPressed = false;
		}

		GD.Print("isMultiPlayer?" + GameSettings.isMultiPlayer());
	}

	public void On2PlayerButtonPressed()
	{
		if (!GameSettings.isMultiPlayer())
		{
			GameSettings.SetMultiPlayer();
			_1PlayerButton.ButtonPressed = false;
		}

		GD.Print("isMultiPlayer?" + GameSettings.isMultiPlayer());
	}

	public void OnHowToButtonPressed()
	{
		GetTree().ChangeSceneToFile("res://Scenes/HowTo.tscn");
	}
}
	