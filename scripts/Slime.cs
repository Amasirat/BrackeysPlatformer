using Godot;
using System.Collections.Generic;

public partial class Slime : Node2D
{
	public override void _Ready()
	{
		RayCast = new RayCast2D[2];
		RayCast[0] = GetNode<RayCast2D>("RayCastRight");
		RayCast[1] = GetNode<RayCast2D>("RayCastLeft");
		animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

		if(RayCast[0].IsColliding())
		{
			direction = -1;
			animatedSprite.FlipH = true;
		}

		if(RayCast[1].IsColliding())
		{
			animatedSprite.FlipH = false;
			direction = 1;
		}
		
		Vector2 pos = Position;
		pos.X += Speed * (float)delta * direction;
		Position = new Vector2(pos.X, pos.Y);
	}

	[Export]
	public float Speed;

	public int direction = 1;
	private RayCast2D[] RayCast;
	private AnimatedSprite2D animatedSprite;
}
