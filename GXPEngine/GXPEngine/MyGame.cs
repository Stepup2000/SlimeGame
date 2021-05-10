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
        tilea.SetPosition(game.width - 64, game.height / 2 - 64);

        Tile tileb = new Tile(false, false);
        world.AddBody(tileb);
        tileb.SetPosition(640, game.height / 4 - 64);

        StaticCrystal sc = new StaticCrystal(60);
        world.AddBody(sc);
        sc.SetPosition(512, game.height / 2 - 64);

        //Walls

        //Ground floor floating wall1
        for (int i = 0; i < 1; i++)
        {
            Tile tile = new Tile();
            world.AddBody(tile);
            tile.SetPosition(512, (i * 64) + 960);
        }

        //Ground floor floating wall2
        for (int i = 0; i < 2; i++)
        {
            Tile tile = new Tile();
            world.AddBody(tile);
            tile.SetPosition(1024, (i * 64) + 832);
        }

        //Ground floor platform
        for (int i = 0; i < 4; i++)
        {
            Tile tile = new Tile();
            world.AddBody(tile);
            tile.SetPosition((i * 64) + 1792, 896);
        }

        //Floors
        //First floor
        for (int i = 0; i < 25; i++)
        {
            Tile tile = new Tile();
            world.AddBody(tile);
            tile.SetPosition(i * 64, 768);
        }

        //Second floor
        for (int i = 0; i < 25; i++)
        {
            Tile tile = new Tile();
            world.AddBody(tile);
            tile.SetPosition((i * 64) + 384, 448);
        }

        //Boundary
        //Ceiling
        for (int i = 0; i < 31; i ++)
        {
            Tile tile = new Tile();
            world.AddBody(tile);
            tile.SetPosition(i * 64, 0);
        }

        //Floor
        for (int i = 0; i < 31; i++)
        {
            Tile tile = new Tile();
            world.AddBody(tile);
            tile.SetPosition(i * 64, game.height);
        }

        //Left
        for (int i = 0; i < 17; i++)
        {
            Tile tile = new Tile();
            world.AddBody(tile);
            tile.SetPosition(0, i * 64);
        }

        //Right
        for (int i = 0; i < 17; i++)
        {
            Tile tile = new Tile();
            world.AddBody(tile);
            tile.SetPosition(game.width, i * 64);
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