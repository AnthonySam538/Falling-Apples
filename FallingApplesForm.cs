// Author: Anthony Sam
// Email: anthonysam538@csu.fullerton.edu
// Course: CPSC 223N
// Semester: Fall 2019
// Assignment #5
// Program Name: Falling Apples

// Name of this file: FallingApplesForm.cs
// Purpose of this file: Define the layout of the user interface (UI) window.
// Purpose of this entire program: This program lets the user catch falling apples.

// Source files in this program: FallingApplesForm.cs, FallingApplesMain.cs
// The source files in this program should be compiled in the order specified below in order to satisfy dependencies.
//  1. FallingApplesForm.cs compiles into library file FallingApplesForm.dll
//  2. FallingApplesMain.cs compiles and links with the dll file above to create FallingApples.exe
// Compile this file:
// mcs -target:library -r:System.Drawing.dll -r:System.Windows.Forms.dll -out:FallingApplesForm.dll FallingApplesForm.cs

using System;
using System.Timers;
using System.Drawing;
using System.Windows.Forms;

public class FallingApplesForm : Form
{
  private const short formHeight = 1000;
  private const short formWidth = formHeight * 16/9;
  private const short diameter = 70;
  private const short distance = 4; //100 pixels per animationClock's tick
  private const double refreshRate = 1000/20; //20 frames per second
  private const double animationRate = 1000/30; //30 updates per second
  private short fallenApples = 0; //only 10 apples will fall
  private short applesCaught = 0;

  // Create point
  private Point apple = new Point(-diameter, -diameter); //it's initially off-screen

  // Create Controls
  private Button startButton = new Button();
  private Button exitButton = new Button();
  private Label applesCaughtCounter = new Label();
  private Label controlPanel = new Label();

  // Create Timers
  private static System.Timers.Timer refreshClock = new System.Timers.Timer(refreshRate);
  private static System.Timers.Timer animationClock = new System.Timers.Timer(animationRate);

  public FallingApplesForm()
  {
    // Set up texts
    Text = "Falling Apples";
    controlPanel.Text = "Control Panel";
    controlPanel.TextAlign = ContentAlignment.TopCenter;
    startButton.Text = "Start";
    applesCaughtCounter.Text = "Apples caught: " + applesCaught;
    exitButton.Text = "Exit";

    // Set up sizes
    Size = new Size(formWidth, formHeight);
    controlPanel.Size = new Size(formWidth, formHeight/10);

    // Set up locations
    controlPanel.Location = new Point(0, formHeight-controlPanel.Height);
    startButton.Location = new Point(formWidth/4, controlPanel.Top + controlPanel.Height/2 - startButton.Height/2);
    applesCaughtCounter.Location = new Point(formWidth/2,controlPanel.Top + controlPanel.Height/2 - applesCaughtCounter.Height/2);
    exitButton.Location = new Point(formWidth*3/4, startButton.Top);

    // Set up colors
    BackColor = Color.Peru;
    controlPanel.BackColor = Color.Yellow;
    applesCaughtCounter.BackColor = controlPanel.BackColor;

    // Add the controls to the form
    Controls.Add(applesCaughtCounter);
    Controls.Add(startButton);
    Controls.Add(exitButton);
    Controls.Add(controlPanel);

    // Assign methods to controls
    startButton.Click += new EventHandler(start);
    exitButton.Click += new EventHandler(exit);
    refreshClock.Elapsed += new ElapsedEventHandler(refreshScreen);
    animationClock.Elapsed += new ElapsedEventHandler(updateApple);
  }

  protected override void OnPaint(PaintEventArgs e)
  {
    Graphics graphics = e.Graphics;

    graphics.FillRectangle(Brushes.Cyan, 0, 0, formWidth, formHeight*7/10); //blue sky

    graphics.FillEllipse(Brushes.Red, apple.X, apple.Y, diameter, diameter);

    base.OnPaint(e);
  }

  protected override void OnMouseDown(MouseEventArgs e) //when the user clicks on the background (the dirt, in this case)
  {
    System.Console.WriteLine(Math.Sqrt(Math.Pow(e.X-apple.X, 2) + Math.Pow(e.Y-apple.Y, 2)));
    if(apple.Y+diameter > formHeight*7/10 && Math.Sqrt(Math.Pow(apple.X+diameter/2-e.X, 2) + Math.Pow(apple.Y+diameter/2-e.Y, 2)) <= diameter/2) //if the apple's low enough and it's been clicked
    {
      applesCaughtCounter.Text = "Apples caught: " + ++applesCaught;
      spawnApple();
    }
  }

  protected void spawnApple()
  {
    apple.X = formWidth/2;

    if(fallenApples >= 10)
    {
      refreshClock.Stop();
      animationClock.Stop();
      apple.Y = -diameter;
      Invalidate();
    }
    else
    {
      fallenApples++;
      apple.Y = 0;
    }
  }

  protected void start(Object sender, EventArgs events)
  {
    fallenApples = 0;
    applesCaught = 0;

    spawnApple();

    refreshClock.Start();
    animationClock.Start();
  }

  protected void exit(Object sender, EventArgs events)
  {
    System.Console.WriteLine("You clicked on the Exit button.");
    Close();
  }

  protected void refreshScreen(Object sender, ElapsedEventArgs events)
  {
    Invalidate();
  }

  protected void updateApple(Object sender, ElapsedEventArgs events)
  {
    apple.Y += distance;

    if(apple.Y+diameter > controlPanel.Top)
      spawnApple();
  }
}
