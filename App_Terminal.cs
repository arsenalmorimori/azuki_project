using System;
using System.Text;
using WindowsInput;
using WindowsInput.Native;

class App_Terminal {
    static Frontend_Asset fa = new Frontend_Asset();
    public static void Run() {
        Load();
    }

    static string command;
    
    public static void Load() {
        Frontend_Setup.program_running = true;
        fa.ClearCmd();
        App_Setup.Zoom_In(5);   
        Wallpaper.Window_5();
        // StringBuilder cli = new StringBuilder();
        // cli.Append(@"C:\Azuki\User\Mashiro\");

        while (true) {
            
            String command = Console.ReadLine();


            if(command == "-x") {
                fa.ClearCmd();
                App_Setup.Zoom_Out(5);
                break;
            }
        }

    }
}








            // fa.TextBox(6, 299, Style_Root.MAGENTA_BG + Style_Root.BLACK +  @"         " + Style_Root.RESET);
            // fa.TextBox(7, 299, Style_Root.MAGENTA_BG + Style_Root.BLACK +  @"  \‾\‾/  " + Style_Root.RESET);
            // fa.TextBox(8, 299, Style_Root.MAGENTA_BG + Style_Root.BLACK +  @"  /_\_\  " + Style_Root.RESET);
            // fa.TextBox(9, 299, Style_Root.MAGENTA_BG + Style_Root.BLACK +  @"         " + Style_Root.RESET)