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
    public static int Pointer = -1;
    
        
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

            // CENTER MUSIC TITLE DISPLAY             
            fa.TextBox(32,110 + 15, fa.CenterText("Do I cross the line", 34));

            // MP3 UI
            fa.TextBox(34,135,"၊၊||၊|။||။|။၊|။");
            fa.TextBox(38,117 + 17,"◀◀      ❚❚      ▶︎▶︎");
            fa.TextBox(40,117+1 + 16, Style_Root.MAGENTA + "[n]   [space]   [m]" + Style_Root.RESET);
            fa.TextBox(45,111 + 15, Style_Root.MAGENTA + "[j] Vol -    [j] Vol +    [l]  Art" + Style_Root.RESET);
            
            // MUSIC FILE LIST
            App_Music_Setup.GetPlaylist();
            int line = 0;
            foreach(var file in App_Music_Setup.playlist) {
                App_Setup.MusicList(file.Substring(file.IndexOf(@"Debug\net9.0-windows\music") + 27, file.Length - (file.IndexOf(@"Debug\net9.0-windows\music") + 27)), 5, 5 + line, 178, line);
                line ++;
            }

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
            }else if (cursor == ConsoleKey.S) {
                Pointer++;
            }else if (cursor == ConsoleKey.W) {
                Pointer--;
            }
            
 
        }

    }














}









