using Godot;
using System;

public partial class Paddle : CharacterBody2D
{
	
	[Export]
	public float Speed { get; set; }= 300.0f;	//speed paddles will move

	//Export Move actions so we can edit them in the Editor rather than using magic strings in code. 
	[Export] 
	public string MoveUpAction { get; set; } = "move_up";
	
	[Export] 
	public string MoveDownAction { get; set; } = "move_down";
	
	public override void _PhysicsProcess(double delta)
	{
		//debug movement
		//GD.Print("PhysicsProcess running - direction = ", Input.GetAxis(MoveUpAction, MoveDownAction));
		
		//create new vector2 with the paddles' current Velocity
		Vector2 velocity = Velocity;

		//Calculate direction
		float direction = Input.GetAxis(MoveUpAction, MoveDownAction);
		
		//set velocity.Y
		velocity.Y = direction * Speed;
		velocity.X = 0.0f;
		
		//Store value in Paddles' Velocity variable.
		//Velocity = velocity;
		
		MoveAndCollide(velocity * (float)delta);
		
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
}
