using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRadioDatabase.SongExceptions
{
    class InvalidSongMinutesException : InvalidSongLengthException
    {
        public InvalidSongMinutesException()
            : base("Song minutes should be between 0 and 14.")
        {

        }

        public InvalidSongMinutesException(string message)
            : base(message)
        {

        }
    }
}
