using Godot;
using System;

public partial class Hud : CanvasLayer
{
	
	private Label _leftScoreLabel;
	private Label _rightScoreLabel;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_leftScoreLabel = GetNode<Label>("LeftScore");
		_rightScoreLabel = GetNode<Label>("RightScore");
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
}
