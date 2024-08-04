using Godot;

public partial class Player : CharacterBody2D
{
	[Export]
	public const float Speed = 100.0f;
	[Export]
	public const float JumpVelocity = -300.0f;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	AnimatedSprite2D animatedSprite;

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
			velocity.Y += gravity * (float)delta;

		// Handle Jump.
		if (Input.IsActionJustPressed("jump") && IsOnFloor())
			velocity.Y += JumpVelocity;

		if(!IsOnFloor())
		{
			animatedSprite.Animation = "jump";
		}
		else
		{
			animatedSprite.Animation = "idle";
		}

		// Get the input direction and handle the movement/deceleration.
		Vector2 direction = Input.GetVector("move_left", "move_right", "move_up", "move_down");
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
			animatedSprite.Animation = "run";
			animatedSprite.FlipH = velocity.X < 0;// Flip animatedSprite if direction is to the left(<0)
		}
		else
		{
			animatedSprite.Animation = "idle";
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
		GD.Print(animatedSprite.Animation);
	}
	
	public override void _Ready()
	{
		animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}
}
