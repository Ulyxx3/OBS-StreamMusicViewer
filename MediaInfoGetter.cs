using System;
using System.IO;
using System.Threading.Tasks;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Media.Control;
using Windows.Storage.Streams;

namespace MediaInfoGetter
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string artworkPath = args.Length > 0 ? args[0] : "temp_artwork.jpg";
            
            try
            {
                var sessionManager = await GlobalSystemMediaTransportControlsSessionManager.RequestAsync();
                var session = sessionManager.GetCurrentSession();
                
                if (session == null)
                {
                    Console.WriteLine("NO_TRACK");
                    return;
                }
                
                var mediaProps = await session.TryGetMediaPropertiesAsync();
                
                if (mediaProps == null)
                {
                    Console.WriteLine("NO_TRACK");
                    return;
                }
                
                string title = mediaProps.Title ?? "Unknown Title";
                string artist = mediaProps.Artist ?? "Unknown Artist";
                string album = mediaProps.AlbumTitle ?? "";
                
                var playbackInfo = session.GetPlaybackInfo();
                int status = playbackInfo != null ? (int)playbackInfo.PlaybackStatus : 3;
                
                bool hasArtwork = false;
                if (mediaProps.Thumbnail != null)
                {
                    try
                    {
                        using (var stream = await mediaProps.Thumbnail.OpenReadAsync())
                        {
                            byte[] buffer = new byte[stream.Size];
                            await stream.ReadAsync(buffer.AsBuffer(), (uint)stream.Size, InputStreamOptions.None);
                            File.WriteAllBytes(artworkPath, buffer);
                            hasArtwork = true;
                        }
                    }
                    catch
                    {
                        // Artwork not available
                    }
                }
                
                Console.WriteLine($"{title}|{artist}|{album}|{status}|{hasArtwork}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR:{ex.Message}");
                Environment.Exit(1);
            }
        }
    }
}
