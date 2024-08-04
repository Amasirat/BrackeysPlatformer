using Godot;

public partial class Killzone : Area2D
{
    public override void _Ready()
    {
        timer = GetNode<Timer>("Timer");
    }
    public void OnBodyEntered(Node2D body)
    {
        GD.Print("Died!");
        Engine.TimeScale = 0.5;
        body.GetNode<CollisionShape2D>("CollisionShape2D").SetDeferred(CollisionShape2D.PropertyName.Disabled, true);
        timer.Start();
    }

    public void OnTimeout()
    {
        Engine.TimeScale = 1;
        GetTree().ReloadCurrentScene();
    }  

    private Timer timer; 
}
