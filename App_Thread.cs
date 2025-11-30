
using System.Text;
using System.Net.WebSockets;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using TextCopy;
using System.Management;
using System.Text.Json;
using System;
using System.Collections;
using System.Drawing.Drawing2D;
using System.Text;
using System.Threading.Tasks;
class App_Thread{

    
    // -------------------------- SETTING JSON VARIABLE --------------------------
     [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("username")]
    public string Username { get; set; }

    [JsonPropertyName("message")]
    public string Message { get; set; }

    [JsonPropertyName("created_at")]
    public string CreatedAt { get; set; }

    
    // -------------------------- DECLARATION --------------------------
    static Frontend_Asset fa = new Frontend_Asset();
    static App_Notepad_Setup ns = new App_Notepad_Setup();
    // public static int Pointer = -1;
    public static int current_len = 0;
    public static int isActive= 0;

        



    // -------------------------- METHOD --------------------------
    public static void Run() {
        Thread input_thread = new Thread(Load);
        input_thread.Start();

        Thread load_thread = new Thread(Load_https().Wait);
        load_thread.Start();
        
        
        
    }






    // -- Failed attempt with GUI 
    // public static void Load() {
    //     // -- Setting  Environment
    //     if (!Frontend_Setup.program_running) {
    //         fa.ClearCmd();    
    //         Frontend_Setup.program_running = true;
    //         App_Setup.Zoom_In(5);
    //         App_Setup.LoadingBar_5();
    //     }


    //     fa.ClearCmd();    
    //     Wallpaper.Window_5();
    //     // App_Setup.LoadTaskbarBox_5();


    //     // Loading the screen
    //     while (true) {
    //         // App_Setup.LoadTaskbar_5("Thread",69);
    //         fa.Box(3,15,135,39,"");
    //         fa.Box(36+8,15,135,1,"");
    //         fa.TextBox(45,17, Style_Root.MAGENTA + "  >   [m] to create a message... [↑/↓] to scroll"+Style_Root.RESET );
            
    //         Console.SetCursorPosition(0,0);
    //         cursor = Console.ReadKey().Key;

    //         if (cursor == ConsoleKey.M) {
    //             isActive = 1;
    //             Thread.Sleep(500);
    //             fa.Box(36+8,15,135,1,Style_Root.MAGENTA);
    //             Console.SetCursorPosition(17, 45);
    //             string message_input = Console.ReadLine();
    //             Add(message_input);
    //             isActive = 0;
                    
    //         }else {
    //             current_len = 0;
    //         }

        
    //     }

    // }
















// ----------------------------------------------- BACKEND -----------------------------------------------


    public static void Load() {
        // -- Setting  Environment
        if (!Frontend_Setup.program_running) {
            fa.ClearCmd();    
            Frontend_Setup.program_running = true;
            App_Setup.Zoom_In(5);
            App_Setup.LoadingBar_5();
        }


        // fa.ClearCmd();    
        // Wallpaper.Window_5();

        while (true) {
            ConsoleKeyInfo cursor = Console.ReadKey(intercept: true);
            if (cursor.Key == ConsoleKey.M) {
                isActive ++;
                    
                Console.SetCursorPosition(0, 40);
                string message_input = Console.ReadLine();
                Add(message_input);
                isActive --;
            }else {
                current_len = 0;
            }

        
        }

    }
















// ----------------------------------------------- BACKEND -----------------------------------------------





    public async static void Add(string message_){

        string insertUrl = "https://" + env_private.supabase_project + ".supabase.co/rest/v1/azuki_message";

        var newMessageJson = "{\"username\":\"" + env.username + "\",\"message\":\"" + message_ + "\"}";

        using HttpClient client = new HttpClient();

        // Headers
        client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", env_private.supabase_anonkey);

        client.DefaultRequestHeaders.Add("apikey", env_private.supabase_anonkey);
        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json")
        );

        // Body
        HttpContent content = new StringContent(newMessageJson, Encoding.UTF8, "application/json");

        // Send POST
        HttpResponseMessage response = await client.PostAsync(insertUrl, content);
        response.EnsureSuccessStatusCode();

