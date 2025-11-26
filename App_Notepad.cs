using System.Management;

using System;
using System.Collections;
using System.Drawing.Drawing2D;
using System.Text;
using System.Threading.Tasks;
class App_Notepad {

    // -------------------------- DECLARATION --------------------------
    static Frontend_Asset fa = new Frontend_Asset();
    static App_Terminal_Pet pet = new App_Terminal_Pet();
    public static StringBuilder cli = new StringBuilder();
    public static string command;
    public static int Pointer = -1;
    public static ConsoleKey cursor;
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
        App_Setup.LoadTaskbar_5("Notepad",69);
        fa.Box(4,130,35,43,"");
        
        
        // -- Program Loop
        while (true) {
            // -- File placeholders
            int line = 5;
            int col = 5;
            int col_add = 23;
            fa.Icon(Style_Root.note_add_ico, 0, Pointer, line, col);
            col+= col_add;
            fa.NoteIcon(Style_Root.note_ico, 1, Pointer, line, col);
            col+= col_add;
            fa.NoteIcon(Style_Root.note_ico, 2, Pointer, line, col);
            col+= col_add;
            fa.NoteIcon(Style_Root.note_ico, 3, Pointer, line, col);
            col+= col_add;
            fa.NoteIcon(Style_Root.note_ico, 4, Pointer, line, col);
            col+= col_add;
            fa.Box(4,130,35,43,"");

            line+=13;
            col = 5;
            fa.NoteIcon(Style_Root.note_ico, 5, Pointer, line, col);
            col+= col_add;
            fa.NoteIcon(Style_Root.note_ico, 6, Pointer, line, col);
            col+= col_add;
            fa.NoteIcon(Style_Root.note_ico, 7, Pointer, line, col);
            col+= col_add;
            fa.NoteIcon(Style_Root.note_ico, 8, Pointer, line, col);
            col+= col_add;
            fa.NoteIcon(Style_Root.note_ico, 9, Pointer, line, col);
            col+= col_add;
            fa.Box(4,130,35,43,"");


            line+=13;
            col = 5;
            fa.NoteIcon(Style_Root.note_ico, 10, Pointer, line, col);
            col+= col_add;
            fa.NoteIcon(Style_Root.note_ico, 11, Pointer, line, col);
            col+= col_add;
            fa.NoteIcon(Style_Root.note_ico, 12, Pointer, line, col);
            col+= col_add;
            fa.NoteIcon(Style_Root.note_ico, 13, Pointer, line, col);
            col+= col_add;



            // -- Box Selector
            if (Pointer <=-1) {
                Clear_Box();
                fa.TextBox(24,141,"No file selected");
            }else if (Pointer ==0) {
                Clear_Box();
                fa.TextBox(24,141,"  Add new file");
            }else {
                Clear_Box();
                fa.NoteIcon(Style_Root.note_ico, Pointer, 0, 7, 138);
                fa.TextBox(23,134,"Title : Heloooooooooooooooo...");
                fa.TextBox(25,134,"Created at : 11/27/25");
            }

            

            Console.SetCursorPosition(164,49);
            cursor = Console.ReadKey().Key;
            
            if(cursor == ConsoleKey.D) {
                Pointer++;
            }else if(cursor == ConsoleKey.A) {
                Pointer--;
            }
            
        }

    }



    // ---------------------------------------------------------------------------------------------------------
    public static void Clear_Box() {
        for (int a = 7 ; a <= 26; a++) {
            Console.SetCursorPosition(134, a);
            Console.Write("                                 ");
        }
    }
}









