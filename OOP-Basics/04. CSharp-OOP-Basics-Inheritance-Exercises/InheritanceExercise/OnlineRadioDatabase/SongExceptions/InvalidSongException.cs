using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRadioDatabase.SongExceptions
{
    class InvalidSongException : Exception
    {
        public InvalidSongException() 
            : base("Invalid song.")
        {
            
        }

        public InvalidSongException(string message)
            : base(message)
        {

        }
    }
}
