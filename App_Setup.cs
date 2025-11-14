using WindowsInput;
using WindowsInput.Native;
using System;
using System.Threading.Tasks;
using Google.GenAI;
using Google.GenAI.Types;

class App_Setup{

    
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



}