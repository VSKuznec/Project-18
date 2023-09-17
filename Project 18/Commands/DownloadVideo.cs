using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Converter;
using YoutubeExplode.Search;

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
            Console.WriteLine("\nНачалось скачивание видео!");
            var youtube = new YoutubeClient();
            var video = await youtube.Videos.GetAsync(urlVideo);
            string nameVideo = "C:\\Users\\sevac\\source\\repos\\Project 18\\Project 18\\bin\\Debug\\net7.0.mp4";

            await youtube.Videos.DownloadAsync(urlVideo, nameVideo, builder => builder.SetPreset(ConversionPreset.UltraFast)).ConfigureAwait(false);
            receiver.Operation($"Видео скачано в файл: {nameVideo}");
        }
    }
}
