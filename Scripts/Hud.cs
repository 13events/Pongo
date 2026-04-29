using Godot;
using System;

public partial class Hud : CanvasLayer
{
	
	private Label _leftScoreLabel;
	private Label _rightScoreLabel;
	private Label _winMessageLabel;
	private Label _playAgainLabel;
	private Button _returnToMenuButton;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_leftScoreLabel = GetNode<Label>("LeftScore");
		_rightScoreLabel = GetNode<Label>("RightScore");
		_winMessageLabel = GetNode<Label>("WinMessage");	//starts hidden
		_playAgainLabel = GetNode <Label>("PlayAgainMessage");
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
		_playAgainLabel.Visible = true;
		_returnToMenuButton.Visible = true;
	}
	
	public void HidePlayAgainMessage()
	{
		_playAgainLabel.Visible = false;
	}

	private void OnReturnToMenuButtonPressed()
	{
		GetTree().ChangeSceneToFile("res://Scenes/MainMenu.tscn");
	}
}
