
    using System.Text;
    using System.Net.Http.Headers;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    class App_Thread{

        /*
            DESCRIPTION :
                - Class for THREAD APPLICATION or message / forum app
                - It use realtime database concept but using seperate Threads and HTTPS that reload every second defined
                - User interaction will ONLY respond after a reload... be patient <3
            
            API USED :
                - SUPABASE Database
        */
        
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
        // public static int Pointer = -1;
        public static int current_len = 0;
        public static int isActive= 0;
        public static bool loop_contorol = true;
        public static bool end_thread = false;
        public static bool end_main_thread = false;
        public static ConsoleKeyInfo cursor;



        // -------------------------- METHOD --------------------------
        public static void Run() {
        
            current_len = 0;
            isActive= 0;
            loop_contorol = true;
            end_thread = false;
            end_main_thread = false;

            Load();

            Thread load_thread = new Thread(Load_https().Wait);
            load_thread.Start();

            Input_System();    
        }



        public static void Load() {
            // -- Setting  Environment
            if (!Frontend_Setup.program_running) {
                fa.ClearCmd();    
                Frontend_Setup.program_running = true;
                App_Setup.Zoom_In(5);
                App_Setup.LoadingBar_5();
            }


            fa.ClearCmd();    
            Wallpaper.Window_5();
            App_Setup.LoadTaskbarBox_5();
            fa.Box(5,15,135,37,"");
            fa.TextBox(5, 88, "");
            fa.TextBox(42, 17, Style_Root.MAGENTA + "LOADING..." + Style_Root.RESET);
            fa.Box(36+8,15,135,1,"");
            fa.TextBox(45,17, Style_Root.MAGENTA + "  >   please wait until the loading finished..."+Style_Root.RESET );

        }

        public static void Input_System() {

            // Loading the screen
            while (loop_contorol) {
                while (isActive == 0) {
                cursor = Console.ReadKey(intercept: true);

                if (cursor.Key == ConsoleKey.M) {
                    isActive ++;
                }else if (cursor.Key == ConsoleKey.X) {
                    end_thread = true;
                    loop_contorol = false;
                    Thread.Sleep(1500);
                    break;
                }else {
                    current_len = 0;
                }

                }

            }
        }



    // ----------------------------------------------- BACKEND -----------------------------------------------
        public static async Task Load_https() {
            Thread.Sleep(1000);
            string url = "https://"+env_private.supabase_project+".supabase.co/rest/v1/azuki_message?select=*&apikey="+ env_private.supabase_anonkey;

            using HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", env_private.supabase_anonkey);
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            
            try{
                    bool reload = true;
                    while (reload) {
                        HttpResponseMessage response = await client.GetAsync(url);
                        response.EnsureSuccessStatusCode();
                        
                        string json = await response.Content.ReadAsStringAsync();
                        var messages = JsonSerializer.Deserialize<List<App_Thread>>(json);
                        int len = messages.Count;
                        int line = 42;

                        
                        Thread.Sleep(500);
                        for(int a = len-1; a > 0 ; a--) {
                            if (line >= 6 ) {
                            Console.SetCursorPosition(17,line);
                            Console.Write("                                                                                                                                       │" );
                            Console.SetCursorPosition(17,line);
                            Thread.Sleep(50);

                                if(messages[a].Username == env.username) {
                                    Console.Write(Style_Root.MAGENTA + $"<{messages[a].Username}>  {messages[a].Message}" + Style_Root.RESET );
                                }else {
                                    Console.Write($"<{messages[a].Username}>  {messages[a].Message}" ); 
                                }
                                line--;
                            }
                            
                        }
                        
                        
                        App_Setup.LoadTaskbar_5("Thread",69);
                        fa.Box(36+8,15,135,1,"");
                        fa.TextBox(45,17, Style_Root.MAGENTA + "  >   [m] to create a message... press once and wait for it to reload"+Style_Root.RESET );

                        if (end_thread == true) {
                            reload = false;
                            loop_contorol = false;
                            end_thread = false;
                            fa.ClearCmd();
                            App_Setup.LoadingBar_5();
                            App_Setup.Zoom_Out(5);
                            end_main_thread = true;
                            break;
                        }
                        if (isActive == 1) {
                            fa.Box(36+8,15,135,1,Style_Root.MAGENTA);
                            Console.SetCursorPosition(17, 45);
                            string message_input = Console.ReadLine();
                            Add(message_input);
                            isActive = 0;
                            
                        }
                    }
                
                
            }catch (Exception ex){
                    // Console.WriteLine("Error fetching messages: " + ex.Message);
            }
        }
        
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
    
    }









