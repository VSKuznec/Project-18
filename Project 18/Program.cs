using Project_18.Commands;

namespace Project_18
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите ссылку на Youtube-видео:");
            string url = Console.ReadLine();

            var sender = new Sender();
            var receiver = new Receiver();

            var getDescription = new GetDescriptionVideo(receiver, url);
            sender.SetCommand(getDescription);
            sender.Run();

            sender.SetCommand(new DownloadVideo(receiver, url));
            sender.Run();
        }
    }
}