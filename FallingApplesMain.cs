// Author: Anthony Sam
// Email: anthonysam538@csu.fullerton.edu
// Course: CPSC 223N
// Semester: Fall 2019
// Assignment #5
// Program Name: Falling Apples

// Name of this file: FallingApplesMain.cs
// Purpose of this file: Launch the window showing the form where the falling apples can be caught.
// Purpose of this entire program: This program lets the user catch falling apples.

// Source files in this program: FallingApplesForm.cs, FallingApplesMain.cs
// The source files in this program should be compiled in the order specified below in order to satisfy dependencies.
//  1. FallingApplesForm.cs compiles into library file FallingApplesForm.dll
//  2. FallingApplesMain.cs compiles and links with the dll file above to create FallingApples.exe
// Compile (and link) this file:
// mcs -r:System.Windows.Forms.dll -r:FallingApplesForm.dll -out:FallingApples.exe FallingApplesMain.cs
// Execute (Linux shell): ./FallingApples.exe

using System;
using System.Windows.Forms;

public class FallingApplesMain
{
  public static void Main()
  {
    System.Console.WriteLine("The falling apples program will begin now.");
    FallingApplesForm FallingApples_App = new FallingApplesForm();
    Application.Run(FallingApples_App);

    System.Console.WriteLine("The falling apples program has ended.");
  }
}
