using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Converter;
using YoutubeExplode.Search;
using YoutubeExplode.Videos.Streams;

namespace Project_18.Commands
{
    class DownloadVideo : Command
    {
        Receiver receiver;
        string urlVideo;
        
        public DownloadVideo(Receiver receiver, string urlVideo)
        {
            this.receiver = receiver;
            this.urlVideo = urlVideo;
        }

        public override async void Run()
        {
            Console.WriteLine("\nVideo start to download!");
            var youtube = new YoutubeClient();
            var video = await youtube.Videos.GetAsync(urlVideo);
            var streamManifest = await youtube.Videos.Streams.GetManifestAsync(video.Id);
            var streamInfo = streamManifest.GetMuxedStreams().GetWithHighestVideoQuality();

            await youtube.Videos.Streams.DownloadAsync(streamInfo, $"video.{streamInfo.Container}");
            Console.WriteLine("Video downloaded!");
        }
    }
}
