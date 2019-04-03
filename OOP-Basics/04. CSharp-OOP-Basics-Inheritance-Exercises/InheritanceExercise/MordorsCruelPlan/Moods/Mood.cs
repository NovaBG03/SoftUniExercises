using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MordorsCruelPlan.Moods
{
    abstract class Mood
    {
        private int happiness;


        public Mood(int happiness)
        {
            this.Happiness = happiness;
        }


        public string Name
        {
            get { return this.GetType().Name; }
        }

        public int Happiness
        {
            get { return happiness; }
            private set { happiness = value; }
        }

    }
}
