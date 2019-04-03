using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRadioDatabase.SongExceptions
{
    class InvalidSongNameException : InvalidSongException
    {
        public InvalidSongNameException()
            : base("Song name should be between 3 and 30 symbols.")
        {

        }

        public InvalidSongNameException(string message)
            : base(message)
        {

        }
    }
}
