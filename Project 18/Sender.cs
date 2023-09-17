using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_18.Commands;
using YoutubeExplode.Converter;
using YoutubeExplode.Search;

namespace Project_18
{
    class Sender
    {
        private Command _command;

        public void SetCommand(Command command)
        {
            _command = command;
        }

        public async void Run()
        {
            _command.Run();
        }
    }
}
