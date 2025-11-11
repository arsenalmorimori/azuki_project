
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
        fa.TextBox( 2, 140,  Style_Root.BLUE + "  _  _     |  o     _  _ " + Style_Root.RESET);
        fa.TextBox(3, 140, Style_Root.BLUE + " (_| /_|_| |< |    (_) > " + Style_Root.RESET);

        fa.Icon(Style_Root.file_icoH, Style_Root.file_icoUH, 1, 60, 10);
        fa.Icon(Style_Root.file_icoH, Style_Root.file_icoUH, 2, 60, 29);
        fa.Icon(Style_Root.file_icoH, Style_Root.file_icoUH, 3, 60, 48);
        fa.Icon(Style_Root.file_icoH, Style_Root.file_icoUH, 4, 60, 67);

        fa.Icon(Style_Root.file_icoH, Style_Root.file_icoUH, 5, 67, 10);
        fa.Icon(Style_Root.file_icoH, Style_Root.file_icoUH, 6, 67, 29);
        fa.Icon(Style_Root.file_icoH, Style_Root.file_icoUH, 7, 67, 48);
        fa.Icon(Style_Root.file_icoH, Style_Root.file_icoUH, 8, 67, 67);
        fa.Icon(Style_Root.file_icoH, Style_Root.file_icoUH, 9, 67, 86);
    }

    public static void User_Cursor() {
        Console.SetCursorPosition(0, 0);
        Cursor = Console.ReadKey().Key;
        
        if(Cursor == ConsoleKey.D) {
            Pointer++;
        }else if(Cursor == ConsoleKey.A) {
            Pointer--;
        }
    }
}