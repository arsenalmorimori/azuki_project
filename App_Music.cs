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
    public static ConsoleKeyInfo cursor;
    public static bool loop_control = true;
    public static int Pointer = -1;
    public static int p = 0;
    public static string current_song = "---------------------------------";
    
        
    // -------------------------- METHOD --------------------------
    public static void Run() {
        Load();     
               
        Thread music_background = new Thread(App_Music_Setup.Music_Activity);
        music_background.IsBackground = true;
        music_background.Start();

        InputSystem();

        Console.WriteLine("LOAD LOADEDDD : "+ p);
        p++;  
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

    }

    public static void UI() {
        // ART
        fa.Graphics(Style_Root.Mp3_art(env.mp3_wallpaper),10, 125,"","");
        // CENTER MUSIC TITLE DISPLAY             
        fa.TextBox(32,110 + 15, "                                  ");
        fa.TextBox(32,110 + 15, fa.CenterText(current_song, 34));

        // MP3 UI
        fa.TextBox(34,135,"၊၊||၊|။||။|။၊|။");
        if (App_Music_Setup.play_pause == 0) {
            fa.TextBox(38,117 + 17,"◀◀      ❚❚      ▶︎▶︎");
        }else {
            fa.TextBox(38,117 + 17,"◀◀      ▶︎       ▶︎▶︎");
        }
        fa.TextBox(40,117+1 + 16, Style_Root.MAGENTA + "[n]   [space]   [m]" + Style_Root.RESET);
        fa.TextBox(45,111 + 15, Style_Root.MAGENTA + "[j] Vol -    [k] Vol +    [l]  Art" + Style_Root.RESET);
        
        // MUSIC FILE LIST
        App_Music_Setup.GetPlaylist();
        int line = 0;
        foreach(var file in App_Music_Setup.playlist) {
            App_Setup.MusicList(file.Substring(file.IndexOf(@"Debug\net9.0-windows\music") + 27, file.Length - (file.IndexOf(@"Debug\net9.0-windows\music") + 27)), 5, 5 + line, 112, line);
            line ++;
        }
    }

    public static void InputSystem() {

        // LOOP SYSTEM
        while (loop_control) {
            UI();
            

           // USER INPUT
            // Console.SetCursorPosition(164,49);
            cursor = Console.ReadKey(intercept: true);

            if (cursor.Key == ConsoleKey.L) {
                if(env.mp3_wallpaper == 5) {
                    env.mp3_wallpaper = 0;
                }
                else {
                    env.mp3_wallpaper++;                    
                }
            }else if (cursor.Key == ConsoleKey.S) {
                if(Pointer > App_Music_Setup.playlist.Length - 1){
                }else{
                    Pointer++;
                }
            }else if (cursor.Key == ConsoleKey.W) {
                if(Pointer < 0){
                }else{
                    Pointer--;
                }
            }else if (cursor.Key == ConsoleKey.Enter) {
                if (Pointer >= 0 && Pointer < App_Music_Setup.playlist.Length) {
                    App_Music_Setup.index_request = Pointer;
                    App_Music_Setup.Stop();
                    App_Music_Setup.PlaySong(App_Music_Setup.playlist[App_Music_Setup.index_request]);
                }
            }else if (cursor.Key == ConsoleKey.Spacebar) {
                App_Music_Setup.Play_Pause();
            }else if (cursor.Key == ConsoleKey.J) {
                App_Music_Setup.volume -= 0.05f;
            }else if (cursor.Key == ConsoleKey.K) {                
                App_Music_Setup.volume += 0.05f;
            }else if (cursor.Key == ConsoleKey.N) {
                if(App_Music_Setup.current_index == 0){
                        App_Music_Setup.index_request = App_Music_Setup.playlist.Length-1;
                    }else{
                        App_Music_Setup.index_request--;
                    }          
                Thread.Sleep(1000);
            }else if (cursor.Key == ConsoleKey.M) {      
                 if(App_Music_Setup.current_index == App_Music_Setup.playlist.Length-1){
                        App_Music_Setup.index_request = 0;
                    }else{
                        App_Music_Setup.index_request++;    
                    }          
                Thread.Sleep(1000);
            }else if(cursor.Key == ConsoleKey.X) {
                    fa.ClearCmd();
                    App_Setup.LoadingBar_5();
                    App_Setup.Zoom_Out(5);
                    break;
            }
            
        }

    }














}









