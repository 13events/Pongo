using Godot;
using System;

public partial class Main : Node
{
	//get ball reference
	private Ball _ball;
	
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		 _ball =  GetNode<Ball>("Ball");
		 _ball.Reset();
		 
		 
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}
}
