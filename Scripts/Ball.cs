using Godot;
using System;

public partial class Ball : CharacterBody2D
{
    [Export]
    public float Speed { get; set; } = 300.0f;
    
    //cache audio sounds
    private AudioStreamPlayer _wallBounceSound;
    private AudioStreamPlayer _paddleBounceSound;

    public override void _Ready()
    {
        //grab ref to the audio nodes
        _wallBounceSound = GetNode<AudioStreamPlayer>("WallBounceSound");
        _paddleBounceSound = GetNode<AudioStreamPlayer>("PaddleBounceSound");
    }

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

    private void PlayBounceSound(KinematicCollision2D collisionInfo)
    {
        if (collisionInfo.GetCollider() is Paddle)
        {
            _paddleBounceSound.Play();
        }
        else if (collisionInfo.GetCollider() is Node node && node.IsInGroup("Walls"))
        {
            _wallBounceSound.Play();
        }
    }
    public override void _PhysicsProcess(double delta)
    {

        var collisionInfo = MoveAndCollide(Velocity * (float)delta);
        
        //something here can be extracted, i'm sure of it
        if (collisionInfo != null)
        { 
            Velocity = Velocity.Bounce(collisionInfo.GetNormal());
            
            PlayBounceSound(collisionInfo);
        }
        
        
    }


    
}
