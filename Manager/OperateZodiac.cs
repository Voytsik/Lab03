using System;
using System.Windows;

namespace Lab02.Manager
{
    class OperateZodiac
    {
        public bool isBirthday(DateTime date)
        {
            if (DateTime.Today.Date.Day == date.Date.Day && DateTime.Today.Date.Month == date.Date.Month)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string FindWestZodiac(DateTime date)
        {
            MessageBox.Show(date.Year.ToString());
            var day = date.Day;
            var month = date.Month;
            WestZodiac.WestZodiacSigns Zodiac;
            if ((month == 3 && day >= 21) || (month == 4 && day <= 20))
            {
                Zodiac = WestZodiac.WestZodiacSigns.Aries;
            }
            else if ((month == 4 && day >= 21) || (month == 5 && day <= 20))
            {
                Zodiac = WestZodiac.WestZodiacSigns.Taurus;
            }
            else if ((month == 5 && day >= 21) || (month == 6 && day <= 21))
            {
                Zodiac = WestZodiac.WestZodiacSigns.Gemini;
            }
            else if ((month == 6 && day >= 22) || (month == 7 && day <= 22))
            {
                Zodiac = WestZodiac.WestZodiacSigns.Cancer;
            }
            else if ((month == 7 && day >= 23) || (month == 8 && day <= 23))
            {
                Zodiac = WestZodiac.WestZodiacSigns.Leo;
            }
            else if ((month == 8 && day >= 24) || (month == 9 && day <= 23))
            {
                Zodiac = WestZodiac.WestZodiacSigns.Virgo;
            }
            else if ((month == 9 && day >= 24) || (month == 10 && day <= 22))
            {
                Zodiac = WestZodiac.WestZodiacSigns.Libra;
            }
            else if ((month == 10 && day >= 23) || (month == 11 && day <= 22))
            {
                Zodiac = WestZodiac.WestZodiacSigns.Scorpio;
            }
            else if ((month == 11 && day >= 23) || (month == 12 && day <= 21))
            {
                Zodiac = WestZodiac.WestZodiacSigns.Sagittarius;
            }
            else if ((month == 12 && day >= 22) || (month == 1 && day <= 20))
            {
                Zodiac = WestZodiac.WestZodiacSigns.Capricorn;
            }
            else if ((month == 1 && day >= 21) || (month == 2 && day <= 19))
            {
                Zodiac = WestZodiac.WestZodiacSigns.Aquarius;
            }
            else if ((month == 2 && day >= 20) || (month == 3 && day <= 20))
            {
                Zodiac = WestZodiac.WestZodiacSigns.Pisces;
            }
            else
            {
                return "Error!";
            }
            return Zodiac.ToString();
        }

        public string FindChineseZodiac(int year)
        {
            var modY = year % 12;
            AsianZodiac.AsianZodiacSigns Zodiac;
            switch (modY)
            {
                case 0: Zodiac = AsianZodiac.AsianZodiacSigns.Monkey; break;
                case 1: Zodiac = AsianZodiac.AsianZodiacSigns.Rooster; break;
                case 2: Zodiac = AsianZodiac.AsianZodiacSigns.Dog; break;
                case 3: Zodiac = AsianZodiac.AsianZodiacSigns.Pig; break;
                case 4: Zodiac = AsianZodiac.AsianZodiacSigns.Rat; break;
                case 5: Zodiac = AsianZodiac.AsianZodiacSigns.Ox; break;
                case 6: Zodiac = AsianZodiac.AsianZodiacSigns.Tiger; break;
                case 7: Zodiac = AsianZodiac.AsianZodiacSigns.Rabbit; break;
                case 8: Zodiac = AsianZodiac.AsianZodiacSigns.Dragon; break;
                case 9: Zodiac = AsianZodiac.AsianZodiacSigns.Snake; break;
                case 10: Zodiac = AsianZodiac.AsianZodiacSigns.Horse; break;
                case 11: Zodiac = AsianZodiac.AsianZodiacSigns.Ram; break;
                default: return "Error!";
            }
            return Zodiac.ToString();
        }
    }
}