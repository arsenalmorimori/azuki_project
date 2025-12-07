using WindowsInput;
using WindowsInput.Native;
using System.Text;
using System.Text.Json;
using System;
using System.Threading.Tasks;
using Google.GenAI;
using Google.GenAI.Types;
using Terminal.Gui;
using System.Linq;

class App_Setup{

    
    public static Frontend_Asset fa = new Frontend_Asset();
    public static InputSimulator sim = new InputSimulator();



    // ----------------- GENERAL ----------------- 

    public static void Zoom_In(int scroll){
        fa.ClearCmd();
        for(int a = 0; a < scroll; a++){
            sim.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.OEM_PLUS);
        }
    }

    public static void Zoom_Out(int scroll){
        fa.ClearCmd();
        for(int a = 0; a < scroll; a++){
            sim.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.OEM_MINUS);
        }
    }

    public static void LoadTaskbarBox_5(){
        fa.Box(1, 2, 163, 1,"");
    }

    public static void LoadTaskbar_5(string app,int center_col){
        fa.TextBox(2, center_col, "AZUKI OS  :  " + Style_Root.MAGENTA + app + Style_Root.RESET);
        fa.TextBox(2, 6,  $"{DateTime.Now.ToString("ddd")}   {DateTime.Now.ToString("MMM dd")}");
        fa.Widget_Battery(2,152);
    }

    public static void LoadingBar() {
        fa.ClearCmd();
        Thread.Sleep(50);
        Wallpaper.Loading_Blank();
        Console.SetCursorPosition(107,40);
        Console.Write(                   "                                            Loading                                            ");
        
        for(int a = 0; a <= 5 ; a++) {
            Console.SetCursorPosition(107,42);
            switch (a) {
                case 0:
                    Console.Write(Style_Root.BLACK + "────────────────────────────────────────────────────────────────────────────────────────────────" + Style_Root.RESET);
                    break;
                case 1:
                    Console.Write( Style_Root.MAGENTA + "───────────────────────" + Style_Root.BLACK +"─────────────────────────────────────────────────────────────────────────" + Style_Root.RESET);
                    break;
                case 2:
                    Console.Write( Style_Root.MAGENTA + "───────────────────────────────────────" + Style_Root.BLACK +"─────────────────────────────────────────────────────────" + Style_Root.RESET);
                    break;
                case 3:
                    Console.Write( Style_Root.MAGENTA + "────────────────────────────────────────────────────────" + Style_Root.BLACK +"────────────────────────────────────────" + Style_Root.RESET);
                    break;
                case 4:
                    Console.Write( Style_Root.MAGENTA + "─────────────────────────────────────────────────────────────────────────────────" + Style_Root.BLACK +"───────────────" + Style_Root.RESET);
                    break;
                case 5:
                    Console.Write( Style_Root.MAGENTA + "────────────────────────────────────────────────────────────────────────────────────────────────" + Style_Root.RESET);
                    break;
            }
            Thread.Sleep(50);
        }
    }

    public static void LoadingBar_5() {
        fa.ClearCmd();
        Thread.Sleep(50);
        Wallpaper.LoadingBlank_5();
        Console.SetCursorPosition(53,23);
        Console.Write(                   "                           Loading                           ");
        for(int a = 0; a <= 5 ; a++) {
            Console.SetCursorPosition(53,25);
            switch (a) {
                case 0:
                    Console.Write(Style_Root.BLACK + "─────────────────────────────────────────────────────────────" + Style_Root.RESET);
                    break;
                case 1:
                    Console.Write( Style_Root.MAGENTA + "──────────────────" + Style_Root.BLACK +"───────────────────────────────────────────" + Style_Root.RESET);
                    break;
                case 2:
                    Console.Write( Style_Root.MAGENTA + "────────────────────────" + Style_Root.BLACK +"─────────────────────────────────────" + Style_Root.RESET);
                    break;
                case 3:
                    Console.Write( Style_Root.MAGENTA + "─────────────────────────────────────────" + Style_Root.BLACK +"────────────────────" + Style_Root.RESET);
                    break;
                case 4:
                    Console.Write( Style_Root.MAGENTA + "─────────────────────────────────────────────────────" + Style_Root.BLACK +"────────" + Style_Root.RESET);
                    break;
                case 5:
                    Console.Write( Style_Root.MAGENTA + "─────────────────────────────────────────────────────────────" + Style_Root.RESET);
                    break;
            }
            Thread.Sleep(50);
        }
    }




    // ----------------- GEMINI TERMINAL ----------------- 

    public static async Task Ask(string question){

        var response = await env_private.client.Models.GenerateContentAsync(
            model: "gemini-2.0-flash",
            contents: question + ". Answer in only one short sentence. Must not exceed to 145 characters, including spaces");
        App_Terminal.cli.Append(Style_Root.MAGENTA + "   > " + response.Candidates[0].Content.Parts[0].Text + Style_Root.RESET +"\n");
        
    }

    public static async Task Ask_Motivation(string question){

        var response = await env_private.client.Models.GenerateContentAsync(
            model: "gemini-2.0-flash",
            contents: question + ". Please gieve a quotation, phrase, or analogy that can help me mentally. Please dont use most common ai word like embrace, unleash, etc. Must not exceed to 145 characters, including spaces");
        App_Terminal.cli.Append(Style_Root.MAGENTA + "   > " + response.Candidates[0].Content.Parts[0].Text + Style_Root.RESET +"\n");
        
    }


    // ----------------- NOTEPAD ----------------- 
    
    public static void Hypentext(int max, string text, int col, int line) {
        StringBuilder sentence = new StringBuilder();
        string[] words = text.Split(' ','\n');

        int word_count = 0;
        int box_line = 0;
        int line_ = line;

        for (int a = 0; a < words.Length; a++) {
            if (word_count + words[a].Length >= max || a == words.Length-1) {
                Console.SetCursorPosition(col,line_);
                word_count+= words[a].Length+1;
                Console.Write(sentence );
                sentence.Clear();
                line_++;  
                box_line++;  
                word_count = 0;
            }
            sentence.Append(words[a] + " ");
            if (a == words.Length -1) {
                Console.Write(sentence );
                sentence.Clear();
            }
            word_count+= words[a].Length+1;
        }
        
        App_Notepad.box_title_end += box_line+1;
    }



}