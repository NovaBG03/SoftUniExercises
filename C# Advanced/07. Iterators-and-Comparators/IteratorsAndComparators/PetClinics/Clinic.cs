using System;
using System.Text;

namespace PetClinics
{
    public class Clinic 
    {
        private Pet[] rooms;
        private int index;
        private bool isLeft;
        private int increaser;

        public Clinic(string name, int roomsCount)
        {
            this.Name = name;
            this.Rooms = new Pet[roomsCount];
            this.Reset();
        }

        public string Name { get; private set; }

        private Pet[] Rooms
        {
            get => rooms;
            set
            {
                if (value.Length % 2 == 0)
                {
                    throw new ArgumentException("Rooms count must be an odd number.");
                }

                rooms = value;
            }
        }

        private Pet Current
        {
            get => this.Rooms[index];
            set => this.Rooms[index] = value;
        }

        private int MiddleIndex => this.Rooms.Length / 2;

        private void MoveNext()
        {
            if (this.isLeft)
            {
                if (this.MiddleIndex + this.increaser < this.Rooms.Length)
                {
                    this.index = this.MiddleIndex + this.increaser;
                    this.isLeft = false;
                    this.increaser++;
                    //return true;
                    return;
                }
                //return false;
                return;
            }

            this.index = this.MiddleIndex - this.increaser;
            this.isLeft = true;
            //return true;
            return;
        }

        private void Reset()
        {
            //this.index = this.MiddleIndex;
            this.increaser = 0;
            this.isLeft = true;
        }

        public bool Add(Pet pet)
        {
            this.Reset();

            for (int i = 0; i < this.Rooms.Length; i++)
            {
                MoveNext();
                if ((this.Current is null))
                {
                    this.Current = pet;
                    return true;
                }
            }

            return false;
        }

        internal bool HasEmptyRooms()
        {
            for (int i = 0; i < this.Rooms.Length; i++)
            {
                var currentRoom = this.Rooms[i];

                if (currentRoom is null)
                {
                    return true;
                }
            }

            return false;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < this.Rooms.Length; i++)
            {
                if (this.Rooms[i] is null)
                {
                    builder.AppendLine("Room empty");
                }
                else
                {
                    builder.AppendLine(this.Rooms[i].ToString());
                }
            }

            return builder.ToString().TrimEnd();
        }

        public bool Release()
        {
            for (int i = this.MiddleIndex; i < this.Rooms.Length; i++)
            {
                if (!(this.Rooms[i] is null))
                {
                    this.Rooms[i] = null;
                    return true;
                }
            }

            for (int i = 0; i < this.MiddleIndex; i++)
            {
                if (!(this.Rooms[i] is null))
                {
                    this.Rooms[i] = null;
                    return true;
                }
            }

            return false;
        }

        public Pet this[int index]
        {
            get => this.Rooms[index]; 
        }
    }
}
