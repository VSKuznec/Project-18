using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata.Ecma335;
using YoutubeExplode;
using YoutubeExplode.Converter;

namespace Project_18.Commands
{
    class GetDescriptionVideo : Command
    {
        Receiver receiver;
        string urlVideo;
        
        public GetDescriptionVideo(Receiver receiver, string urlVideo)
        {
            this.receiver = receiver;
            this.urlVideo = urlVideo;
        }

        public override void Run()
        {
            Console.WriteLine("\nVideo description:");
            var youtube = new YoutubeClient();

            var video = youtube.Videos.GetAsync(urlVideo).Result;
            Console.WriteLine($"Video title: {video.Title}");
            Console.WriteLine($"Channel name: {video.Author.Title}");
            Console.WriteLine($"Video duration: {video.Duration}");
            receiver.Operation();
        }
    }
}
