using System.Text.Json;
class json_db {
    // public int Id {get; set;}
    // public string Name {get; set;}

    public string title {get; set;}
    public string created {get; set;}
    public string content {get; set;}

    public static void json_input() {
        string title_ = "Hello!";
        string mess;
        DateTime date = DateTime.Now;
        Console.WriteLine("");
        Console.WriteLine("Enter message  ");
        // mess = Console.ReadLine();

        string filePath = "note.json";
        string json = File.ReadAllText(filePath);
        List<json_db> student = JsonSerializer.Deserialize<List<json_db>>(json);

        string add_ = JsonSerializer.Serialize(student, new JsonSerializerOptions {
            WriteIndented = true
        });

        File.WriteAllText(filePath, add_);
        json = File.ReadAllText(filePath);
        Console.WriteLine(json);
        hypentext(25,student[4].content);
    }

    public static void hypentext(int max, string text) {
        string[] words = text.Split(' ');

        int word_count = 0;
        for (int a = 0; a < words.Length; a++) {
            if (word_count + words[a].Length >= max) {
                Console.Write("\n");    
                word_count = 0;
            }
            Console.Write(words[a] + " ");
            word_count+= words[a].Length+1;
        }
    }
    public static void Run() {
    //     string filePath = "students.json";
    //     string json = File.ReadAllText(filePath);

    //     Console.WriteLine(json);

    //     List<json_db> student = JsonSerializer.Deserialize<List<json_db>>(json);
    //     Console.WriteLine(student[0].Name);
    //     Console.WriteLine(student[1].Name);
    //     Console.WriteLine("// ADD");
       



    //     //    ADD
    //     // json_db add_student = new json_db{
    //     //     Id = 6,
    //     //     Name = "L"
    //     // };

    //     // student.Add(add_student);
        



    //     // DELETE
    //     // for (int a =0; a< student.Count ; a++) {
    //     //     if(student[a].Name == "DELETE THIS") {
    //     //         student.Remove(student[a]);
    //     //     }
    //     // }
        



    //     // UPDATE
    //     for (int a =0; a< student.Count ; a++) {
    //         if(student[a].Id == 8) {
    //             student[a].Name = "UPDATED";
    //         }
    //     }

    //     string update = JsonSerializer.Serialize(student, new JsonSerializerOptions {
    //         WriteIndented = true
    //     });

    //     File.WriteAllText(filePath, update);
    //     json = File.ReadAllText(filePath);
    //     Console.WriteLine(json);
    }
}