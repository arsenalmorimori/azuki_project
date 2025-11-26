using TextCopy;
using System.Management;
using System.Text.Json;
using System;
using System.Collections;
using System.Drawing.Drawing2D;
using System.Text;
using System.Threading.Tasks;
class App_Notepad {

    // -------------------------- DECLARATION --------------------------
    static Frontend_Asset fa = new Frontend_Asset();
    static App_Notepad_Setup ns = new App_Notepad_Setup();
    public static int Pointer = -1;
    public static ConsoleKey cursor;
    public static int box_title_end = 24;
    public static bool home = true;
    public static bool nav = true;
    public static bool view_parent = true;
    public static bool view = true;
    public static bool edit_parent = true;
    public static bool edit = true;
    // -- json database
    public static string filePath = "notepad.json";
    public static string json = File.ReadAllText(filePath);
    public static List<json_db> note = JsonSerializer.Deserialize<List<json_db>>(json);
    
        
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





        while (home) {
            home = false;
            nav = true;
            fa.ClearCmd();    
            Wallpaper.Window_5();
            App_Setup.LoadTaskbarBox_5();
            App_Setup.LoadTaskbar_5("Notepad",69);
            fa.Box(4,130,35,43,"");
            
            
            // -- Program Loop
            while (nav) {
                // relead in every reload
                json = File.ReadAllText(filePath);
                note = JsonSerializer.Deserialize<List<json_db>>(json);
                
                int line = 5;
                int col = 5;
                int col_add = 23;
                
                for(int a = 0; a < note.Count + 1 ; a++) {
                    if (a == 0) {
                        fa.Icon(Style_Root.note_add_ico, 0, Pointer, line, col);
                        col+= col_add;
                    }else {
                        fa.NoteIcon(Style_Root.note_ico, a, Pointer, line, col);
                        col+= col_add;
                    }

                    if (a == 4 || a == 9 ) {
                        line+=13;
                        col = 5;
                    }
                }

                // -- Box Selector
                if (Pointer <=-1) {
                    Clear_Box();
                    fa.TextBox(24,141,"No file selected");
                }else if (Pointer ==0) {
                    Clear_Box();
                    fa.TextBox(24,141,"  Add new file");
                }else {
                    Clear_Box();
                    box_title_end = 24;
                    fa.NoteIcon(Style_Root.note_ico, Pointer, 0, 7, 138);
                    fa.TextBox(23,134,"Title : ");
                    App_Notepad_Setup.Hypentext(25, note[Pointer-1].title,142,23);
                    fa.TextBox(box_title_end,134,"Created at : " + note[Pointer-1].created);
                }

                Console.SetCursorPosition(164,49);
                cursor = Console.ReadKey().Key;

                if(cursor == ConsoleKey.D) {
                    if(Pointer < note.Count) {
                        Pointer++;                    
                    }
                }else if(cursor == ConsoleKey.A) {
                    if(Pointer > -1) {
                        Pointer--;                    
                    }
                }else if(cursor == ConsoleKey.Enter) {
                    view_parent = true;
                    view = true;
                    if (Pointer > 0) {
                        View();                        
                    }
                }else if(cursor == ConsoleKey.R) {
                    home = true;
                    nav = false;
                }
            }

        }

    }


    public static void View(){
        while (view_parent) {
            view_parent = false;
            view = true;
            fa.ClearCmd();
            App_Setup.Zoom_In(4);   
        
            while (view) {
                fa.ClearCmd();
                Wallpaper.Window_9(); 
                Thread.Sleep(50);
                fa.TextBox(2, 108, Style_Root.MAGENTA + "[x]"+Style_Root.RED +" [d]"+Style_Root.YELLOW +" [e]" + Style_Root.RESET);
                fa.TextBox(5, 10, note[Pointer-1].title);
                fa.TextBox(6, 10, note[Pointer-1].created);
                Thread.Sleep(50);
                App_Notepad_Setup.Hypentext(100, note[Pointer-1].content, 10, 10);
            
                Console.SetCursorPosition(124,35);
                cursor = Console.ReadKey().Key;
                
                if(cursor == ConsoleKey.X) {
                    fa.ClearCmd();
                    App_Setup.Zoom_Out(4);
                    view_parent = false;
                    view = false;
                    home = true;
                    nav = false;
                }else if (cursor == ConsoleKey.E) {
                    edit_parent = true;
                    edit = true;
                    Edit();
                }
            }   
        }

    }

    public static void Edit(){
        while (edit_parent) {
            edit_parent = false;
            edit = true;

            while (edit) {
                fa.ClearCmd();
                Wallpaper.Window_9();
                Thread.Sleep(50);
                fa.TextBox(2, 100, Style_Root.YELLOW + "[a] Edit Title" + Style_Root.RESET);
                fa.TextBox(3, 100, Style_Root.YELLOW + "[s] Edit Note" + Style_Root.RESET);
                fa.TextBox(4, 100, Style_Root.YELLOW + "[x] Back" + Style_Root.RESET);
                
                fa.TextBox(5, 10, Style_Root.YELLOW + "Title" + Style_Root.RESET);
                fa.TextBox(6, 10, note[Pointer-1].title);
                
                
                fa.TextBox(10, 10, Style_Root.YELLOW + "Note" + Style_Root.RESET);
                Thread.Sleep(50);
                App_Notepad_Setup.Hypentext(100, note[Pointer-1].content, 10, 11);
            
                Console.SetCursorPosition(124,35);
                cursor = Console.ReadKey().Key;
                
                if(cursor == ConsoleKey.X) {
                    view = true;
                    edit = false;
                }else if (cursor == ConsoleKey.A) {
                    Edit_Window(0);
                    view = true;
                    edit = false;
                }else if (cursor == ConsoleKey.S) {
                    Edit_Window(1);
                    view = true;
                    edit = false;
                }
            }
        }

    }

    public static void Edit_Window(int what) {
        fa.ClearCmd();
        if (what == 0) {
            ClipboardService.SetText(note[Pointer-1].title.ToString());
        }else {
            ClipboardService.SetText(note[Pointer-1].content.ToString());
        }

        Console.WriteLine();
        Console.WriteLine("     ");
        Console.WriteLine("     ");
        Console.Write("          ");
        Console.WriteLine(Style_Root.YELLOW + "// hit \"Ctrl + V\" and watch your text appear like magic" + Style_Root.RESET);
        if (what == 0) {
            Console.Write("          ");
            Console.WriteLine(Style_Root.YELLOW + "// Please make it short as possible (〃▽〃) " + Style_Root.RESET);
        }else {
            Console.Write("          ");
            Console.WriteLine(Style_Root.YELLOW + "// Word cuts may appear here, but don't worry, it's fixed in view!  //•/ω/•// " + Style_Root.RESET);
        }

        Console.WriteLine();
        Console.Write("          ");
        string new_text = Console.ReadLine();

        if (what == 0) {
            note[Pointer-1].title = new_text;
        }else {
            note[Pointer-1].content = new_text;
        }

        string update = JsonSerializer.Serialize(note, new JsonSerializerOptions {
            WriteIndented = true
        });

        
        File.WriteAllText(filePath, update);
        json = File.ReadAllText(filePath);

    }


    // ---------------------------------------------------------------------------------------------------------
    public static void Clear_Box() {
        for (int a = 7 ; a <= 40; a++) {
            Console.SetCursorPosition(134, a);
            Console.Write("                                 ");
        }
    }
}









