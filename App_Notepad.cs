using TextCopy;
using System.Management;
using System.Text.Json;
using System;
using System.Collections;
using System.Drawing.Drawing2D;
using System.Text;
using System.Threading.Tasks;
class App_Notepad {
    
    // -------------------------- DATABASE VALUES --------------------------
    public string title {get; set;}
    public string created {get; set;}
    public string content {get; set;}

    // -------------------------- DECLARATION --------------------------
    static Frontend_Asset fa = new Frontend_Asset();
    static App_Notepad_Setup ns = new App_Notepad_Setup();
    public static int Pointer = -1;
    public static ConsoleKey cursor;
    public static int box_title_end = 24;
    public static int loop_control = 255;

    /*  -- bitwise loop control

      1     1        1          1       1           1        1           1
    home   nav   add_parent   add   view_parent   view   edit_parent   edit
    128     64       32        16        8          4         2          1
 
    ^ = false
    | = true

    // public static bool home = true;
    // public static bool nav = true;
    // public static bool add_parent = true;
    // public static bool add = true;
    // public static bool view_parent = true;
    // public static bool view = true;
    // public static bool edit_parent = true;
    // public static bool edit = true;
    */
    
    // -- json database
    public static string filePath = "notepad.json";
    public static string json = File.ReadAllText(filePath);
    public static List<App_Notepad> note = JsonSerializer.Deserialize<List<App_Notepad>>(json);
    
        
    // -------------------------- METHOD --------------------------
    public static void Run() {
        Load();
    }

    public static void Load() {
        // -- Setting  Environment
        if (!Frontend_Setup.program_running) {
            fa.ClearCmd();    
            Frontend_Setup.program_running = true;
            App_Setup.Zoom_In(5);
            App_Setup.LoadingBar_5();
            loop_control = 255;
        }





        while ((loop_control & 128) == 128 ) {
            loop_control = loop_control ^ 128;
            // home = false;
            loop_control = loop_control | 64;
            // nav = true;

            fa.ClearCmd();    
            Wallpaper.Window_5();
            App_Setup.LoadTaskbarBox_5();
            App_Setup.LoadTaskbar_5("Notepad",69);
            fa.Box(4,130,35,43,"");
            
            
            // -- Program Loop
            while ((loop_control & 64) == 64) {
                // relead in every reload
                json = File.ReadAllText(filePath);
                note = JsonSerializer.Deserialize<List<App_Notepad>>(json);
                
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
                }else if(cursor == ConsoleKey.X) {
                    fa.ClearCmd();
                    App_Setup.LoadingBar_5();
                    App_Setup.Zoom_Out(5);
                    break;
                }else if(cursor == ConsoleKey.Enter) {
                    loop_control = loop_control | 8;
                    // view_parent = true;
                    loop_control = loop_control | 4;
                    // view = true;
                    if (Pointer > 0) {
                        View();                        
                    }else if (Pointer == 0) {
                        Add();                        
                    }
                }else if(cursor == ConsoleKey.R) {
                    loop_control = loop_control | 128;
                    // home = true;
                    loop_control = loop_control ^ 64;
                    // nav = false;
                }
            }

        }

    }














