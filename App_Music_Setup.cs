using System;
using System.IO;
using System.Linq;
using System.Threading;
using NAudio.Wave;

class App_Music_Setup
{

    public static string[] playlist;    
    public static AudioFileReader audioFile;

    private static IWavePlayer outputDevice;
    private static int playing;
    public static int index_request = 0;
    public static int current_index = 0;
    public static int play_pause = 0;
    public static float volume = 0.3f;

    public static void Music_Activity() {
        while (true){
                
            if (play_pause == 1) {
                
                if (current_index != index_request){
                    Stop();
                    Play();
                    current_index = index_request;
                    PlaySong(playlist[current_index]);
                    
                  
                }

            }

            if (audioFile != null){
                audioFile.Volume = volume; // this can change in real-time
                Thread.Sleep(1000);
            }

            try
            {
                TimeSpan buffer = TimeSpan.FromMilliseconds(500); // margin of error

                if (audioFile.CurrentTime >= audioFile.TotalTime - buffer)
                {
                    if(current_index == playlist.Length-1){
                        current_index = 0;
                        index_request = 0;
                    }else{
                        index_request++;
                    }

                    App_Music.current_song = playlist[current_index].Substring(playlist[current_index].IndexOf(@"Debug\net9.0-windows\music") + 27, playlist[current_index].Length - (playlist[current_index].IndexOf(@"Debug\net9.0-windows\music") + 27));
                }
            }
            catch{
            }

                

            }

    }

    public static void PlaySong(string file)
    {
        play_pause = 1;
        try
        {
            audioFile = new AudioFileReader(file);
            outputDevice = new WaveOutEvent();
            audioFile.Volume = volume; 
            outputDevice.Init(audioFile);
            outputDevice.Play();

            // Console.WriteLine("Playing: " + Path.GetFileName(file));
            App_Music.current_song = playlist[current_index].Substring(playlist[current_index].IndexOf(@"Debug\net9.0-windows\music") + 27, playlist[current_index].Length - (playlist[current_index].IndexOf(@"Debug\net9.0-windows\music") + 27));
            


        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    public static async void GetPlaylist()
    {
        string musicFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "music");

        if (!Directory.Exists(musicFolder))
        {
            Console.WriteLine("Music folder not found.");
            return;
        }

        playlist = Directory.GetFiles(musicFolder, "*.*")
            .Where(f => f.EndsWith(".mp3", StringComparison.OrdinalIgnoreCase)
                     || f.EndsWith(".wav", StringComparison.OrdinalIgnoreCase))
            .ToArray();
    }

    public static void Stop()
    {
         if (outputDevice != null)
        {
            outputDevice.Stop();   // stops audio immediately
            outputDevice.Dispose();
            audioFile.Dispose();
        }  
    }

    public static void Play()
    {
        playing = 1;   
    }

    public static void Play_Pause()
    {
        if (play_pause == 1)
        {
            outputDevice.Stop();   // stops audio immediately
            play_pause = 0;
        }else if (play_pause == 0)
        {
            outputDevice.Play();   // stops audio immediately
            play_pause = 1;
        }
    }





}