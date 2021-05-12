using System;
using System.Drawing;
using GXPEngine;

public class MyGame : Game
{
    public World world;
    public bool paused { get; set; }

    public MyGame() : base(1920, 1080, false)
    {
        AddChild(new Menu((int)Menu.ScrType.MAINMENU));      // main/start menu
        new Sound("Background.wav", true).Play();
    }

    public void LoadLevel()
    {
        AddChild(new Sprite("Background.png"));
        paused = false;
        world = new World();

        #region IMPORTANT SINGULAR OBJECTS
        Player1 player = new Player1();
        world.AddBody(player);
        player.SetPosition(64, 1024);

        Player2 player2 = new Player2();
        world.AddBody(player2);
        player2.SetPosition(128, 1024);

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
        sc.rotation = -280;
        world.AddBody(sc);
        sc.SetPosition(768, 512);

        StaticCrystal sc2 = new StaticCrystal(340);
        sc2.rotation = -430;
        world.AddBody(sc2);
        sc2.SetPosition(512, 576);

        StaticCrystal scleft = new StaticCrystal(80);
        scleft.rotation = -170;
        world.AddBody(scleft);
        scleft.SetPosition(64, 256);

        StaticCrystal scup1 = new StaticCrystal(348);
        scup1.rotation = -438;
        world.AddBody(scup1);
        scup1.SetPosition(768, 64);

        StaticCrystal scup2 = new StaticCrystal(260);
        scup2.rotation = -350;
        world.AddBody(scup2);
        scup2.SetPosition(1088, 64);

        StaticCrystal scr1 = new StaticCrystal(340);
        scr1.rotation = -430;
        world.AddBody(scr1);
        scr1.SetPosition(1600, 288);

        StaticCrystal scr2 = new StaticCrystal(185);
        scr2.rotation = -275;
        world.AddBody(scr2);
        scr2.SetPosition(1856, 256);
        #endregion


        //Walls
        #region WALLS/TILES
        //Ground floor floating wall1 (vertical)
        Tile tile1 = new Tile(19);
        world.AddBody(tile1);
        tile1.SetPosition(512, 928);
        Tile tile2 = new Tile(162);
        world.AddBody(tile2);
        tile2.SetPosition(512, 992);

        //Ground floor floating wall2 (vertical)
        Tile tile3 = new Tile(50);
        world.AddBody(tile3);
        tile3.SetPosition(1152, 832);
        Tile tile4 = new Tile(162);
        world.AddBody(tile4);
        tile4.SetPosition(1152, 896);
        
        //First floor floating wall (vertical)
        Tile tile5 = new Tile(47);
        world.AddBody(tile5);
        tile5.SetPosition(448, 512);
        Tile tile6 = new Tile(162);
        world.AddBody(tile6);
        tile6.SetPosition(448, 576);

        // First floor button gap wall (horizontal + block down)
        Tile tile7 = new Tile(124);
        world.AddBody(tile7);
        tile7.SetPosition(64, 608);
        Tile tile8 = new Tile(124);
        world.AddBody(tile8);
        tile8.SetPosition(128, 608);
        Tile tile9 = new Tile(53);
        world.AddBody(tile9);
        tile9.SetPosition(192, 608);

        Tile tileb = new Tile(162);
        world.AddBody(tileb);
        tileb.SetPosition(192, 672);
        
        Tile tilem = new Tile(19);
        world.AddBody(tilem);
        tilem.SetPosition(832, 704);

        //Second floor floating wall1 (vertical)
        Tile tile10 = new Tile(19);
        world.AddBody(tile10);
        tile10.SetPosition(448, 288);
        Tile tile11 = new Tile(162);
        world.AddBody(tile11);
        tile11.SetPosition(448, 352);

        //Second floor floating wall2 (horizontal)
        Tile tile12 = new Tile(123);
        world.AddBody(tile12);
        tile12.SetPosition(384, 128);
        Tile tile13 = new Tile(124);
        world.AddBody(tile13);
        tile13.SetPosition(448, 128);
        Tile tile14 = new Tile(44);
        world.AddBody(tile14);
        tile14.SetPosition(512, 128);

        //Second floor floating wall3 (horizontal)
        Tile tile15 = new Tile(123);
        world.AddBody(tile15);
        tile15.SetPosition(704, 256);
        Tile tile16 = new Tile(44);
        world.AddBody(tile16);
        tile16.SetPosition(768, 256);
        
        //Second floor floating wall4 (horizontal)
        Tile tile17 = new Tile(123);
        world.AddBody(tile17);
        tile17.SetPosition(1280, 256);
        Tile tile18 = new Tile(44);
        world.AddBody(tile18);
        tile18.SetPosition(1344, 256);

        //Second floor floating wall5 (vertical)
        Tile tile19 = new Tile(19);
        world.AddBody(tile19);
        tile19.SetPosition(1536, 288);
        Tile tile20 = new Tile(162);
        world.AddBody(tile20);
        tile20.SetPosition(1536, 352);


        //Second floor ending platform (horizontal)
        Tile tile21 = new Tile(123);
        world.AddBody(tile21);
        tile21.SetPosition(1600, 192);
        Tile tile22 = new Tile(124);
        world.AddBody(tile22);
        tile22.SetPosition(1664, 192);
        Tile tile23 = new Tile(124);
        world.AddBody(tile23);
        tile23.SetPosition(1728, 192);
        Tile tile24 = new Tile(124);
        world.AddBody(tile24);
        tile24.SetPosition(1792, 192);
        Tile tile25 = new Tile(124);
        world.AddBody(tile25);
        tile25.SetPosition(1856, 192);


        //Ground floor platform
        Tile tile26 = new Tile(123);
        world.AddBody(tile26);
        tile26.SetPosition(1856, 896);


        //Floors
        //First floor
        for (int i = 0; i < 27; i++)
        {
            Tile tile = new Tile(41);
            world.AddBody(tile);
            tile.SetPosition(i * 64, 768);
        }

        //Second floor
        for (int i = 0; i < 25; i++)
        {
            Tile tile = new Tile(41);
            world.AddBody(tile);
            tile.SetPosition((i * 64) + 384, 448);
        }

        //Boundary
        //Ceiling
        for (int i = 0; i < 31; i++)
        {
            Tile tile = new Tile(30);
            world.AddBody(tile);
            tile.SetPosition(i * 64, 0);
        }

        //Floor
        for (int i = 0; i < 31; i++)
        {
            Tile tile = new Tile(227);
            world.AddBody(tile);
            tile.SetPosition(i * 64, 1088);
        }

        //Left
        for (int i = 0; i < 17; i++)
        {
            Tile tile = new Tile(57);
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

        //Left bottom corner
        Tile tile27 = new Tile(225);
        world.AddBody(tile27);
        tile27.SetPosition(0, 1088);
        //Right bottom corner
        Tile tile28 = new Tile(232);
        world.AddBody(tile28);
        tile28.SetPosition(1920, 1088);
        //Right top corner
        Tile tile29 = new Tile(36);
        world.AddBody(tile29);
        tile29.SetPosition(1920, 0);
        //Left top corner
        Tile tile30 = new Tile(29);
        world.AddBody(tile30);
        tile30.SetPosition(0, 0);

        //Ground floor right side
        Tile tile31 = new Tile(128);
        world.AddBody(tile31);
        tile31.SetPosition(1920, 896);
        //First floor ground
        Tile tile32 = new Tile(44);
        world.AddBody(tile32);
        tile32.SetPosition(1664, 768);
        //First floor intersection 1
        Tile tile33 = new Tile(81);
        world.AddBody(tile33);
        tile33.SetPosition(1152, 768);
        //First floor intersection 2
        Tile tile34 = new Tile(109);
        world.AddBody(tile34);
        tile34.SetPosition(832, 768);
        //First floor left border
        Tile tile35 = new Tile(39);
        world.AddBody(tile35);
        tile35.SetPosition(0, 768);
        //First floor left border
        Tile tile36 = new Tile(39);
        world.AddBody(tile36);
        tile36.SetPosition(0, 608);
        //Second floor first intersection
        Tile tile37 = new Tile(81);
        world.AddBody(tile37);
        tile37.SetPosition(448, 448);
        //Second floor begin ground
        Tile tile37v = new Tile(123);
        world.AddBody(tile37v);
        tile37v.SetPosition(328, 448);
        //Second floor ground intersection right
        Tile tile38 = new Tile(128);
        world.AddBody(tile38);
        tile38.SetPosition(1920, 448);
        //Second floor platform intersection right
        Tile tile39 = new Tile(128);
        world.AddBody(tile39);
        tile39.SetPosition(1920, 192);

        Canvas hudstripe = new Canvas(game.width, 100);
        #endregion
    }

    void Update()
    {
        if (world != null)
        {
            if (paused == false)
            {
                if (Input.GetKeyDown(Key.P))
                {
                    paused = true;
                    AddChild(new Menu((int)Menu.ScrType.PAUSEMENU));
                }
                world.Step();
            }
        }
    }

    static void Main()                          // Main() is the first method that's called when the program is run
    {
        new MyGame().Start();    // Create a "MyGame" and start it
    }
}