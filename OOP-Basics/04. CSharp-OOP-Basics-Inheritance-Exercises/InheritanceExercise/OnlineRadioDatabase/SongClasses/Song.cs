using OnlineRadioDatabase.SongExceptions;

namespace OnlineRadioDatabase.SongClasses
{
    class Song
    {
        private string artistName;
        private string name;
        private int[] length = new int[2];


        public Song(string artistName, string songName, int[] songLength)
        {
            this.ArtistName = artistName;
            this.Name = songName;
            this.Length = songLength;
        }


        public string ArtistName
        {
            private get => artistName;
            set
            {
                if (value.Length < 3 || value.Length > 20)
                {
                    throw new InvalidArtistNameException();
                }

                artistName = value;
            }
        }

        public string Name
        {
            private get => name;
            set
            {
                if (value.Length < 3 || value.Length > 20)
                {
                    throw new InvalidSongNameException();
                }

                name = value;
            }
        }

        public int[] Length
        {
            private get => length;
            set
            {
                if (value.Length > 2)
                {
                    throw new InvalidSongLengthException();
                }

                if (value[0] < 0 || value[0] > 14)
                {
                    throw new InvalidSongMinutesException();
                }

                if (value[1] < 0 || value[1] > 59)
                {
                    throw new InvalidSongSecondsException();
                }

                length = value;
            }
        }

        public int Minutes
        {
            get => this.Length[0];
        }

        public int Seconds
        {
            get => this.Length[1];
        }


        //public DateTime DateTimeLength
        //{
        //    get => this.CalculateDateTimeLength(); 
        //}


        //private DateTime CalculateDateTimeLength()
        //{
        //    return new DateTime(0, 0, 0, 0, this.length[0], this.Length[1]);
        //}
    }
}
