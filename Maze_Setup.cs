using System;
using System.Runtime.InteropServices;
using Figgle; //For Figgle ASCII Art Letters  
using Figgle.Fonts; //For Figgle ASCII Art Letters  

class Maze_Setup {
    public static Frontend_Asset fa = new Frontend_Asset(); 
    public static void Run() {
        
        if (!Frontend_Setup.program_running) {
            fa.ClearCmd();
            App_Setup.Zoom_In(5);
            Frontend_Setup.program_running = true;
            App_Setup.LoadingBar_5();
        }
        bool loop_control = true;
        
        
        while(loop_control ){
            fa.ClearCmd();

            // Set console to maximum size
            Console.WindowWidth = Console.LargestWindowWidth;
            Console.WindowHeight = Console.LargestWindowHeight;


            // Difficulty selector and setup
            Console.WriteLine(FiggleFonts.Standard.Render("       Welcome to Maze Game!"));
            Console.WriteLine(FiggleFonts.Standard.Render("Choose difficulty:"));
            Console.WriteLine(FiggleFonts.Standard.Render("(E)asy"));
            Console.WriteLine(FiggleFonts.Standard.Render("(M)edium"));
            Console.WriteLine(FiggleFonts.Standard.Render("(H)ard"));
            Console.WriteLine(FiggleFonts.Standard.Render("[C]lose"));

            bool input = true;
            while (input) {
                ConsoleKey choice = Console.ReadKey(true).Key;

                if (choice == ConsoleKey.C) {
                    input = false;
                    loop_control = false;
                    fa.ClearCmd();
                    App_Setup.Zoom_Out(5);
                    App_Setup.LoadingBar();
                }
                else {
                    if (choice == ConsoleKey.E) { input = false; InitializedGame(21,11);}  //For Easy Mode
                    else if (choice == ConsoleKey.M) { input = false;  InitializedGame(31,15);} //For Medium Mode
                    else if (choice == ConsoleKey.H) { input = false;  InitializedGame(91,21);}  //For Hard Mode
                }
                
            }
        }
    }

    public static void InitializedGame(int width, int height) {
         // Initialize and run the game
        MazeGame game = new MazeGame(width, height);
        
        App_Setup.Zoom_In(8);
        game.Run(); 
    }
}