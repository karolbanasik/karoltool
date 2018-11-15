using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDataTools.PeselTools
{
    public class Generator
    {
        public Generator() { }
        public int? YearCheck;
        public int? MonthCheck;
        public int? DayCheck;
        public Sex.SexEnum SexCheck;

        public string ValidPesel(int? year = null, int? month = null, int? day = null,
            Sex.SexEnum sex = Sex.SexEnum.Unspecified )
        {
            const int minYear = 1800;
            const int maxYear = 2299;

            if (!DateTime.TryParse($"{year}-{month}-{day}", out DateTime dt))
            {
                if (year < minYear || year > maxYear)
                {
                    throw new Exception($"Year {year} out of range year must be between {minYear} and {maxYear}");
                }
            }
            else
            {
                throw new Exception("date invalid");
            }

            var r = new Random();

            if (year == null) year = r.Next(minYear, maxYear);

            YearCheck = year;

            if (month == null)
            {
                do
                {
                    month = r.Next(1, 12);
                }
                while (day != null && !DateTime.TryParse($"{year}-{month}-{day}", out dt));
            }

            MonthCheck = month;

            //TODO: better days handling
            if (day == null)
            {
                do
                {
                    day = r.Next(1, 31);
                }
                while (!DateTime.TryParse($"{year}-{month}-{day}", out dt));
            }

            if (!DateTime.TryParse($"{year}-{month}-{day}", out dt))
            {
                throw new Exception("Cannot parse date, invalid data?");
            }

            DayCheck = day;

            if (sex == Sex.SexEnum.Unspecified) ;
            {
                int s = r.Next(1, 2);
                sex = (Sex.SexEnum)s; 
            }
            
            SexCheck = sex;



            return "";
        }
    }
}
