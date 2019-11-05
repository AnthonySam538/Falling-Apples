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
  private const short radius = 10;
  private const short distance = 100; //100 pixels per second
  private short applesCaught = 0;

  private Button startButton = new Button();
  private Button exitButton = new Button();
  private Label applesCaughtCounter = new Label();
  private Label blueSky = new Label();
  private Label controlPanel = new Label();

  public FallingApplesForm()
  {
    // Set up texts
    Text = "Falling Apples";
    blueSky.Text = "Falling Apples by Anthony Sam";
    blueSky.TextAlign = ContentAlignment.TopRight;
    controlPanel.Text = "Control Panel";
    controlPanel.TextAlign = ContentAlignment.TopCenter;
    startButton.Text = "Start";
    applesCaughtCounter.Text = "Apples Caught: " + applesCaught;
    exitButton.Text = "Exit";

    // Set up sizes
    Size = new Size(formWidth, formHeight);
    blueSky.Size = new Size(formWidth, formHeight*7/10);
    controlPanel.Size = new Size(formWidth, formHeight/10);

    // Set up locations
    controlPanel.Location = new Point(0, formHeight-controlPanel.Height);
    startButton.Location = new Point(formWidth/4, controlPanel.Top + controlPanel.Height/2 - startButton.Height/2);
    applesCaughtCounter.Location = new Point(formWidth/2,controlPanel.Top + controlPanel.Height/2 - applesCaughtCounter.Height/2);
    exitButton.Location = new Point(formWidth*3/4, startButton.Top);

    // Set up colors
    BackColor = Color.Peru;
    blueSky.BackColor = Color.Cyan;
    controlPanel.BackColor = Color.Yellow;
    applesCaughtCounter.BackColor = controlPanel.BackColor;

    // Add the controls to the form
    Controls.Add(applesCaughtCounter);
    Controls.Add(startButton);
    Controls.Add(exitButton);
    Controls.Add(blueSky);
    Controls.Add(controlPanel);

    // Assign methods to controls
  }

  protected override void OnPaint(PaintEventArgs e)
  {
    Graphics graphics = e.Graphics;

    graphics.FillEllipse(Brushes.Red, formWidth/2, 791, 50, 70);

    base.OnPaint(e);
  }

  protected override void OnMouseDown(MouseEventArgs e) //when the user clicks on the background (the dirt, in this case)
  {
    // System.Console.WriteLine(e.X);
    // System.Console.WriteLine(e.Y);
  }
}
