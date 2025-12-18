using System;
using System.Management;
using System.Text;

public class Frontend_Asset {

    /*
        DESCRIPTION :
            - Class is the collection of Methods for Assets / Elements Making
            - The frontend in this system is inspired to Android Studio and MAUI utilizing the parameter (width, height, x, y)
            - The elemet placements logic utilize the SetCursorPosition(), inspired to CSS Position Absolute (left, top)    
    */
    
    // Asset from Spectre Console Library
    // ╭─Status────────────╮
    // │ System Booting... │
    // ╰───────────────────╯
    
    // ---------------   Assets   ---------------
    public void Icon(string[] icon, int selector, int pointer, int line, int col) {
        
        if(pointer == selector) {
            Console.Write(Style_Root.BLACK+Style_Root.WHITE_BG);
            foreach (var printline in icon) {
                Console.SetCursorPosition(col, line);
                Console.Write(printline);
                line++;
            }
            Console.Write(Style_Root.RESET);
        }
        else {
            foreach (var printline in icon) {
                Console.SetCursorPosition(col, line);
                Console.Write(printline);
                line++;
            }
        }
    }
    
    public void NoteIcon(string[] icon, int selector, int pointer, int line, int col) {

        if(pointer == selector) {
            Console.Write(Style_Root.BLACK+Style_Root.WHITE_BG);
            for (int a = 0 ; a < icon.Length; a++) {
                Console.SetCursorPosition(col, line);
                Console.Write(icon[a]);
                if(a == 10) {
                Console.Write(@"     note_"+ (selector < 10 ? "0"+selector : selector.ToString()) +@".txt     ");   
                }
                line++;
            }
            Console.Write(Style_Root.RESET);
        }
        else {
            for (int a = 0 ; a < icon.Length; a++) {
                Console.SetCursorPosition(col, line);
                Console.Write(icon[a]);
                if(a == 10) {
                Console.Write(@"     note_"+ (selector < 10 ? "0"+selector : selector.ToString()) +@".txt     ");    
                }
                line++;
            }
        }
    }
    
    public void FileIcon(string[] icon, int selector, int pointer, int line, int col, string title) {

        if(pointer == selector) {
            Console.Write(Style_Root.BLACK+Style_Root.WHITE_BG);
            for (int a = 0 ; a < icon.Length; a++) {
                Console.SetCursorPosition(col, line);
                Console.Write(icon[a]);
                if(a == 10) {
                    Console.Write(title);     
                }
                line++;
            }
            Console.Write(Style_Root.RESET);
        }
        else {
            for (int a = 0 ; a < icon.Length; a++) {
                Console.SetCursorPosition(col, line);
                Console.Write(icon[a]);
                if(a == 10) {
                Console.Write(title);    
                }
                line++;
            }
        }
    }
    
    public void Graphics(string[] graphics, int line, int col, string color, string background) {
        
        foreach (var printline in graphics) {
            Console.SetCursorPosition(col, line);
            Console.Write(color + background + printline + Style_Root.RESET);
            line++;
        }
        
    }
    public void Animation(string[] graphics, int line, int col, int fps,string color, string background) {
        
        foreach (var printline in graphics) {
            Console.SetCursorPosition(col, line);
            Console.Write(color + background + printline + Style_Root.RESET);
            line++;
            Thread.Sleep(fps);
        }
        
    }

    public void TextBox(int line, int col, string text) {
        Console.SetCursorPosition(col, line);
        Console.Write(text);
    }

    public void Box(int line, int col, int width, int height, string bgColor) {
        Console.SetCursorPosition(col, line);
        int end = 0;

        for (int a = 0; a <= width + 2; a++) {
            if (a == width + 2) {
                Console.Write(bgColor +"╮\n"+ Style_Root.RESET);
            }else if (a == 0) {
                Console.Write(bgColor +"╭"+ Style_Root.RESET);
            }else {
                Console.Write(bgColor +"─"+ Style_Root.RESET);
            }
        }

        for (int a2 = 0; a2 <= height; a2++) {
            Console.SetCursorPosition(col, line + a2+1);
            Console.Write(bgColor + "│" + Style_Root.RESET);
            for (int b = 0; b <= width; b++) {
                Console.Write(bgColor + " ");
            }
            if (a2 == height) {
                Console.Write("\n");                
            }else {
                Console.Write(bgColor + "│\n" + Style_Root.RESET);                
            }
            end = a2+1;
        }
        
        Console.SetCursorPosition(col, line + end);
         for (int a = 0; a <= width + 2; a++) {
            if (a == width + 2) {
                Console.Write(bgColor +"╯\n"+ Style_Root.RESET);
            }else if (a == 0) {
                Console.Write(bgColor +"╰"+ Style_Root.RESET);
            }else {
                Console.Write(bgColor +"─"+ Style_Root.RESET);
            }
        }
        
    }

    public void Widget_Battery(int line, int col) {
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
        TextBox(line, col,  battery_ico );
        // fa.TextBox(3, 290, Style_Root.WHITE_BG + Style_Root.BLACK + battery_ico + Style_Root.RESET);
        
    }

    public void ClearCmd(){
        // Code by deepseek
            try
            {
                // Method 1: Standard escape sequences
                Console.Write("\u001b[2J\u001b[H");
                
                // Method 2: Alternative escape sequences
                Console.Write("\x1b[2J\x1b[H");
                
                // Method 3: Even more thorough
                Console.Write("\u001b[3J\u001b[H\u001b[2J");
                
                Console.SetCursorPosition(0, 0);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Clear failed: {e.Message}");
                Console.Clear(); // Fallback
            }
            
            Thread.Sleep(50);
    }

    public string CenterText(string text, int max) {
            // fa.TextBox(33,110 + 15, "----------------------------------");

            if (text.Length > max + 1) {
                text = text.Substring(0,max -3);
                text = text + "...";
            }
            
            for(int a = 0; a < (max - text.Length) ; a++) {
                text = " " + text;
            }

            return text;
    }
}