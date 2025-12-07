
using System;

using System.Management;
using Microsoft.VisualBasic.Devices;
public class Frontend_Setup {

    /*
        DESCRIPTION : 
            - Setup or the Process of Loading the HOMESCREEN and process the navigation system between Apps and Homescreen
        
        PROCESS : 
            - USER MODE
                1   : Display the Wallpaper 
                2   : Display the Taskbar
                3   : Display the Icons
                4   : Get User Input 
                5.1 : Call Run() of the app if ENTER 
                5.2 : Back to process 2 if OTHER
            
            - DEV MODE
                1   : Run the called method only for faster load
    */


    // -------------- VARIABLES --------------
    public static int Pointer = 0;
    public static ConsoleKey Cursor;
    static Frontend_Asset fa = new Frontend_Asset();
    public static bool program_running = true;




    // -------------- MAIN METHOD --------------
    public static void Run() {
        Load();
    }



    // -------------- METHODS --------------
    public static void Load() {
        while (true) {
            if((env.dev & 1) == 1) {
                App_Music.Run();
                User_Cursor();
            }else {
                if(program_running){
                    fa.ClearCmd();
                    Wallpaper.LoadWallpaper();
                    fa.Box(1, 3, 304, 1,"");
                    program_running = false;
                }
                    Load_Taskbar();
                    Load_Gui();
                    User_Cursor();
            }
          
        }
        
    }

    public static void Load_Gui() {
        // ICONS
        if(env.icon_layout == 0){
            int col = 10;
            fa.Icon(Style_Root.terminal_ico, 1, Pointer, 66+7, col);
            col += 20;
            fa.Icon(Style_Root.notepad_ico, 2, Pointer, 66+7, col);
            col += 20;
            fa.Icon(Style_Root.thread_ico, 3, Pointer, 66+7, col);
            col += 20;
            fa.Icon(Style_Root.file_ico, 4, Pointer, 66+7, col);
            col += 20;
            fa.Icon(Style_Root.file_ico, 5, Pointer, 66+7, col);
            col += 20;

            Widget_Clock();
        }else if (env.icon_layout == 1) {
            int line = 7;
            fa.Icon(Style_Root.terminal_ico, 1, Pointer, line, 5);
            line += 8;
            fa.Icon(Style_Root.notepad_ico, Pointer, 2, line, 5);
            line += 8;
            fa.Icon(Style_Root.thread_ico, 3, Pointer, line, 5);
            line += 8;
            fa.Icon(Style_Root.file_ico, 4, Pointer, line, 5);
            line += 8;
            fa.Icon(Style_Root.file_ico, 5, Pointer, line, 5);
            line += 8;
            Widget_Clock();
        }else if (env.icon_layout == 2) {
            int col = 103;
            fa.Icon(Style_Root.terminal_ico, 1, Pointer, 66+7, col);
            col += 20;
            fa.Icon(Style_Root.notepad_ico, 2, Pointer, 66+7, col);
            col += 20;
            fa.Icon(Style_Root.thread_ico, 3, Pointer, 66+7, col);
            col += 20;
            fa.Icon(Style_Root.file_ico, 4, Pointer, 66+7, col);
            col += 20;
            fa.Icon(Style_Root.file_ico, 5, Pointer, 66+7, col);
            col += 20;
            
            Widget_Clock();

        }
    }
    
    public static void Load_Taskbar() {
        fa.TextBox(2, 150, "AZUKI OS");
        fa.TextBox(2, 8,  $"{DateTime.Now.ToString("ddd")}   {DateTime.Now.ToString("MMM  dd")}");
        fa.Widget_Battery(2,290);
    }

    public static void Widget_Clock() {

        string hour = DateTime.Now.ToString("HH");
        string minute = DateTime.Now.ToString("mm");

        string select = "";
        int line = 0;
        int col = 0;
        for (int a = 0; a <= 3; a++) {

            if (env.clock_widget == 0 ) {
                switch (a) {
                    case 0:
                        select = hour.Substring(0, 1);
                        line = 13;
                        col = 15;
                        break;
                    case 1:
                        select = hour.Substring(1);
                        line = 13;
                        col = 15 + 27;
                        break;
                    case 2:
                        select = minute.Substring(0, 1);
                        line = 13 + 18;
                        col = 15;
                        break;
                    case 3:
                        select = minute.Substring(1);
                        line = 13 + 18;
                        col = 15 + 27;
                        break;
                }
            }else if (env.clock_widget == 1) {
                switch (a) {
                    case 0:
                        select = hour.Substring(0, 1);
                        line = 13;
                        col = 240;
                        break;
                    case 1:
                        select = hour.Substring(1);
                        line = 13;
                        col = 240 + 27;
                        break;
                    case 2:
                        select = minute.Substring(0, 1);
                        line = 13 + 18;
                        col = 240;
                        break;
                    case 3:
                        select = minute.Substring(1);
                        line = 13 + 18;
                        col = 240 + 27;
                        break;
                }
            }
            if(env.clock_widget != -1) {
                switch (select) {
                    case "0":
                        fa.Graphics(Style_Root.t_0, line, col, "","");
                        break;
                    case "1":
                        fa.Graphics(Style_Root.t_1, line, col, "","");
                        break;
                    case "2":
                        fa.Graphics(Style_Root.t_2, line, col, "","");
                        break;
                    case "3":
                        fa.Graphics(Style_Root.t_3, line, col, "","");
                        break;
                    case "4":
                        fa.Graphics(Style_Root.t_4, line, col, "","");
                        break;
                    case "5":
                        fa.Graphics(Style_Root.t_5, line, col, "","");
                        break;
                    case "6":
                        fa.Graphics(Style_Root.t_6, line, col, "","");
                        break;
                    case "7":
                        fa.Graphics(Style_Root.t_7, line, col, "","");
                        break;
                    case "8":
                        fa.Graphics(Style_Root.t_8, line, col, "","");
                        break;
                    case "9":
                        fa.Graphics(Style_Root.t_9, line, col, "","");
                        break;
                }
            }
        }
    }

    public static void User_Cursor() {
        Cursor = Console.ReadKey().Key;

        if (Cursor == ConsoleKey.D) {
            Pointer++;
        }
        else if (Cursor == ConsoleKey.A) {
            Pointer--;
        }else if (Cursor == ConsoleKey.Enter) {
            switch (Pointer) {
                case 1:
                    App_Terminal.Run();
                    break;
                case 2:
                    App_Notepad.Run();
                    break;
                case 3:
                    App_Thread.Run();
                    break;
                case 4:
                    App_Music.Run();
                    break;
            }
        }
    }

}