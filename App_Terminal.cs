using System;
using System.Drawing.Drawing2D;
using System.Text;
using System.Threading.Tasks;
class App_Terminal {

    // -------------------------- DECLARATION --------------------------
    static Frontend_Asset fa = new Frontend_Asset();
    public static StringBuilder cli = new StringBuilder();
    static string command;
        
    // -------------------------- METHOD --------------------------
    public static void Run() {
        Load();
    }

    public static async Task Load() {
        // -- Setting  Environment
        if (!Frontend_Setup.program_running) {
            Frontend_Setup.program_running = true;
            fa.ClearCmd();

            if((env.dev & 1) == 1) {
            }else {
                App_Setup.Zoom_In(5);
                // -- Loading 
                App_Setup.OpeningAppScreen("LOADING","STARTING SOFTWARE","PREPARING ENVIRONMENT","PROCESSING DISPLAY");
            }

        }
       
        

        
        fa.ClearCmd();    
        Wallpaper.Window_5();
        App_Setup.LoadTaskbarBox_5();
        App_Setup.LoadTaskbar_5("Terminal",69);
        App_Setup.AppWindow_5();
        
        
        // -- Program Loop
        // while (true) {

            // // -- New thread
            // cli.Append(@"C:\Azuki\User\Mashiro\");
            // int line = 2;
            // Console.SetCursorPosition(4,2);

            // // -- Display
            // foreach (string line_print in cli.ToString().Split(new[] { "\r\n", "\n" }, StringSplitOptions.None)){
            //     if(line >= 40) {
            //         cli.Clear();
            //         Load();
            //     }else {
            //         Console.SetCursorPosition(4,line);
            //         Console.Write(line_print);
            //         line++;
            //     }
            // }

            
            // // -- User Input
            // String command = Console.ReadLine();
            // Thread.Sleep(500);

            
            // // -- Add to thread
            // cli.Append(command + "\n\n");


            // // -- Commands
            // if(command == "-x") {
            //     // CLOSE
            //     fa.ClearCmd();
            //     cli.Clear();
            //     App_Setup.Zoom_Out(5);
            //     App_Setup.ClosingAppScreen("LOADING","RESETTING CONSOLE","CLEARING DATA","ENDING TASK","PROCESSING DISPLAY","SETTING UP ENVIRONMENT");
            //     break;

            // }else if(command.Substring(0,2) == "-w"){
            //     // WALLPAPER
            //     CommandWallpaper(command);
            // }else {
            //     cli.Append("\n"+ Style_Root.RED + "Unrecognizable command... enter \"-h\" to see the lists of commands"+ Style_Root.RESET +"\n");   
            // }
        // }

        // }
    }



    // --------------------------------------------------------- COMMANDS ---------------------------------------------------------
    public static void CommandWallpaper(string command) {
        switch (command) {
            case "-w":
                cli.Append(Style_Root.MAGENTA + "WALLPAPER LIST\n");
                cli.Append("-w 0 : Blank\n");
                cli.Append("-w 1 : Arch\n");
                cli.Append("-w 2 : Circle\n");
                cli.Append("-w 3 : StrawHat\n");
                cli.Append("-w 4 : Starry\n");
                cli.Append("-w 5 : MHA\n");
                cli.Append("-w 6 : Luffy\n");
                cli.Append("-w 7 : Charizard\n\n" + Style_Root.RESET);
                break;
            case "-w 0":
                env.wallpaper = 0;
                cli.Append(Style_Root.GREEN + "WALLPAPER CHANGED!\n\n"+ Style_Root.RESET);
                break;
            case "-w 1":
                env.wallpaper = 1;
                cli.Append(Style_Root.GREEN + "WALLPAPER CHANGED!\n\n"+ Style_Root.RESET);
                break;
            case "-w 2":
                env.wallpaper = 2;
                cli.Append(Style_Root.GREEN + "WALLPAPER CHANGED!\n\n"+ Style_Root.RESET);
                break;
            case "-w 3":
                env.wallpaper = 3;
                cli.Append(Style_Root.GREEN + "WALLPAPER CHANGED!\n\n"+ Style_Root.RESET);
                break;
            case "-w 4":
                env.wallpaper = 4;
                cli.Append(Style_Root.GREEN + "WALLPAPER CHANGED!\n\n"+ Style_Root.RESET);
                break;
            case "-w 5":
                env.wallpaper = 5;
                cli.Append(Style_Root.GREEN + "WALLPAPER CHANGED!\n\n"+ Style_Root.RESET);
                break;
            case "-w 6":
                env.wallpaper = 6;
                cli.Append(Style_Root.GREEN + "WALLPAPER CHANGED!\n\n"+ Style_Root.RESET);
                break;
            case "-w 7":
                env.wallpaper = 7;
                cli.Append(Style_Root.GREEN + "WALLPAPER CHANGED!\n\n"+ Style_Root.RESET);
                break;
            default:
                cli.Append(Style_Root.RED + "WALLPAPER UNRECOGNIZED\n\n"+ Style_Root.RESET);
                break;
        }
    }


    public static void CommandBios(string command) {
        cli.Clear();
    }



}







