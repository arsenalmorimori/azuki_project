using System.Diagnostics;
using TextCopy;
using System.Management;
using System.Text.Json;
using System;
using System.Collections;
using System.Drawing.Drawing2D;
using System.Text;
using System.Threading.Tasks;
class App_Cs1b{
    
    // -------------------------- DECLARATION --------------------------
    static Frontend_Asset fa = new Frontend_Asset();
    public static ConsoleKeyInfo cursor;
    public static bool loop_control = true;
    public static int Pointer = -1;
    public static int p = 0;

    
        
    // -------------------------- METHOD --------------------------
    public static void Run() {
        Load();     

        InputSystem();

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
        App_Setup.LoadTaskbar_5("CS1B File",69);
        fa.Box(4,130,35,43,"");

            

    }

    public static void UI() {
        int line = 5;
        int col = 5;
        int col_add = 23;
        
        fa.FileIcon(Style_Root.battleship_ico, 0, Pointer, line, col,"    Battleship.cs    ");
        col += col_add;
        fa.FileIcon(Style_Root.beastbound_ico, 1, Pointer, line, col,"    BeastBound.cs    ");
        col += col_add;
        fa.FileIcon(Style_Root.bloomify_ico, 2, Pointer, line, col,"     Bloomify.cs     ");

      
         // -- Box Selector
        if (Pointer <= -1) {
            Clear_Box();
            fa.TextBox(24,141,"No file selected");
        }else if(Pointer == 0){
            Clear_Box();
            fa.FileIcon(Style_Root.battleship_ico, Pointer-9, 0, 9, 138,"");
            fa.TextBox(23,134,"Title : ");
            App_Setup.Hypentext(25, "Battleship.cs    ",142,23);
            fa.TextBox(25,134,"Group : ");
            App_Setup.Hypentext(25, "Georgie Bognalbal    ",142,25);
            App_Setup.Hypentext(26, "Zanne Acosta    ",142,26);
            App_Setup.Hypentext(27, "Lance Sarmiento    ",142,27);
            App_Setup.Hypentext(28, "MArtin Villapando    ",142,28);
        }else if(Pointer == 1){
            Clear_Box();
            fa.FileIcon(Style_Root.beastbound_ico, Pointer-9, 0, 9, 138,"");
            fa.TextBox(23,134,"Title : ");
            App_Setup.Hypentext(25, "BeastBound.cs    ",142,23);
            fa.TextBox(25,134,"Group : ");
            App_Setup.Hypentext(25, "Eymard Ricafort",142,25);
        }else if(Pointer == 2){
            Clear_Box();
            fa.FileIcon(Style_Root.bloomify_ico, Pointer-9, 0, 9, 138,"");
            fa.TextBox(23,134,"Title : ");
            App_Setup.Hypentext(25, "Bloomify.cs    ",142,23);
            fa.TextBox(25,134,"Group : ");
            App_Setup.Hypentext(25, "Anjilyn Ferrer",142,25);
            App_Setup.Hypentext(26, "Cyrille Del Mundo",142,26);
            App_Setup.Hypentext(27, "Marc Gian Yambao",142,27);
        }


    }

    public static void InputSystem() {

        // LOOP SYSTEM
        while (loop_control) {
            UI();
            

           // USER INPUT
            // Console.SetCursorPosition(164,49);
            cursor = Console.ReadKey(intercept: true);

            if (cursor.Key == ConsoleKey.D) {
                if(Pointer >  2){
                }else{
                    Pointer++;
                }
            }else if (cursor.Key == ConsoleKey.A) {
                if(Pointer < 0){
                }else{
                    Pointer--;
                }
            }else if (cursor.Key == ConsoleKey.Enter) {
                if (Pointer == 2) {
                    Process.Start(new ProcessStartInfo("cmd.exe", "/c start cs1b_bloomify.bat") { CreateNoWindow = false });
                } else if (Pointer == 0) {
                    Process.Start(new ProcessStartInfo("cmd.exe", "/c start cs1b_battleship.bat") { CreateNoWindow = false });
                } else if (Pointer == 1) {
                    Process.Start(new ProcessStartInfo("cmd.exe", "/c start cs1b_beastbound.bat") { CreateNoWindow = false });
                }
            }else if(cursor.Key == ConsoleKey.X) {
                    fa.ClearCmd();
                    App_Setup.LoadingBar_5();
                    App_Setup.Zoom_Out(5);
                    break;
            }

            
            
        }

    }




    public static void Clear_Box() {
        for (int a = 7 ; a <= 40; a++) {
            Console.SetCursorPosition(134, a);
            Console.Write("                                 ");
        }
    }









}









