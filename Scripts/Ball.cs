using Godot;
using System;

public partial class Ball : CharacterBody2D
{
    [Export]
    public float Speed { get; set; } = 300.0f;
    
    //cache audio sounds
    private AudioStreamPlayer _wallBounceSound;
    private AudioStreamPlayer _paddleBounceSound;
    
    static readonly  Vector2 SCREEN_CENTER = new Vector2(400, 300);
    private const float X_DIRECTION_THRESHOLD = 0.5f;
    private const float Y_DIRECTION_RANGE_MAX = 0.6f;
    
    public override void _Ready()
    {
        //grab ref to the audio nodes
        _wallBounceSound = GetNode<AudioStreamPlayer>("WallBounceSound");
        _paddleBounceSound = GetNode<AudioStreamPlayer>("PaddleBounceSound");
    }

    public void Reset()
    {
        //move ball to center of screen
        Position = SCREEN_CENTER;
        
        //xSign for x direction 
        float xSign = (GD.Randf() >= X_DIRECTION_THRESHOLD) ? 1f : -1f;
        
        var direction = new Vector2(xSign, (float)GD.RandRange(-Y_DIRECTION_RANGE_MAX, Y_DIRECTION_RANGE_MAX));
        
        //decide random direction
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

        if (collisionInfo != null)
        {
            HandleBounce(collisionInfo);
        }
    }

    private void HandleBounce(KinematicCollision2D collisionInfo)
    {
            Velocity = Velocity.Bounce(collisionInfo.GetNormal());
            
            PlayBounceSound(collisionInfo);
    }
}
