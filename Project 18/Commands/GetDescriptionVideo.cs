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
            Console.WriteLine("\nОписание видео:");
            var youtube = new YoutubeClient();

            var video = youtube.Videos.GetAsync(urlVideo).Result;
            Console.WriteLine($"Название видео: {video.Title}");
            Console.WriteLine($"Название канала: {video.Author.Title}");
            Console.WriteLine($"Длительность видео: {video.Duration}");
            receiver.Operation();
        }
    }
}
