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

        timer.Start();
    }

    public void OnTimeout()
    {
        GetTree().ReloadCurrentScene();
    }  

    private Timer timer; 
}
