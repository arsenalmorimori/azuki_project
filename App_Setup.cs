using WindowsInput;
using WindowsInput.Native;
using System;
using System.Threading.Tasks;
using Google.GenAI;
using Google.GenAI.Types;
using Terminal.Gui;
using System.Linq;

class App_Setup{

    
    public static Frontend_Asset fa = new Frontend_Asset();
    public static InputSimulator sim = new InputSimulator();

    public static void Zoom_In(int scroll){
        for(int a = 0; a < scroll; a++){
            sim.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.OEM_PLUS);
        }
    }

    public static void Zoom_Out(int scroll){
        for(int a = 0; a < scroll; a++){
            sim.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.OEM_MINUS);
        }
    }


    public static void OpeningAppScreen(string text1, string text2,string text3,string text4) {
        Console.WriteLine(Style_Root.MAGENTA + text1 + "....."+ Style_Root.RESET);
        Thread.Sleep(100);
        Console.WriteLine(Style_Root.MAGENTA + text2 + "....."+ Style_Root.RESET);
        Thread.Sleep(200);
        Console.WriteLine(Style_Root.MAGENTA + text3 + "....."+ Style_Root.RESET);
        Thread.Sleep(300);
        Console.WriteLine(Style_Root.MAGENTA + text4 + "....."+ Style_Root.RESET);
        Thread.Sleep(400);
    }
    public static void ClosingAppScreen(string text1, string text2,string text3,string text4,string text5,string text6) {
        Console.WriteLine(Style_Root.MAGENTA + text1 + "....."+ Style_Root.RESET);
        Thread.Sleep(100);
        Console.WriteLine(Style_Root.MAGENTA + text2 + "....."+ Style_Root.RESET);
        Thread.Sleep(200);
        Console.WriteLine(Style_Root.MAGENTA + text3 + "....."+ Style_Root.RESET);
        Thread.Sleep(300);
        Console.WriteLine(Style_Root.MAGENTA + text4 + "....."+ Style_Root.RESET);
        Thread.Sleep(400);
        Console.WriteLine(Style_Root.MAGENTA + text5 + "....."+ Style_Root.RESET);
        Thread.Sleep(500);
        Console.WriteLine(Style_Root.MAGENTA + text6 + "....."+ Style_Root.RESET);
        Thread.Sleep(600);
    }




    public static async Task Ask(){
        var client = new Client(apiKey: "AIzaSyDuoIzXFjrIFzAAnUnnaiIvFxDGG-LziOA");

        var response = await client.Models.GenerateContentAsync(
            model: "gemini-2.0-flash",
            contents: "Explain how AI works in a few words"
        );

        App_Terminal.cli.Append(response.Candidates[0].Content.Parts[0].Text);
    }

    public static void LoadTaskbarBox_5(){
        fa.Box(1, 2, 163, 1,"");
    }

    public static void LoadTaskbar_5(string app,int center_col){
        fa.TextBox(2, center_col, "AZUKI OS  :  " + Style_Root.MAGENTA + app + Style_Root.RESET);
        fa.TextBox(2, 6,  "SUN   NOV 11");
        fa.Widget_Battery(2,152);
    }


    public static void LoadingBar() {
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
            Thread.Sleep(100);
        }
    }



    public static void LoadingBar_5() {
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
            Thread.Sleep(100);
        }
    }




    // SCROLLABLE WINDOW using console key UP and DOWN
    // CODE by AI 
    public static void AppWindow_5(){
//         int windowX = 5, windowY = 5, width = 50, height = 10;
//         string[] lines = Enumerable.Range(1, 100).Select(i => $"Line {i}").ToArray();
//         int scroll = 0;

//         ConsoleKey key;

//         do
//         {
//     // Draw window border
//     for (int y = 0; y <= height; y++)
//     {
//         Console.SetCursorPosition(windowX, windowY + y);
//         if (y == 0 || y == height)
//             Console.Write("+" + new string('-', width - 2) + "+");
//         else
//             Console.Write("|" + new string(' ', width - 2) + "|");
//     }

//     // Draw visible content
//     for (int y = 0; y < height - 2; y++)
//     {
//         int lineIndex = scroll + y;
//         if (lineIndex >= lines.Length) break;
//         Console.SetCursorPosition(windowX + 1, windowY + 1 + y);
//         string text = lines[lineIndex].PadRight(width - 2);
//         Console.Write(text);
//     }

//     key = Console.ReadKey(true).Key;

//     if (key == ConsoleKey.DownArrow && scroll < lines.Length - (height - 2))
//         scroll++;
//     else if (key == ConsoleKey.UpArrow && scroll > 0)
//         scroll--;

// } while (key != ConsoleKey.Escape);

    }



}