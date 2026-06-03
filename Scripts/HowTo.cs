using Godot;
using System;

public partial class HowTo : CanvasLayer
{
	private Button _menuButton;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_menuButton = GetNode<Button>("BackToMenuButton");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		_menuButton.Pressed += OnBackToMenuButtonPressed;
	}

	private void OnBackToMenuButtonPressed()
	{
		GetTree().ChangeSceneToFile("res://Scenes/MainMenu.tscn");
	}
}
