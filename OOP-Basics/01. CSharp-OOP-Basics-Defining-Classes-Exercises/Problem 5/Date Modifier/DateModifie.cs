using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Date_Modifier
{
    public class DateModifie
    {
        private DateTime startDate;
        private DateTime endDate;
        private int dateDifference;


        public DateModifie()
        {
            this.dateDifference = -1;
        }
        

        public DateTime StartDate
        {
            get { return this.startDate; }
            set { this.startDate = value; }
        }

        public DateTime EndDate
        {
            get { return this.endDate; }
            set { this.endDate = value; }
        }

        public int DateDifference
        {
            get { return this.dateDifference; }
            set { this.dateDifference = value; }
        }


        public int DifferenceInDays(string startDate, string endDate)
        {
            this.StartDate = Convert.ToDateTime(startDate);
            this.EndDate = Convert.ToDateTime(endDate);

            DateDifference = (EndDate.Date - StartDate.Date).Days;

            DateDifference = Math.Abs(DateDifference);

            return DateDifference;
        }
    }
}
