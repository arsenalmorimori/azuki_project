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

        // UI LAYOUT 
        fa.ClearCmd();    
        Wallpaper.Window_5();
        App_Setup.LoadTaskbarBox_5();
        App_Setup.LoadTaskbar_5("Music",69);
        fa.Box(4,117,35+13,43,"");
        fa.Box(4,3,123-13,43,"");



        // LOOP SYSTEM
        while (loop_control) {

            // ART
            fa.Graphics(Style_Root.Mp3_art(env.mp3_wallpaper),10, 125,"","");

            // MP3 UI
            fa.TextBox(31,135,"၊၊||၊|။||။|။၊|။");
            fa.TextBox(37,117 + 17,"◀◀      ❚❚      ▶︎▶︎");
            fa.TextBox(39,117+1 + 16, Style_Root.MAGENTA + "[n]   [space]   [m]" + Style_Root.RESET);
            fa.TextBox(43,116 + 15, Style_Root.MAGENTA + "[j]  -  Volume UP" + Style_Root.RESET);
            fa.TextBox(44,116 + 15, Style_Root.MAGENTA + "[k]  -  Volume DOWN" + Style_Root.RESET);
            fa.TextBox(45,116 + 15, Style_Root.MAGENTA + "[l]  -  Change Art" + Style_Root.RESET);
            
            // USER INPUT
            Console.SetCursorPosition(164,49);
            cursor = Console.ReadKey().Key;

            if (cursor == ConsoleKey.L) {
                if(env.mp3_wallpaper == 5) {
                    env.mp3_wallpaper = 0;
                }
                else {
                    env.mp3_wallpaper++;                    
                }
            }
            
 
        }

    }














}









