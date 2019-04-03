using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MordorsCruelPlan.Foods
{
    abstract class Food
    {
        private int happinessPoints;


        public Food(int happinessPoints)
        {
            this.HappinessPoints = happinessPoints;
        }


        public int HappinessPoints
        {
            get { return happinessPoints; }
            private set
            {
                happinessPoints = value;
            }
        }

    }
}
