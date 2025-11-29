using System.Text;
using System.Text.Json;
public class App_Notepad_Setup {

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