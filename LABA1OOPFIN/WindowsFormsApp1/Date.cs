using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Date
    {
        private uint day;
        private uint month;
        private uint year;
        
        public Date ()
        {
            this.day = 1;
            this.month = 1;
            this.year = 1;
        }

        public uint get_day()
        {
            return this.day;
        }
        public uint get_month()
        {
            return this.month;
        }
        public uint get_year()
        {
            return this.year;
        }
        public bool set_day(uint d)
        {
            if (d <= 31 && d >= 1)
            {
                this.day = d;
                return true;
            } else
            {
                return false;
            }
        }
        public bool set_month(uint d)
        {
            if (d <= 12 && d >= 1)
            {
                this.month = d;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool set_year(uint d)
        {
            if (d > 0)
            {
                this.year = d;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void plus_date(int plus)
        {
            DateTime dd = new DateTime((int)this.year, (int)this.month, (int)this.day);
            dd = dd.AddDays(plus);
            this.day = (uint)dd.Day;
            this.month = (uint)dd.Month;
            this.year = (uint)dd.Year;
        }

        public void minus_date(int plus)
        {
            DateTime dd = new DateTime((int)this.year, (int)this.month, (int)this.day);
            dd = dd.AddDays(-(int)plus);
            this.day = (uint)dd.Day;
            this.month = (uint)dd.Month;
            this.year = (uint)dd.Year;
        }

        public bool is_vis()
        {
            if ((int)this.year % 4 == 0)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public int compare_dates(Date d1, Date d2)
        {
            DateTime dd1 = new DateTime((int)d1.year, (int)d1.month, (int)d1.day);
            DateTime dd2 = new DateTime((int)d2.year, (int)d2.month, (int)d2.day);
            if (dd1 < dd2)
            {
                return -1;
            } else if (dd1 == dd2)
            {
                return 0;
            } else
            {
                return 1;
            }
        }

        public int dates_difference(Date d1, Date d2)
        {
            DateTime dd1 = new DateTime((int)d1.year, (int)d1.month, (int)d1.day);
            DateTime dd2 = new DateTime((int)d2.year, (int)d2.month, (int)d2.day);
            TimeSpan res = dd1 - dd2;
            return (int)res.TotalDays;
        }
    }
}
