using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRadioDatabase.SongExceptions
{
    class InvalidSongSecondsException : InvalidSongLengthException
    {
        public InvalidSongSecondsException()
            : base("Song seconds should be between 0 and 59.")
        {

        }

        public InvalidSongSecondsException(string message)
            : base(message)
        {

        }
    }
}
