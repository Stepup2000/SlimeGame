using System;
using System.Drawing;
using GXPEngine;

// Code architecture basis (Body->Circle->Player with
// circle/circle overlaps) by Bram den Hond

public class MyGame : Game
{
    World world;

    public MyGame() : base(1920, 1080, false)
    {
        world = new World();

        Player1 player = new Player1();
        world.AddBody(player);
        player.SetPosition(64, 100);

        Player2 player2 = new Player2();
        world.AddBody(player2);
        player2.SetPosition(game.width - 64, 100);

        Tile tilea = new Tile(false, false);
        world.AddBody(tilea);
        tilea.SetPosition(320, game.height / 2 - 64);

        Tile tileb = new Tile(false, false);
        world.AddBody(tileb);
        tileb.SetPosition(640, game.height / 4 - 64);

        StaticCrystal sc = new StaticCrystal(60);
        world.AddBody(sc);
        sc.SetPosition(512, game.height / 2 - 64);

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