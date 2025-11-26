using System.Text;
using System.Text.Json;
public class App_Notepad_Setup {
    
    public string title {get; set;}
    public string created {get; set;}
    public string content {get; set;}

    public static string filePath = "notepad.json";
    public static string json = File.ReadAllText(filePath);
    public static List<App_Notepad_Setup> student = JsonSerializer.Deserialize<List<App_Notepad_Setup>>(json);



    public static async Task Add(string title_, string content_) {
        DateTime date = DateTime.Now;

        App_Notepad_Setup add_note = new App_Notepad_Setup{
            title = title_,
            created = date.ToString("MM/dd/yy"),
            content = content_
        };

        string add = JsonSerializer.Serialize(add_note, new JsonSerializerOptions {
            WriteIndented = true
        });

        File.WriteAllText(filePath, add);
    }    

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