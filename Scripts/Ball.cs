using Godot;
using System;

public partial class Ball : CharacterBody2D
{
    [Export]
    public float Speed { get; set; } = 300.0f;
    public void Reset()
    {
        //move ball to center of screen
        Position = new Vector2(400, 300);
        
        //xSign for x direction 
        float xSign = (GD.Randf() >= 0.5) ? 1f : -1f;
        
        var direction = new Vector2(xSign, (float)GD.RandRange(-0.6, 0.6));
        
        //decide random  direction
       // direction = new Vector2(GD.Randi() * 2 - 1, (float)GD.RandRange(-0.6, 0.6));
        direction = direction.Normalized() * Speed;
        
        //assign the vector to the ball
        Velocity = direction;
    }

    public override void _PhysicsProcess(double delta)
    {
        MoveAndSlide();
    }

    
}
