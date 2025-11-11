
using System;

namespace azuki_project {
    public class Program {

        public static string User = "Mashiro";


        // public static readonly string BLACK_ON_WHITE = "\u001b[30;47m";
        // public static readonly string WHITE_ON_BLACK = "\u001b[37;40m\u001b[0m";

        // public static int Pointer = 0;
        // public static ConsoleKey Cursor;
        
        // Frontend_Setup frontend = new Frontend_Setup();


        public static void Main(string[] args) {
            Frontend_Setup.Run();
            
            // int window_line = 7;
            // int window_col = 20; 
            // Gui_sim g1 = new Gui_sim();
            // g1.MHA_Screen();
                
            // while (true) {

            //     string[] file_icon_1 = {
            //     @"..._________.......",
            //     @"...\        \___...",
            //     @"....\        \ |...",
            //     @".....\________\|...",
            //     @"........file 1....."
            // };

            //     g1.Icon(file_icon_1, 1, 8, 2);
            //     g1.Icon(file_icon_1, 2, 14, 2);
            //     g1.Icon(file_icon_1, 3, 20, 2);
            //     g1.Icon(file_icon_1, 4, 8, 20);
            //     g1.TextBox(2, 5, "Helooo");
            //     g1.TextBox(2, 18, "World");

            //     Cursor = Console.ReadKey().Key;
            //     if (Program.Cursor == ConsoleKey.UpArrow) {
            //         window_line -= 2;
            //     }
            //     else if (Program.Cursor == ConsoleKey.DownArrow) {
            //         window_line += 2;
            //     }
            //     else if (Program.Cursor == ConsoleKey.LeftArrow) {
            //         window_col -= 2;
            //     }
            //     else if (Program.Cursor == ConsoleKey.RightArrow) {
            //         window_col += 2;
            //     }else if(Cursor == ConsoleKey.D) {
            //         Pointer++;
            //     }else if(Cursor == ConsoleKey.A) {
            //         Pointer--;
            //     }
            // }
        }











        // static void Battery() {
        //       var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Battery");

        // foreach (var battery in searcher.Get())
        // {
        //     Console.WriteLine($"Battery Name: {battery["Name"]}");
        //     Console.WriteLine($"Estimated Charge Remaining: {battery["EstimatedChargeRemaining"]}%");
        //     Console.WriteLine($"Battery Status: {battery["BatteryStatus"]}");
        // }

        // Console.ReadLine();
        // }


    }
}


    