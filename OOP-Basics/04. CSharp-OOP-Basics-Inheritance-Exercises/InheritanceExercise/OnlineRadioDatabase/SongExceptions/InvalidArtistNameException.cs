using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRadioDatabase.SongExceptions
{
    class InvalidArtistNameException : InvalidSongException
    {
        public InvalidArtistNameException()
            : base("Artist name should be between 3 and 20 symbols.")
        {

        }

        public InvalidArtistNameException(string message)
            : base(message)
        {

        }
    }
}