        string result = await response.Content.ReadAsStringAsync();
    }



    // -- Failed attempt with GUI 
    // public static async Task Load_https() {
    //     string url = "https://"+env_private.supabase_project+".supabase.co/rest/v1/azuki_message?select=*&apikey="+ env_private.supabase_anonkey;

    //     using HttpClient client = new HttpClient();
    //     client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", env_private.supabase_anonkey);
    //     client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        
    //     try{
    //         while (true) {
    //                 HttpResponseMessage response = await client.GetAsync(url);
    //                 response.EnsureSuccessStatusCode();
                    
    //                 string json = await response.Content.ReadAsStringAsync();
    //                 var messages = JsonSerializer.Deserialize<List<App_Thread>>(json);
    //                 int len = messages.Count;
                    
    //                 if((isActive & 1) == 1) {
          
    //                 }else {
    //                     if(current_len == len) {
    //                     // do nothing

    //                     }else {
    //                         StringBuilder message_con = new StringBuilder();
    //                         current_len = len;

    //                         message_con.Append("╭────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────╮\n"+
    //                                            "│                                                                                                                                                                        │\n"+
    //                                            "│                                                                                                                                                                        │\n"+
    //                                            "│              ╭────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────╮                │\n");


    //                         if (len < 39) {
    //                             for(int a = 0 ; a < 39 - len; a++) {
    //                                 message_con.Append("│              │                                                                                                                                        │                │\n");
    //                             }
    //                         }

    //                         for(int a = 0; a < len ; a++) {
    //                             if(messages[a].Username == env.username) {
    //                                 message_con.Append("│              │ " + Style_Root.MAGENTA + $"<{messages[a].Username}>  {messages[a].Message}" + Style_Root.RESET + "\n");
    //                             }else {
    //                                 message_con.Append($"│              │ <{messages[a].Username}>  {messages[a].Message}" + "\n"); 
    //                             }
    //                         } 

    //                         Console.SetCursorPosition(0,0);
    //                         Console.Write(message_con);
    //                         messages.Clear();


    //                     }

    //                 }
    //         }
            
    //     }catch (Exception ex){
    //             // Console.WriteLine("Error fetching messages: " + ex.Message);
    //     }



    // }
    
    
    public static async Task Load_https() {
        string url = "https://"+env_private.supabase_project+".supabase.co/rest/v1/azuki_message?select=*&apikey="+ env_private.supabase_anonkey;

        using HttpClient client = new HttpClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", env_private.supabase_anonkey);
        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        if (isActive == 0) {
            bool load_ = true;
            try{
                while (load_) {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    
                    string json = await response.Content.ReadAsStringAsync();
                    var messages = JsonSerializer.Deserialize<List<App_Thread>>(json);
                    int len = messages.Count;
                    
                    StringBuilder message_con = new StringBuilder();
                    current_len = len;
                    
                    for(int a = 0; a < len ; a++) {
                        if(messages[a].Username == env.username) {
                            message_con.Append( Style_Root.MAGENTA + $"<{messages[a].Username}>  {messages[a].Message}" + Style_Root.RESET + "\n");
                        }else {
                            message_con.Append($"<{messages[a].Username}>  {messages[a].Message}" + "\n"); 
                        }
                    } 

                    Console.Clear();
                    Console.Write(message_con);
                    messages.Clear();

                    // fa.Box(36+8,15,135,1,"");
                    // fa.TextBox(45,17, Style_Root.MAGENTA + "  >   [m] to create a message... [↑/↓] to scroll"+Style_Root.RESET );
                    Thread.Sleep(1000);
                    load_ = isActive == 0 ? true : false;
                }
            }catch (Exception ex){
                    // Console.WriteLine("Error fetching messages: " + ex.Message);
            }
        }
        else {
            
        }
        



    }
    
    


// ----------------------------------------------- FRONTEND -----------------------------------------------
    // public static void Clear_ThreadBox() {
    //     Thread.Sleep(50);
    //     for (int a = 6 ; a <= 40; a++) {
    //         Console.SetCursorPosition(17, a);
    //         Console.Write("                                                                                                                                      ");
    //     }
    // }
}









