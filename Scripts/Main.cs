using Godot;
using System;
using System.Reflection.Metadata.Ecma335;


public partial class Main : Node
{
	[Export]
	private int _winCondition = 5;	//adjustable in godot editor.
	
	//hold references for various nodes
	private Ball _ball;
	private Hud _hud;
	private Paddle _leftPaddle;
	private Paddle _rightPaddle;
	
	//variables track score
	private int _leftScore = 0;
	private int _rightScore = 0;
	
	//gamestate
	private bool _gameOver = false;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		ProcessMode = ProcessModeEnum.Always;
		
		_hud = GetNode<Hud>("HUD");
		_ball =  GetNode<Ball>("Ball"); //get ref to ball
		_leftPaddle = GetNode<Paddle>("LeftPaddle");
		_rightPaddle = GetNode<Paddle>("RightPaddle");
		
		_hud.UpdateScore(_leftScore, _rightScore);
		_ball.Reset();
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	//check if ball exited left of screen, increment score for right paddle, reset ball.
	public void OnLeftGoalBodyExited(Node2D body)
	{
		
		if (_gameOver) return;
		
		if (body is Ball) //checks and creates a variable in one line
		{
			GD.Print("Ball has exited the left goal");
			
			HandleGoalScored(false);
		}
	}
	
	//check if ball exited right of screen, increment score for left paddle, reset ball.
	public void OnRightGoalBodyExited(Node2D body)
	{
		if (_gameOver) return;
		
		if (body is Ball) //checks and creates a variable in one line
		{
			GD.Print("Ball has exited the right goal");
			
			HandleGoalScored(true);
		}
	}

	public void IncrementLeftScore()
	{
		_leftScore++;
		GD.Print($"Left Player Scored! {_leftScore} - {_rightScore}");
	}

	public void IncrementRightScore()
	{
		_rightScore++;
		GD.Print($"Right Player Scored! {_leftScore} - {_rightScore}");
	}

	public void UpdateScore()
	{
		_hud.UpdateScore(_leftScore, _rightScore);
		CheckWinCondition();
	}

	public void CheckWinCondition()
	{
		if (_leftScore == _winCondition)
		{
			_gameOver = true;
			_hud.ShowWinMessage("Left Player Wins!");
			GetTree().Paused = true;
			HideGameElements();
			_hud.ShowPlayAgainMessage();
		}
		else if (_rightScore == _winCondition)
		{
			_gameOver = true;
			_hud.ShowWinMessage("Right Player Wins!");
			GetTree().Paused = true;
			HideGameElements();
			_hud.ShowPlayAgainMessage();
		}
	}
	
	public void HideGameElements()
	{
		_ball.Visible = false;
		_leftPaddle.Visible = false;
		_rightPaddle.Visible = false;
	}

	public void RestartGame()
	{
		//reset ball
		_ball.Reset();
		//reset score
		_leftScore = 0;
		_rightScore = 0;
		
		//update Score UI
		_hud.UpdateScore(_leftScore, _rightScore);
		
		//reset gameOver to false
		_gameOver = false;
		//reset paddle positions
		_leftPaddle.Reset(new Vector2 (96,232));
		_rightPaddle.Reset(new Vector2 (656, 232));
		//hide win message
		_hud.HideWinMessage();
		
		//hide play again message
		_hud.HidePlayAgainMessage();
		//show game elements
		_leftPaddle.ShowPaddle();
		_rightPaddle.ShowPaddle();
		_ball.Visible = true;
		
		//unpause game
		GetTree().Paused = false;

	}

	public override void _Input(InputEvent @event)
	{
		if (_gameOver)
		{
			if (@event is InputEventKey eventKey && eventKey.Pressed)
			{
				RestartGame();
			}
		}	
		
	}

	private void HandleGoalScored(bool isLeftScore)
	{
		if (isLeftScore)
		{
			IncrementLeftScore();
			
		}
		else
		{
			IncrementRightScore();
			
		}
		
		UpdateScore();

		if (!_gameOver)
		{
			_ball.Reset();
		}
	}
}