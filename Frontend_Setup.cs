
using System;

using System.Management;
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
        Console.Clear();
        Console.Write(Style_Root.RESET);
        fa.Screen();
        fa.Box(1, 3, 304, 3);
        while (true) {
            Load_Gui();
            User_Cursor();
        }
    }

    public static void Load_Gui() {
        // ICONS
        int col = 10;
        fa.Icon(Style_Root.terminal_ico, 1, 60, col);
        col += 21;
        fa.Icon(Style_Root.file_ico, 2, 60, col);
        col += 21;
        fa.Icon(Style_Root.file_ico, 3, 60, col);
        col += 21;
        fa.Icon(Style_Root.file_ico, 4, 60, col);
        col += 21;
        
        col = 10;
        fa.Icon(Style_Root.file_ico, 5, 67, col);
        col += 21;
        fa.Icon(Style_Root.file_ico, 6, 67, col);
        col += 21;
        fa.Icon(Style_Root.file_ico, 7, 67, col);
        col += 21;
        fa.Icon(Style_Root.file_ico, 8, 67, col);
        col += 21;
        fa.Icon(Style_Root.file_ico, 9, 67, col);
        col += 21;
        // fa.Icon(Style_Root.file_ico, 2, 60, 29);
        // fa.Icon(Style_Root.file_ico, 3, 60, 48);
        // fa.Icon(Style_Root.file_ico, 4, 60, 67);
        // fa.Icon(Style_Root.file_ico, 5, 67, 10);
        // fa.Icon(Style_Root.file_ico, 6, 67, 29);
        // fa.Icon(Style_Root.file_ico, 7, 67, 48);
        // fa.Icon(Style_Root.file_ico, 8, 67, 67);
        // fa.Icon(Style_Root.file_ico, 9, 67, 86);

        Widget_Clock();

        fa.TextBox(3, 150, Style_Root.WHITE_BG + Style_Root.BLACK + "AZUKI OS" + Style_Root.RESET);
        fa.TextBox(3, 8, Style_Root.WHITE_BG + Style_Root.BLACK + "SUN   NOV 11" + Style_Root.RESET);
        Widget_Battery();

        

    }


    public static void Widget_Clock() {

        string hour = DateTime.Now.ToString("HH");
        string minute = DateTime.Now.ToString("mm");

        string select = "";
        int line = 0;
        int col = 0;
        for (int a = 0; a <= 3; a++) {

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

    public static void Widget_Battery() {
        var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Battery");
        short battery_ = 0;
        string battery_ico = "";
        foreach (ManagementObject battery in searcher.Get()) {
            battery_ =  Convert.ToSByte(battery["EstimatedChargeRemaining"]);
        }
        if (battery_ >= 98) {
            battery_ico = "[██████████]";
        }
        else if (battery_ >= 90) {
            battery_ico = "[█████████░]";
        }
        else if (battery_ >= 80) {
            battery_ico = "[████████░░]";
        }
        else if (battery_ >= 70) {
            battery_ico = "[███████░░░]";
        }
        else if (battery_ >= 60) {
            battery_ico = "[██████░░░░]";
        }
        else if (battery_ >= 50) {
            battery_ico = "[█████░░░░░]";
        }
        else if (battery_ >= 40) {
            battery_ico = "[████░░░░░░]";
        }
        else if (battery_ >= 30) {
            battery_ico = "[███░░░░░░░]";
        }
        else if (battery_ >= 20) {
            battery_ico = "[██░░░░░░░░]";
        }
        else if (battery_ >= 10) {
            battery_ico = "[█░░░░░░░░░]";
        }
        fa.TextBox(3, 290, Style_Root.WHITE_BG + Style_Root.BLACK + battery_ico + Style_Root.RESET);
        
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