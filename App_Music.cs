using TextCopy;
using System.Management;
using System.Text.Json;
using System;
using System.Collections;
using System.Drawing.Drawing2D;
using System.Text;
using System.Threading.Tasks;
class App_Music{
    
    // -------------------------- DECLARATION --------------------------
    static Frontend_Asset fa = new Frontend_Asset();
    public static ConsoleKey cursor;
    public static bool loop_control = true;
    
        
    // -------------------------- METHOD --------------------------
    public static void Run() {
        Load();
    }

    public static void Load() {
        if (!Frontend_Setup.program_running) {
            fa.ClearCmd();    
            Frontend_Setup.program_running = true;
            App_Setup.Zoom_In(5);
            App_Setup.LoadingBar_5();
        }




        // Loading the screen
        while (loop_control) {
            fa.ClearCmd();    
            Wallpaper.Window_5();
            App_Setup.LoadTaskbarBox_5();
            App_Setup.LoadTaskbar_5("Music",69);
            fa.Box(4,130-13,35+13,43,"");
            fa.Box(4,3,123-13,43,"");
            
            // COnsole.SetCursorPosition()
            cursor = Console.ReadKey().Key;
            
 
        }

    }














}









