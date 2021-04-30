using System;									// System contains a lot of default C# libraries 
using System.Drawing;                           // System.Drawing contains a library used for canvas drawing below
using GXPEngine;								// GXPEngine contains the engine

public class MyGame : Game
{
	public MyGame() : base(1920, 1080, false)		// Create a window that's 800x600 and NOT fullscreen
	{
        //----------------------------------------------------example-code----------------------------
        //create a canvas
        Canvas canvas = new Canvas(1920, 1080);

        //add canvas to display list
        AddChild(canvas);
		//------------------------------------------------end-of-example-code-------------------------
		Player1 player = new Player1(50, 250);
		AddChild(player);
	}

    void Update()
	{
		//----------------------------------------------------example-code----------------------------
		if (Input.GetKeyDown(Key.SPACE)) // When space is pressed...
		{
			new Sound("ping.wav").Play(); // ...play a sound
		}
		//------------------------------------------------end-of-example-code-------------------------
	}

	static void Main()							// Main() is the first method that's called when the program is run
	{
		new MyGame().Start();					// Create a "MyGame" and start it
	}
}