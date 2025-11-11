
using System;
public class Frontend_Setup {
    
    // -------------- VARIABLES --------------
    public static int Pointer = 0;
    public static ConsoleKey Cursor;
    static Frontend_Asset fa = new Frontend_Asset();
    static Style_Root style = new Style_Root();

    // -------------- MAIN METHOD --------------
    public static void Run() {
        Load();
    }

    // -------------- METHODS --------------
    public static void Load() {
        fa.MHA_Wallpaper();
        while (true) {
            Load_Gui();    
            User_Cursor();
        }
    }

    public static void Load_Gui() {
        // ICONS
        fa.Icon(Style_Root.file_icoH, Style_Root.file_icoUH, 1, 60, 10 + 5);
        fa.Icon(Style_Root.file_icoH, Style_Root.file_icoUH, 2, 60, 29 + 5);
        fa.Icon(Style_Root.file_icoH, Style_Root.file_icoUH, 3, 60, 48 + 5);
        fa.Icon(Style_Root.file_icoH, Style_Root.file_icoUH, 4, 60, 67 + 5);
        fa.Icon(Style_Root.file_icoH, Style_Root.file_icoUH, 5, 67, 10 + 5);
        fa.Icon(Style_Root.file_icoH, Style_Root.file_icoUH, 6, 67, 29 + 5);
        fa.Icon(Style_Root.file_icoH, Style_Root.file_icoUH, 7, 67, 48 + 5);
        fa.Icon(Style_Root.file_icoH, Style_Root.file_icoUH, 8, 67, 67 + 5);
        fa.Icon(Style_Root.file_icoH, Style_Root.file_icoUH, 9, 67, 86 + 5);

        Widget_Clock();


    }
    

    public static void Widget_Clock() {
        
        string hour= DateTime.Now.ToString("HH");
        string minute = DateTime.Now.ToString("mm");
        
        string select = "";
        int line = 0;
        int col = 0;
        for (int a = 0; a <= 3; a++) {
            
            switch (a) {
                case 0:
                    select = hour.Substring(0,1);
                    line = 13;
                    col = 15;
                    break;
                case 1:
                    select = hour.Substring(1);
                    line = 13;
                    col = 15 + 27;
                    break;
                case 2:
                    select = minute.Substring(0,1);
                    line = 13 + 18;
                    col = 15;
                    break;
                case 3:
                    select = minute.Substring(1);
                    line = 13 + 18;
                    col = 15 + 27;
                    break;
            }
            switch (select) {
                case "0":
                    fa.Graphics(Style_Root.t_0, line, col);
                    break;
                case "1":
                    fa.Graphics(Style_Root.t_1, line, col);
                    break;
                case "2":
                    fa.Graphics(Style_Root.t_2, line, col);
                    break;
                case "3":
                    fa.Graphics(Style_Root.t_3, line, col);
                    break;
                case "4":
                    fa.Graphics(Style_Root.t_4, line, col);
                    break;
                case "5":
                    fa.Graphics(Style_Root.t_5, line, col);
                    break;
                case "6":
                    fa.Graphics(Style_Root.t_6, line, col);
                    break;
                case "7":
                    fa.Graphics(Style_Root.t_7, line, col);
                    break;
                case "8":
                    fa.Graphics(Style_Root.t_8, line, col);
                    break;
                case "9":
                    fa.Graphics(Style_Root.t_9, line, col);
                    break;
                }     
        }
    }


    public static void User_Cursor() {
        Console.SetCursorPosition(0, 0);
        Cursor = Console.ReadKey().Key;

        if (Cursor == ConsoleKey.D) {
            Pointer++;
        }
        else if (Cursor == ConsoleKey.A) {
            Pointer--;
        }
    }
    
    public static void console_log(int line, string text) {
        Console.SetCursorPosition(0, line);
        Console.WriteLine(text);
    }

}