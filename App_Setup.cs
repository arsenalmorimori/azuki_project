using WindowsInput;
using WindowsInput.Native;

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


}