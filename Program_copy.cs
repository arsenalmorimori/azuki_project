// dotnet add package NAudio
using System.Media;
class Program_copy
{
    
    static int current_index = 0;
    public static void Main(string[] args)
    {
    Thread inpu_system_ = new Thread(inpu_system);
        Thread music_bg = new Thread(Run_2);
            inpu_system_.Start();
            music_bg.Start();
            

    }

    public static void inpu_system()
    {
        
        while (true)
        {
            ConsoleKey cursor = new ConsoleKey();
            cursor = Console.ReadKey().Key;
            if (cursor == ConsoleKey.D){
                if (Music_2.index_request > (Music_2.playlist.Length) - 2)
                {
                    Music_2.index_request = 0;
                    Console.WriteLine("back  :   " + Music_2.index_request);
                }
                else
                {
                    Music_2.index_request ++;
                    Console.WriteLine("add  :   " + Music_2.index_request);
                }
            }else if (cursor == ConsoleKey.A){
                if (Music_2.index_request <= 0)
                {
                    Music_2.index_request =  Music_2.playlist.Length-1;
                    Console.WriteLine("back  :   " + Music_2.index_request);
                }
                else
                {
                    Music_2.index_request --;
                    Console.WriteLine("sub  :   " + Music_2.index_request);
                }
            }else if (cursor == ConsoleKey.Spacebar){
                Music_2.Play_Pause();
            }
        }
    }

public static void Run_2(){
        Music_2.GetPlaylist();

        Music_2.PlaySong(Music_2.playlist[Music_2.current_index]);

        // DISPLAY SONG
        int start = Music_2.playlist[0].ToString().IndexOf(@"Debug\net9.0\Music");
        int len = @"Debug\net9.0\Music".Length;

        foreach(var item in Music_2.playlist){
            Console.WriteLine(item.ToString().Substring(start + len + 1, item.Length - (start + len + 1)));
        }
        

    }

}

