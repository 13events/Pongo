using Godot;
using System;

public partial class Hud : CanvasLayer
{
	[Signal]
	public delegate void PlayAgainEventHandler();
	
	private Label _leftScoreLabel;
	private Label _rightScoreLabel;
	private Label _winMessageLabel;
	private Button _playAgainButton;
	private Button _returnToMenuButton;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_leftScoreLabel = GetNode<Label>("LeftScore");
		_rightScoreLabel = GetNode<Label>("RightScore");
		_winMessageLabel = GetNode<Label>("WinMessage");	//starts hidden
		_playAgainButton = GetNode<Button>("PlayAgainButton");
		_returnToMenuButton = GetNode<Button>("ReturnToMenuButton");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void UpdateScore(int leftScore, int rightScore)
	{
		_leftScoreLabel.Text = leftScore.ToString();
		_rightScoreLabel.Text = rightScore.ToString();
	}

	public void ShowWinMessage(string message)
	{
		_winMessageLabel.Text = message;
		_winMessageLabel.Visible = true;
		
		
	}

	public void HideWinMessage()
	{
		_winMessageLabel.Visible = false;
	}

	public void ShowPlayAgainMessage()
	{
		_playAgainButton.Visible = true;
		_returnToMenuButton.Visible = true;
	}
	
	public void HidePlayAgainMessage()
	{
		_playAgainButton.Visible = false;
	}

	private void OnReturnToMenuButtonPressed()
	{
		GetTree().Paused = false;
		GetTree().ChangeSceneToFile("res://Scenes/MainMenu.tscn");
	}

	private void OnPlayAgainButtonPressed()
	{
		_returnToMenuButton.Hide();
		EmitSignalPlayAgain();
	}
}
