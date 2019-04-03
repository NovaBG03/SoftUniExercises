using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRadioDatabase.SongExceptions
{
    class InvalidSongLengthException : InvalidSongException
    {
        public InvalidSongLengthException()
            : base("Invalid song length.")
        {

        }

        public InvalidSongLengthException(string message)
            : base(message)
        {

        }
    }
}
