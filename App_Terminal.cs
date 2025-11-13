
using System;
using System.Text;
using WindowsInput;
using WindowsInput.Native;

class App_Terminal {
    static Frontend_Asset fa = new Frontend_Asset();
    public static InputSimulator sim = new InputSimulator();
    public static void Run() {
        Load();
    }
    static string command;
    public static void Load() {
        Frontend_Setup.program_running = true;
        Console.Clear();
        sim.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.OEM_PLUS);          
        sim.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.OEM_PLUS);          
        sim.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.OEM_PLUS);

        StringBuilder cli = new StringBuilder();
        cli.Append(@"C:\Azuki\User\Mashiro\");

        while (true) {
            Console.SetCursorPosition(0,0);
            Console.Write(cli);
            String command = Console.ReadLine();
            cli.Append(command+ "\n\n");
            Console.Clear();

            if(command == "--close") {
                sim.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.OEM_MINUS);          
                sim.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.OEM_MINUS);   
                sim.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.OEM_MINUS);
                Console.Clear();
                // erroring at bringing back
                Frontend_Setup.program_running = false;   
                break;
            }
            // fa.TextBox(6, 299, Style_Root.MAGENTA_BG + Style_Root.BLACK +  @"         " + Style_Root.RESET);
            // fa.TextBox(7, 299, Style_Root.MAGENTA_BG + Style_Root.BLACK +  @"  \‾\‾/  " + Style_Root.RESET);
            // fa.TextBox(8, 299, Style_Root.MAGENTA_BG + Style_Root.BLACK +  @"  /_\_\  " + Style_Root.RESET);
            // fa.TextBox(9, 299, Style_Root.MAGENTA_BG + Style_Root.BLACK +  @"         " + Style_Root.RESET)
        }

    }
}