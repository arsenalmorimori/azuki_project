using System;
using System.Drawing.Drawing2D;
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
        
        
        Console.WriteLine(Style_Root.MAGENTA + "LOADING..." + Style_Root.RESET);
        Thread.Sleep(900);
        Console.WriteLine(Style_Root.MAGENTA + "PREPARING SOFTWARE..." + Style_Root.RESET);
        Thread.Sleep(1000);
        Console.WriteLine(Style_Root.MAGENTA + "DISPLAY PROECSSING..." + Style_Root.RESET);
        Thread.Sleep(1000);
        
        fa.ClearCmd();   
        Wallpaper.Window_5();

        StringBuilder cli = new StringBuilder();
        fa.TextBox(0,3,"Terminal");
        fa.TextBox(0,164, Style_Root.MAGENTA +" X " + Style_Root.RESET  );
        
        while (true) {
            cli.Append(@"C:\Azuki\User\Mashiro\");
            int line = 2;
            Console.SetCursorPosition(4,line);
            foreach (string line_print in cli.ToString().Split(new[] { "\r\n", "\n" }, StringSplitOptions.None)){
                Console.SetCursorPosition(4,line);
                Console.Write(line_print);
                line++;
            }
            String command = Console.ReadLine();
            cli.Append(command + "\n");


            if(command == "-x") {
                fa.ClearCmd();
                App_Setup.Zoom_Out(5);
                Console.WriteLine(Style_Root.MAGENTA + "LOADINIG..." + Style_Root.RESET);
                Thread.Sleep(900);
                Console.WriteLine(Style_Root.MAGENTA + "ENDING TASK..." + Style_Root.RESET);
                Thread.Sleep(1000);
                Console.WriteLine(Style_Root.MAGENTA + "DISPLAY PROECSSING..." + Style_Root.RESET);
                Thread.Sleep(1000);
                break;
            }
        }

    }
}







