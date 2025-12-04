using System;
using System.IO;
using System.Linq;
using System.Threading;
using NAudio.Wave;

class App_Music_Setup
{

    public static string[] playlist;    
    private static AudioFileReader audioFile;

    private static IWavePlayer outputDevice;
    private static int playing;
    public static int index_request = 0;
    public static int current_index = 0;
    public static int play_pause = 1;

    public static void GetPlaylist()
    {
        string musicFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Music");

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



    public static void PlaySong(string file)
    {

        try
        {
            audioFile = new AudioFileReader(file);
            outputDevice = new WaveOutEvent();
            outputDevice.Init(audioFile);
            outputDevice.Play();

            Console.WriteLine("Playing: " + Path.GetFileName(file));

            while (true)
            {
                if (current_index != index_request)
                {
                    Stop();
                    Play();
                    current_index = index_request;
                    PlaySong(playlist[current_index]);
                    Console.WriteLine("PLAYING   :   " + playlist[current_index]);   
                }

            }


        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
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