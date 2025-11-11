using System;
public class Style_Root {

    public static string RESET = "\u001b[0m";
    
    // -- color
    public static string PRIMARY_ = "\u001b[30m";
    public static string MAGENTA = "\u001b[35m";
    public static string BLUE = "\u001b[34m";
    public static string CYAN = "\u001b[36m";
    public static string WHITE = "\u001b[37m";
    public static string BLACK = "\u001b[30m";
    public static string BLACK_WHITE = "\u001b[30;47m";

    // -- background color
    public static string PRIMARY_BG = "\u001b[47m";
    public static string WHITE_BG = "\u001b[47m";



    /*
    
    NOTES:

    -- color
        0 - black
        1 - red
        2 - green
        3 - yellow
        4 - blue
        5 - magenta
        6 - cyan
        7 - white

    */



    // ------------------- ICONS
    public static string[] file_icoH = {
        PRIMARY_ + PRIMARY_BG + @"..._________......." + RESET,
        PRIMARY_ + PRIMARY_BG + @"...\        \___..." + RESET,
        PRIMARY_ + PRIMARY_BG + @"....\        \ |..." + RESET,
        PRIMARY_ + PRIMARY_BG + @".....\________\|..." + RESET,
        PRIMARY_ + PRIMARY_BG + @"........file 1....." + RESET
    };
    public static string[] file_icoUH = {
        @"..._________.......",
        @"...\        \___...",
        @"....\        \ |...",
        @".....\________\|...",
        @"........file 1....."
    };

}