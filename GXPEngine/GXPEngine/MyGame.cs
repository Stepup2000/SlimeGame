using System;
using System.Drawing;
using GXPEngine;

// Code architecture basis (Body->Circle->Player with
// circle/circle overlaps) by Bram den Hond

public class MyGame : Game
{
    World world;

    public MyGame() : base(800, 600, false)     // Create a window that's 800x600 and NOT fullscreen
    {
        world = new World();
        AddChild(world);

        Player player = new Player(new Vec2(0, 1f));
        player.acceleration = new Vec2(0, 0.3f);
        world.AddBody(player);
        player.SetPosition(64, 100);

        Player player2 = new Player(new Vec2(0, 1f));
        player2.acceleration = new Vec2(0, 0.3f);
        world.AddBody(player2);
        player2.SetPosition(305, 110);

        /*Ball ball = new Ball();
        world.AddBody(ball);
        ball.SetPosition(305, 110);*/

        Rock tilea = new Rock();
        world.AddBody(tilea);
        tilea.SetPosition(128, game.height / 2 - 64);

        for (int i = 0; i < game.width; i += 64)
        {
            Tile tile = new Tile();
            world.AddBody(tile);
            tile.SetPosition(i, game.height / 2);
        }
    }

    void Update()
    {
        world.Step();
    }

    static void Main()                          // Main() is the first method that's called when the program is run
    {
        new MyGame().Start();                   // Create a "MyGame" and start it
    }
}