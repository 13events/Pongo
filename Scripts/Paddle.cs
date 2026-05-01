using Godot;
using System;

public partial class Paddle : CharacterBody2D
{
	
	[Export]
	public float Speed { get; set; }= 300.0f;	//speed paddles will move
	
	[Export]
	public bool isAI {get; set;} = false;

	private Ball _ball;

	//Export Move actions so we can edit them in the Editor rather than using magic strings in code. 
	[Export] 
	public string MoveUpAction { get; set; } = "move_up";
	
	[Export] 
	public string MoveDownAction { get; set; } = "move_down";

	public override void _Ready()
	{
		_ball = GetNode<Ball>("../Ball"); //cache referece to ball.
	}
	
	public override void _PhysicsProcess(double delta)
	{
		
		if (isAI)
		{
			HandleAIMovement(delta);
		}
		else
		{
			//create new vector2 with the paddles' current Velocity
			Vector2 velocity = Velocity;

			//Calculate direction
			float direction = Input.GetAxis(MoveUpAction, MoveDownAction);

			//set velocity.Y
			velocity.Y = direction * Speed;
			velocity.X = 0.0f;
			
			MoveAndCollide(velocity * (float)delta);
		}
	}

	public void Reset(Vector2 position)
	{
		this.Position = position;
	}

	public void HidePaddle()
	{
		this.Visible = false;
	}

	public void ShowPaddle()
	{
		this.Visible = true;
	}


	public void HandleAIMovement(double delta)
	{
		var ballY = _ball.Position.Y;
		var paddleY = Position.Y;
		var distanceToBall = ballY - paddleY;
		var paddleVelocity = Velocity;
		
		float direction;
		
		// compare and see if we are within 15pxl
		if (Mathf.Abs(distanceToBall) <= 15f)
		{
			direction = 0f; 	//if ball is within 15px of paddle, stop movement
		} 
		else if (ballY > Position.Y)
		{
			direction = 1f;	//If we are farther than 15px and ball is below paddle, move down
		}
		else
		{
			direction = -1f;	//If we are farther than 15px and ball is above paddle, move up
		}
		
		paddleVelocity.Y = direction * Speed * 0.7f;
		MoveAndCollide(paddleVelocity * (float)delta);
	}
}
