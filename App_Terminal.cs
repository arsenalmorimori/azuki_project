using System;
class App_Terminal {
    static Frontend_Asset fa = new Frontend_Asset();
    public static void Run() {
        Load();
    }
    static string command;
    public static void Load() {

        fa.Box(5, 3, 304, 72, Style_Root.BLACK_BG);
        fa.TextBox(6, 5, "Terminal");
        fa.TextBox(6, 299, Style_Root.MAGENTA_BG + Style_Root.BLACK +  @"         " + Style_Root.RESET);
        fa.TextBox(7, 299, Style_Root.MAGENTA_BG + Style_Root.BLACK +  @"  \‾\‾/  " + Style_Root.RESET);
        fa.TextBox(8, 299, Style_Root.MAGENTA_BG + Style_Root.BLACK +  @"  /_\_\  " + Style_Root.RESET);
        fa.TextBox(9, 299, Style_Root.MAGENTA_BG + Style_Root.BLACK +  @"         " + Style_Root.RESET);

        fa.TextBox(12, 10, @"C:\Azuki\User\Mashiro\");
        command = Console.ReadLine();

        // fa.Graphics(Style_Root.azuki_illus, 10, 50,Style_Root.MAGENTA,"");
        // fa.Graphics(Style_Root.Terminal_Hello, 10, 130,Style_Root.MAGENTA,"");

    }
}