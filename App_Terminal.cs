using System.Management;

using System;
using System.Collections;
using System.Drawing.Drawing2D;
using System.Text;
using System.Threading.Tasks;
class App_Terminal {

    // -------------------------- DECLARATION --------------------------
    static Frontend_Asset fa = new Frontend_Asset();
    static App_Terminal_Pet pet = new App_Terminal_Pet();
    public static StringBuilder cli = new StringBuilder();
    public static string command;
    static int line = 0; // this is for automatically clearing the cli before it exceed to limit height
    public static List<string> unlocked_pet = new List<string>();
        
    // -------------------------- METHOD --------------------------
    public static void Run() {
        Load();
    }

    public static void Load() {
        // -- Setting  Environment
        if (!Frontend_Setup.program_running) {
            Frontend_Setup.program_running = true;
                App_Setup.Zoom_In(5);
                App_Setup.LoadingBar_5();
    }


       
        

        
        fa.ClearCmd();    
        Wallpaper.Window_5();
        App_Setup.LoadTaskbarBox_5();
        App_Setup.LoadTaskbar_5("Terminal",69);
        
        
        // -- Program Loop
        while (true) {

            // -- New thread
            cli.Append(@"C:\Azuki\User\Mashiro\");
            int line_ = 5;
            Console.SetCursorPosition(4,2);

            // -- Display
            foreach (string line_print in cli.ToString().Split(new[] { "\r\n", "\n" }, StringSplitOptions.None)){
                    Console.SetCursorPosition(4,line_);
                    Console.Write(line_print);
                    if(env.dev == 0) {
                        Console.Write(" : " + line);
                    }
                    line_++;
            }


            
            // -- User Input
            String command = Console.ReadLine();

            // -- Add to thread
            if(line >= 30) {
                cli.Clear();
                Clear_Terminal();
                cli.Append(@"C:\Azuki\User\Mashiro\");
                line = 0;
            }

            cli.Append(command + "\n");
            line ++;
            


            // -- Commands
            if(command == "-x") {
                // CLOSE
                cli.Clear();
                line = 0;
                App_Setup.LoadingBar_5();
                App_Setup.Zoom_Out(5);
                break;
            }else if(command.Contains("-w")){
                CommandWallpaper(command);
            }else if(command.Contains("-l")){
                CommandLayout(command);
            }else if(command.Contains("-h")){
                cli.Append(Style_Root.MAGENTA_BG + Style_Root.BLACK + "  COMMANDS LIST " + Style_Root.RESET + Style_Root.MAGENTA+ "▓▒░\n" + Style_Root.RESET);
                cli.Append(Style_Root.MAGENTA + "-x  - Close\n"+ Style_Root.RESET);
                cli.Append(Style_Root.MAGENTA + "-w  : Wallpaper\n"+ Style_Root.RESET);
                cli.Append(Style_Root.MAGENTA + "-pet  : Collect and view ascii pets\n"+ Style_Root.RESET);
                cli.Append(Style_Root.MAGENTA + "-bios : Display device bios\n"+ Style_Root.RESET);
                cli.Append(Style_Root.MAGENTA +"wtf : Ask Gemini AI\n"+ Style_Root.RESET);
                cli.Append(Style_Root.MAGENTA + "cls : Clear terminal\n\n"+ Style_Root.RESET);
                line += 8;
            }else if(command.Contains("-pet")){
                CommandPet(command);
            }else if(command.Contains("-bios")){
                CommanBios();
            }else if(command.Contains("wtf ")){
                App_Setup.Ask(command).Wait();
                line +=2;
            }else if(command.Contains("cls")){
                Clear_Terminal();
            }else{
                cli.Append(Style_Root.RED + "Unrecognizable command... enter \"-h\" to see the lists of commands"+ Style_Root.RESET +"\n\n"); 
                line +=2;  
            }
        }

    }



    // --------------------------------------------------------- COMMANDS ---------------------------------------------------------
    public static void CommandLayout(string command_) {
        switch (command_) {
            case "-l":
                cli.Append(Style_Root.MAGENTA_BG + Style_Root.BLACK + "  LAYOUT COMMAND LIST " + Style_Root.RESET + Style_Root.MAGENTA+ "▓▒░\n");
                cli.Append("-l 0  : Horizontal layout\n");
                cli.Append("-l 1  : Vertical layuot\n");
                cli.Append("-l 2  : Center layuot\n");
                cli.Append("-w c0 : Hide clock widget\n");
                cli.Append("-w c1 : Show clock widget\n\n"+Style_Root.RESET);
                line += 7;
                break;
            case "-l 0":
                env.icon_layout = 0;
                env.clock_widget = 0;
                cli.Append(Style_Root.MAGENTA + "LAYOUT CHANGED!\n\n"+ Style_Root.RESET);
                line +=2;
                break;
            case "-l 1":
                env.icon_layout = 1;
                env.clock_widget = 1;
                cli.Append(Style_Root.MAGENTA + "LAYOUT CHANGED!\n\n"+ Style_Root.RESET);
                line +=2;
                break;
            case "-l 2":
                env.icon_layout = 2;
                env.clock_widget = 0;
                cli.Append(Style_Root.MAGENTA + "LAYOUT CHANGED!\n\n"+ Style_Root.RESET);
                line +=2;
                break;
            case "-l c0":
                env.clock_widget = -1;
                cli.Append(Style_Root.MAGENTA + "CLOCK WIDGET HIDE!\n\n"+ Style_Root.RESET);
                line +=2;
                break;
            case "-l c1":
                if(env.icon_layout == 2) {
                    env.clock_widget = 0;
                }
                else {
                    env.clock_widget = env.icon_layout;
                }
                cli.Append(Style_Root.MAGENTA + "CLOCK WIDGET UNHIDE!\n\n"+ Style_Root.RESET);
                line +=2;
                break;
            default:
                cli.Append(Style_Root.RED + "LAYOUT COMMAND UNRECOGNIZED\n\n"+ Style_Root.RESET);
                line +=2;
                break;
        }
    }

    public static void CommandWallpaper(string command_) {
        switch (command_) {
            case "-w":
                cli.Append(Style_Root.MAGENTA_BG + Style_Root.BLACK + "  WALLPAPER LIST " + Style_Root.RESET + Style_Root.MAGENTA+ "▓▒░\n");
                cli.Append("-w 0 : Blank\n");
                cli.Append("-w 1 : Arch\n");
                cli.Append("-w 2 : Circle\n");
                cli.Append("-w 3 : StrawHat\n");
                cli.Append("-w 4 : Starry\n");
                cli.Append("-w 5 : MHA\n");
                cli.Append("-w 6 : Luffy\n");
                cli.Append("-w 7 : Charizard\n\n" + Style_Root.RESET);
                line += 10;
                break;
            case "-w 0":
                env.wallpaper = 0;
                cli.Append(Style_Root.MAGENTA + "WALLPAPER CHANGED!\n\n"+ Style_Root.RESET);
                line +=2;
                break;
            case "-w 1":
                env.wallpaper = 1;
                cli.Append(Style_Root.MAGENTA + "WALLPAPER CHANGED!\n\n"+ Style_Root.RESET);
                line +=2;
                break;
            case "-w 2":
                env.wallpaper = 2;
                cli.Append(Style_Root.MAGENTA + "WALLPAPER CHANGED!\n\n"+ Style_Root.RESET);
                line +=2;
                break;
            case "-w 3":
                env.wallpaper = 3;
                cli.Append(Style_Root.MAGENTA + "WALLPAPER CHANGED!\n\n"+ Style_Root.RESET);
                line +=2;
                break;
            case "-w 4":
                env.wallpaper = 4;
                cli.Append(Style_Root.MAGENTA + "WALLPAPER CHANGED!\n\n"+ Style_Root.RESET);
                line +=2;
                break;
            case "-w 5":
                env.wallpaper = 5;
                cli.Append(Style_Root.MAGENTA + "WALLPAPER CHANGED!\n\n"+ Style_Root.RESET);
                line +=2;
                break;
            case "-w 6":
                env.wallpaper = 6;
                cli.Append(Style_Root.MAGENTA + "WALLPAPER CHANGED!\n\n"+ Style_Root.RESET);
                line +=2;
                break;
            case "-w 7":
                env.wallpaper = 7;
                cli.Append(Style_Root.MAGENTA + "WALLPAPER CHANGED!\n\n"+ Style_Root.RESET);
                line +=2;
                break;
            default:
                cli.Append(Style_Root.RED + "WALLPAPER UNRECOGNIZED\n\n"+ Style_Root.RESET);
                line +=2;
                break;
        }
    }

    public static void CommandPet(string command_) {
        string pet_name;
        switch (command_) {
            case "-pet raichu":
                Pet("raichu", App_Terminal_Pet.raichu);
            break;
            case "-pet teddy":
                Pet("teddy", App_Terminal_Pet.teddy);
            break;
            case "-pet rattah":
                Pet("rattah", App_Terminal_Pet.rattah);
            break;
            case "-pet vulpix":
                Pet("vulpix", App_Terminal_Pet.vulpix);
            break;
            case "-pet jgs":
                Pet("jgs", App_Terminal_Pet.jgs);
            break;
            case "-pet evee":
                Pet("evee", App_Terminal_Pet.evee);
            break;
            case "-pet sandslash":
                Pet("sandslash", App_Terminal_Pet.sandslash);
            break;
            case "-pet poliwag":
                Pet("poliwag", App_Terminal_Pet.poliwag);
            break;
            case "-pet luffy":
                Pet("luffy", App_Terminal_Pet.luffy);
            break;
            case "-pet sandshrew":
                Pet("sandshrew", App_Terminal_Pet.sandshrew);
            break;
            default: 
                cli.Append(Style_Root.RED + "no pet found"+ Style_Root.RESET +"\n\n"); 
                line +=2;  
            break;
        }
    }

    public static void Pet(string petname, string[] pet){
        bool isNew = true;
        for(int a = 0; a < unlocked_pet.Count ; a++) {
            if(unlocked_pet[a] == petname) {
                isNew = false;
                a+= 40;
            }
        }

        if (isNew) {
            unlocked_pet.Add(petname);
            cli.Append(Style_Root.MAGENTA_BG + Style_Root.BLACK + "  A NEW PET ACQUIRED! " + Style_Root.RESET + Style_Root.MAGENTA+ "▓▒░\n\n");   
            line+= 2;
        }
        else {
            cli.Append(Style_Root.MAGENTA +"Pet Acquired ("+ unlocked_pet.Count + "/40)"+Style_Root.RESET+ "\n\n");
            line+=2;    
        }
        
        foreach(var pet_line in pet) {
            cli.Append(Style_Root.MAGENTA + pet_line+ Style_Root.RESET+ "\n");
            line++;
        }
        cli.Append("\n");
        line++;
    }


    public static void CommanBios() {
        Clear_Terminal();
        line = 0;
        int line_ = 5;
        foreach (string line_print in Style_Root.azuki_illus){
            Console.SetCursorPosition(4,line_);
            Console.Write(line_print);
            line_++;
            line++;
        }

        int top = 7;
        
            fa.TextBox(top, 75, Style_Root.MAGENTA+ "mashiro@laptop --bios " + Style_Root.RESET);
            top++;
            top++;
            fa.TextBox(top, 75, "------------------------------------------");
            top++;
            top++;
            fa.TextBox(top, 75, Style_Root.MAGENTA + "OS  :  " + Style_Root.RESET + "AZUKI 0SS");
            top++;
            fa.TextBox(top, 75, Style_Root.MAGENTA + "OS Version  :  " + Style_Root.RESET + "azk_0.1");
            top++;
            fa.TextBox(top, 75, Style_Root.MAGENTA + "Prog Lang  :  " + Style_Root.RESET + "csharp");
            top++;
            top++;

        ManagementObjectSearcher cpuSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
        foreach (ManagementObject cpu in cpuSearcher.Get())
        {
            fa.TextBox(top, 75, Style_Root.MAGENTA + "CPU  : " + Style_Root.RESET + cpu["Name"]);
            top++;
            fa.TextBox(top, 75, Style_Root.MAGENTA + "CPU Cores  :  " + Style_Root.RESET + cpu["NumberOfCores"]);
            top++;
            fa.TextBox(top, 75, Style_Root.MAGENTA + "CPU Threads  :  " + Style_Root.RESET + cpu["NumberOfLogicalProcessors"]);
            top++;
            fa.TextBox(top, 75, Style_Root.MAGENTA + "CPU ID  :  " + Style_Root.RESET + cpu["ProcessorId"]);
            top++;
            top++;
        }

        ManagementObjectSearcher ramSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMemory");
        foreach (ManagementObject ram in ramSearcher.Get())
        {
            fa.TextBox(top, 75, Style_Root.MAGENTA + "RAM Capacity (GB)  :  " + Style_Root.RESET + Math.Round(Convert.ToDouble(ram["Capacity"]) / (1024*1024*1024), 2));
            top++;
            fa.TextBox(top, 75, Style_Root.MAGENTA + "RAM Speed (MHz)  :  " + Style_Root.RESET + ram["Speed"]);
            top++;
            fa.TextBox(top, 75, Style_Root.MAGENTA + "RAM Manufacturer  :  " + Style_Root.RESET + ram["Manufacturer"]);
            top++;
            top++;
        }

        ManagementObjectSearcher diskSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
        foreach (ManagementObject disk in diskSearcher.Get())
        {
            fa.TextBox(top, 75, Style_Root.MAGENTA + "Disk Model  :  " + Style_Root.RESET + disk["Model"]);
            top++;
            fa.TextBox(top, 75, Style_Root.MAGENTA + "Disk Size (GB)  :  " + Style_Root.RESET + Math.Round(Convert.ToDouble(disk["Size"]) / (1024*1024*1024), 2));
            top++;
            top++;
            top++;
            top++;
            top++;
            top++;
            top++;
            top++;
            top++;
        }


        
            fa.TextBox(top, 75, Style_Root.MAGENTA_BG +"       " + Style_Root.RESET + Style_Root.MAGENTA+ "▓▓▓▓▓▓▓▒▒▒▒▒▒▒░░░░░░░" + Style_Root.RESET);
            top++;
            fa.TextBox(top, 75, Style_Root.MAGENTA_BG +"       " + Style_Root.RESET + Style_Root.MAGENTA+ "▓▓▓▓▓▓▓▒▒▒▒▒▒▒░░░░░░░" + Style_Root.RESET);
           

    }




    public static void Clear_Terminal() {
           for (int a = 0 ; a <= 43 ; a++){
                cli.Clear();
                Console.SetCursorPosition(4,5 + a);
                Console.Write("                                                                                                                                                   ");                            
            }
            line = 0;
    }

}









