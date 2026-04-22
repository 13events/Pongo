using Godot;
using System;


public partial class Main : Node
{
	//hold references for various nodes
	private Ball _ball;
	private Hud _hud;
	
	//variables track score
	private int _leftScore = 0;
	private int _rightScore = 0;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_hud = GetNode<Hud>("HUD");
		 _ball =  GetNode<Ball>("Ball"); //get ref to ball
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
		if (body is Ball) //checks and creats a variable in one line
		{
			GD.Print("Ball has exited the left goal");
			
			//Increment right paddle player score.
			IncrementRightScore();
			
			//use HUD to update score
			UpdateScore();
			
			_ball.Reset(); //reset ball
		}
	}
	
	//check if ball exited right of screen, increment score for left paddle, reset ball.
	public void OnRightGoalBodyExited(Node2D body)
	{
		if (body is Ball) //checks and creats a variable in one line
		{
			GD.Print("Ball has exited the right goal");
			
			//Increment left paddle player score.
			IncrementLeftScore();
			
			//use HUD to update score
			UpdateScore();
			
			_ball.Reset();	//reset ball 
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
	}

}
