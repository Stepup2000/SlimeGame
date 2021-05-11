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

        #region IMPORTANT SINGULAR OBJECTS
        Player1 player = new Player1();
        world.AddBody(player);
        player.SetPosition(64, 512);

        Player2 player2 = new Player2();
        world.AddBody(player2);
        player2.SetPosition(900, 1024);

        Exit exit = new Exit();
        world.AddBody(exit);
        exit.SetPosition(1728, 128);

        Seed seed = new Seed(101);
        world.AddBody(seed);
        seed.SetPosition(1472, 1024);
        #endregion

        #region GATES+SAPLINGS
        // Vine gate (vertical, first floor, sample ID 8)
        Gate gate = new Gate(32, 96, 8);
        world.AddBody(gate);
        gate.SetPosition(448, 704);

        // "Corresponding" sapling
        Sapling sap = new Sapling(8);
        world.AddBody(sap);
        sap.SetPosition(768, 704);

        // Vine gate (horizontal ground floor, BUTTON)
        Gate gate0 = new Gate(96, 32, 101);
        world.AddBody(gate0);
        gate0.SetPosition(1792, 768);

        // Vine gate
        Gate gate1 = new Gate(32, 96, 9);
        world.AddBody(gate1);
        gate1.SetPosition(1152, 1024);

        // "Corresponding" sapling
        Sapling sap1 = new Sapling(9);
        sap1.rotation = 180;
        world.AddBody(sap1);
        sap1.SetPosition(960, 832);

        // Gate linked to spawnable sapling (ID 99)
        Gate sgate = new Gate(96, 32, 99);
        world.AddBody(sgate);
        sgate.SetPosition(256, 448);

        Gate sgate2 = new Gate(96, 32, 99);
        world.AddBody(sgate2);
        sgate2.SetPosition(64, 448);

        // Vine gate (FINAL, vertical)
        Gate gatef = new Gate(32, 96, 10);
        world.AddBody(gatef);
        gatef.SetPosition(1600, 128);

        // "Corresponding" sapling
        Sapling sapf = new Sapling(10);
        sapf.rotation = 90;
        world.AddBody(sapf);
        sapf.SetPosition(1600, 352);
        #endregion

        #region BUTTONS

        Button bseed = new Button(101, (int)Button.bType.SEED);
        world.AddBody(bseed);
        bseed.SetPosition(1600, 1024);

        Button bslime = new Button(102, (int)Button.bType.SLIME);
        world.AddBody(bslime);
        bslime.SetPosition(64, 704);

        #endregion

        #region ROCKS
        // Top rock
        Rock rock = new Rock();
        world.AddBody(rock);
        rock.SetPosition(1856, 384);

        Rock rock2 = new Rock();
        world.AddBody(rock2);
        rock2.SetPosition(1024, 704);

        Rock rock3 = new Rock();
        world.AddBody(rock3);
        rock3.SetPosition(960, 1024);
        #endregion

        // Crystals
        #region CRYSTALS
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

        StaticCrystal scr1 = new StaticCrystal(340);
        scr1.rotation = 90;
        world.AddBody(scr1);
        scr1.SetPosition(1600, 288);

        StaticCrystal scr2 = new StaticCrystal(185);
        scr2.rotation = 180;
        world.AddBody(scr2);
        scr2.SetPosition(1856, 256);
        #endregion

        //Walls
        #region WALLS/TILES
        //Ground floor floating wall1 (vertical)
        for (int i = 0; i < 2; i++)
        {
            Tile tile = new Tile();
            world.AddBody(tile);
            tile.SetPosition(512, (i * 64) + 928);
        }

        //Ground floor floating wall2 (vertical)
        for (int i = 0; i < 2; i++)
        {
            Tile tile = new Tile();
            world.AddBody(tile);
            tile.SetPosition(1152, (i * 64) + 832);
        }

        //First floor floating wall (vertical)
        for (int i = 0; i < 2; i++)
        {
            Tile tile = new Tile();
            world.AddBody(tile);
            tile.SetPosition(448, (i * 64) + 512);
        }

        // First floor button gap wall (horizontal + block down)
        for (int i = 0; i < 3; i++)
        {
            Tile tile = new Tile();
            world.AddBody(tile);
            tile.SetPosition((i * 64) + 64, 608);
        }

        Tile tileb = new Tile();
        world.AddBody(tileb);
        tileb.SetPosition(192, 672);

        Tile tilem = new Tile();
        world.AddBody(tilem);
        tilem.SetPosition(832, 704);

        //Second floor floating wall1 (vertical)
        for (int i = 0; i < 2; i++)
        {
            Tile tile = new Tile();
            world.AddBody(tile);
            tile.SetPosition(448, (i * 64) + 288);
        }

        //Second floor floating wall2 (horizontal)
        for (int i = 0; i < 3; i++)
        {
            Tile tile = new Tile();
            world.AddBody(tile);
            tile.SetPosition((i * 64) + 384, 128);
        }

        //Second floor floating wall3 (horizontal)
        for (int i = 0; i < 2; i++)
        {
            Tile tile = new Tile();
            world.AddBody(tile);
            tile.SetPosition((i * 64) + 704, 256);
        }

        //Second floor floating wall4 (horizontal)
        for (int i = 0; i < 2; i++)
        {
            Tile tile = new Tile();
            world.AddBody(tile);
            tile.SetPosition((i * 64) + 1280, 256);
        }

        //Second floor floating wall5 (vertical)
        for (int i = 0; i < 2; i++)
        {
            Tile tile = new Tile();
            world.AddBody(tile);
            tile.SetPosition(1536, (i * 64) + 288);
        }

        //Second floor ending platform (horizontal)
        for (int i = 0; i < 5; i++)
        {
            Tile tile = new Tile();
            world.AddBody(tile);
            tile.SetPosition((i* 64) + 1600, 192);
        }

        //Ground floor platform
        for (int i = 0; i < 3; i++)
        {
            Tile tile = new Tile();
            world.AddBody(tile);
            tile.SetPosition((i * 64) + 1856, 896);
        }


        //Floors
        //First floor
        for (int i = 0; i < 27; i++)
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
        for (int i = 0; i < 31; i++)
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
            tile.SetPosition(i * 64, 1088);
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
        #endregion

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