// ----------------------------------------------- BACKEND -----------------------------------------------

    public static void View(){
        while ((loop_control & 8) == 8) {
            loop_control = loop_control ^ 8;
            // view_parent = false;
            loop_control = loop_control | 4;
            // view = true;

            fa.ClearCmd();
            App_Setup.Zoom_In(4);   
        
            while ((loop_control & 4) == 4) {
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
                    // loop_control = loop_control ^ 8;
                    // view_parent = false;
                    loop_control = loop_control ^ 4;
                    // view = false;
                    loop_control = loop_control | 128;
                    // home = true;
                    loop_control = loop_control ^ 64;
                    // nav = false;
                }else if (cursor == ConsoleKey.E) {
                    loop_control = loop_control | 2;
                    // edit_parent = true;
                    loop_control = loop_control | 1;
                    // edit = true;
                    Edit();
                }else if (cursor == ConsoleKey.D) {
                    Delete();
                    Pointer = 0;
                    fa.ClearCmd();
                    App_Setup.Zoom_Out(4);
                    // loop_control = loop_control ^ 8;
                    // view_parent = false;
                    loop_control = loop_control ^ 4;
                    // view = false;
                    loop_control = loop_control | 128;
                    // home = true;
                    loop_control = loop_control ^ 64;
                    // nav = false;
                }
            }   
        }

    }




    public static void Edit(){
        while ((loop_control & 2) == 2) {
            loop_control = loop_control ^ 2;
            // edit_parent = false;
            loop_control = loop_control | 1;
            // edit = true;

            while ((loop_control & 1) == 1) {
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
                    loop_control = loop_control | 4;
                    // view = true;
                    loop_control = loop_control ^ 1;
                    // edit = false;
                }else if (cursor == ConsoleKey.A) {
                    Edit_Window(0);
                    loop_control = loop_control | 4;
                    // view = true;
                    loop_control = loop_control ^ 1;
                    // edit = false;
                }else if (cursor == ConsoleKey.S) {
                    Edit_Window(1);
                    loop_control = loop_control | 4;
                    // view = true;
                    loop_control = loop_control ^ 1;
                    // edit = false;
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
        if (what == 0) {
            Console.Write("          ");
            Console.WriteLine(Style_Root.YELLOW + "// hit \"Ctrl + V\" and watch your title appear like magic" + Style_Root.RESET);
            Console.Write("          ");
            Console.WriteLine(Style_Root.YELLOW + "// Please make it short as possible (〃▽〃) " + Style_Root.RESET);
        }else {
            Console.Write("          ");
            Console.WriteLine(Style_Root.YELLOW + "// hit \"Ctrl + V\" and watch your text appear like magic" + Style_Root.RESET);
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





    public static void Add(){
            fa.ClearCmd();
            App_Setup.Zoom_In(4); 

            fa.TextBox(3, 10, Style_Root.MAGENTA + "Title"+ Style_Root.RESET);
            fa.Box(4, 10, 100,1, Style_Root.MAGENTA.ToString());
            fa.TextBox(7, 10, Style_Root.MAGENTA + "// Please make it short as possible (〃▽〃) "+ Style_Root.RESET);
            fa.TextBox(11, 10, Style_Root.RESET + "Note Content"+ Style_Root.RESET);
            fa.Box(12, 10, 100,19, Style_Root.RESET.ToString());
            
            
            Console.SetCursorPosition(12,5);
            String title_input = Console.ReadLine();

            
            fa.Box(4, 10, 100,1, "");
            fa.TextBox(3, 10, Style_Root.RESET + "Title"+ Style_Root.RESET);
            fa.TextBox(5, 12, Style_Root.RESET + title_input+ Style_Root.RESET);
            fa.TextBox(7, 10, Style_Root.RESET + "// Please make it short as possible (〃▽〃) "+ Style_Root.RESET);
            fa.TextBox(11, 10, Style_Root.MAGENTA + "Note Content"+ Style_Root.RESET);
            fa.Box(12, 10, 100,19, Style_Root.MAGENTA.ToString());
            fa.TextBox(33, 10, Style_Root.MAGENTA + "// Word cuts may appear here, but it's fixed in view!  //•/ω/•// "+ Style_Root.RESET);

            // Console.SetCursorPosition(12,12);
            // String note_input = Console.ReadLine();

            string sentence = ""; 
            string sentence_line = ""; 
            bool isTyping = true; 
            int line = 13;
            int col = 0;
            bool backspace = false;
            while (isTyping) {
                Console.SetCursorPosition(12,line);
                ConsoleKeyInfo typing = Console.ReadKey(intercept: true);
                if (typing.Key == ConsoleKey.Enter) {
                    isTyping = false;
                    if (sentence_line.Length != 0) {
                        sentence = sentence + sentence_line;
                    }
                }else if(typing.Key == ConsoleKey.Backspace){
                    if (col > 0) {
                        sentence_line = sentence_line.Substring(0,col-1);
                        col --;
                    }
                }else {
                    sentence_line = sentence_line + typing.KeyChar;
                    col ++;
                }
                if (col > 99) {
                    line ++;
                    col = 0;
                    sentence = sentence + sentence_line;
                    sentence_line = "";
                    Console.SetCursorPosition(12,line);
                    sentence_line = typing.KeyChar.ToString();
                }
                Console.Write(sentence_line);
            }

            DateTime date = DateTime.Now;

            App_Notepad add_note = new App_Notepad{
                title = title_input,
                created = date.ToString("MM/dd/yy"),
                content = sentence
            };

            note.Add(add_note);

            string add = JsonSerializer.Serialize(note, new JsonSerializerOptions {
                WriteIndented = true
            });

            File.WriteAllText(filePath, add);
            json = File.ReadAllText(filePath);

            fa.ClearCmd();
            fa.TextBox(17, 53, Style_Root.MAGENTA + "Successfully Added!"+ Style_Root.RESET);
            Thread.Sleep(1000);
            fa.ClearCmd();
            Thread.Sleep(100);
            App_Setup.Zoom_Out(4); 
            loop_control = loop_control | 128;  
            // home = true;
            loop_control = loop_control ^ 64;
            // nav = false;
            
        

    }






    public static void Delete(){
            
            note.Remove(note[Pointer-1]);

            string remove = JsonSerializer.Serialize(note, new JsonSerializerOptions {
                WriteIndented = true
            });

            File.WriteAllText(filePath, remove);
            json = File.ReadAllText(filePath);

            fa.ClearCmd();
            fa.TextBox(17, 52, Style_Root.RED + "Deleted Successfully!"+ Style_Root.RESET);
            Thread.Sleep(1000);
    }





// ----------------------------------------------- FRONTEND -----------------------------------------------
    public static void Clear_Box() {
        for (int a = 7 ; a <= 40; a++) {
            Console.SetCursorPosition(134, a);
            Console.Write("                                 ");
        }
    }
}









