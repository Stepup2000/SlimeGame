using System;
using System.Drawing;
using GXPEngine;

public class MyGame : Game
{
    World world;

    public MyGame() : base(1920, 1080, false)
    {
        loadLevel();
    }

    private void loadLevel()
    {
        world = new World();

        Player1 player = new Player1(64);
        world.AddBody(player);
        player.SetPosition(64, 100);

        Player2 player2 = new Player2(64);
        world.AddBody(player2);
        player2.SetPosition(900, 65);

        // Vine gate
        Gate gate = new Gate("square.png", 32, 32, 0, 8);
        world.AddBody(gate);
        gate.SetPosition(200, 200);

        // "Corresponding" sapling
        Sapling sap = new Sapling(0);
        world.AddBody(sap);
        sap.SetPosition(800, 640);

        // Top rock
        Rock rock = new Rock(64);
        world.AddBody(rock);
        rock.SetPosition(1856, 384);

        Rock rock2 = new Rock(64);
        world.AddBody(rock2);
        rock2.SetPosition(960, 704);

        Rock rock3 = new Rock(64);
        world.AddBody(rock3);
        rock3.SetPosition(960, 1024);

        // Crystals
        StaticCrystal sc = new StaticCrystal(190);
        sc.rotation = 180;
        world.AddBody(sc);
        sc.SetPosition(768, 512);

        StaticCrystal sc2 = new StaticCrystal(320);
        sc2.rotation = 90;
        world.AddBody(sc2);
        sc2.SetPosition(512, 576);

        StaticCrystal scleft = new StaticCrystal(80);
        scleft.rotation = 90;
        world.AddBody(scleft);
        scleft.SetPosition(64, 256);

        StaticCrystal scup1 = new StaticCrystal(348);
        scup1.rotation = 180;
        world.AddBody(scup1);
        scup1.SetPosition(768, 64);

        StaticCrystal scup2 = new StaticCrystal(260);
        scup2.rotation = 180;
        world.AddBody(scup2);
        scup2.SetPosition(1088, 64);

        /*StaticCrystal scup3 = new StaticCrystal(290);
        scup3.rotation = 180;
        world.AddBody(scup3);
        scup3.SetPosition(1152, 64);*/

        StaticCrystal scr1 = new StaticCrystal(320);
        scr1.rotation = 90;
        world.AddBody(scr1);
        scr1.SetPosition(1600, 288);

        StaticCrystal scr2 = new StaticCrystal(185);
        scr2.rotation = 180;
        world.AddBody(scr2);
        scr2.SetPosition(1856, 256);

        //Walls
        //Ground floor floating wall1 (vertical)
        for (int i = 0; i < 2; i++)
        {
            Tile tile = new Tile(64);
            world.AddBody(tile);
            tile.SetPosition(512, (i * 64) + 928);
        }

        //Ground floor floating wall2 (vertical)
        for (int i = 0; i < 2; i++)
        {
            Tile tile = new Tile(64);
            world.AddBody(tile);
            tile.SetPosition(1152, (i * 64) + 832);
        }

        //First floor floating wall (vertical)
        for (int i = 0; i < 2; i++)
        {
            Tile tile = new Tile(64);
            world.AddBody(tile);
            tile.SetPosition(448, (i * 64) + 512);
        }

        //Second floor floating wall1 (vertical)
        for (int i = 0; i < 2; i++)
        {
            Tile tile = new Tile(64);
            world.AddBody(tile);
            tile.SetPosition(448, (i * 64) + 288);
        }

        //Second floor floating wall2 (horizontal)
        for (int i = 0; i < 3; i++)
        {
            Tile tile = new Tile(64);
            world.AddBody(tile);
            tile.SetPosition((i * 64) + 384, 128);
        }

        //Second floor floating wall3 (horizontal)
        for (int i = 0; i < 2; i++)
        {
            Tile tile = new Tile(64);
            world.AddBody(tile);
            tile.SetPosition((i * 64) + 704, 256);
        }

        //Second floor floating wall4 (horizontal)
        for (int i = 0; i < 2; i++)
        {
            Tile tile = new Tile(64);
            world.AddBody(tile);
            tile.SetPosition((i * 64) + 1280, 256);
        }

        //Second floor floating wall5 (vertical)
        for (int i = 0; i < 2; i++)
        {
            Tile tile = new Tile(64);
            world.AddBody(tile);
            tile.SetPosition(1536, (i * 64) + 288);
        }

        //Second floor ending platform (horizontal)
        for (int i = 0; i < 5; i++)
        {
            Tile tile = new Tile(64);
            world.AddBody(tile);
            tile.SetPosition((i* 64) + 1600, 192);
        }

        //Ground floor platform
        for (int i = 0; i < 4; i++)
        {
            Tile tile = new Tile(64);
            world.AddBody(tile);
            tile.SetPosition((i * 64) + 1792, 896);
        }


        //Floors
        //First floor
        for (int i = 0; i < 25; i++)
        {
            Tile tile = new Tile(64);
            world.AddBody(tile);
            tile.SetPosition(i * 64, 768);
        }

        //Second floor
        for (int i = 0; i < 25; i++)
        {
            Tile tile = new Tile(64);
            world.AddBody(tile);
            tile.SetPosition((i * 64) + 384, 448);
        }

        //Boundary
        //Ceiling
        for (int i = 0; i < 31; i++)
        {
            Tile tile = new Tile(64);
            world.AddBody(tile);
            tile.SetPosition(i * 64, 0);
        }

        //Floor
        for (int i = 0; i < 31; i++)
        {
            Tile tile = new Tile(64);
            world.AddBody(tile);
            tile.SetPosition(i * 64, 1088);
        }

        //Left
        for (int i = 0; i < 17; i++)
        {
            Tile tile = new Tile(64);
            world.AddBody(tile);
            tile.SetPosition(0, i * 64);
        }

        //Right
        for (int i = 0; i < 17; i++)
        {
            Tile tile = new Tile(64);
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