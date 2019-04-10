using System;
using Lab02.Tools;
using Lab02.Manager;
using Lab02.Exceptions;
using System.Text.RegularExpressions;
using System.Windows;

namespace Lab02.Models
{
    public class Person : BaseViewModel
    {
        private string _name;
        private string _surname;
        private string _email;
        private DateTime _birthdayDate = DateTime.Today ;
        private readonly bool _isAdult;
        private readonly string _westernZodiac;
        private readonly string _chineseZodiac;
        private readonly bool _isBirthday;
        const string pattern = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                _surname = value;
                OnPropertyChanged("Surname");
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }
        public DateTime DateOfBirth
        {
            get
            {
                return _birthdayDate;
            }
            set
            {
                _birthdayDate = value;
                OnPropertyChanged("DateOfBirth");
            }
        }
        public int Age { get; set; }
        public bool getIsAdult => _isAdult;
        public string getWesternZodiac => _westernZodiac;
        public string getChineseZodiac => _chineseZodiac;
        public bool getIsBirthdayToday => _isBirthday;

        public Person()
        {
        }

        public Person(string email, string name, string surname) : this(email, name, surname, DateTime.Today)
        {
        }
        public Person(string name, string surname, DateTime dateOfBirth) : this("", name, surname, dateOfBirth)
        {
        }
        public Person(string email, string name, string surname, DateTime dateOfBirth)
        {
            Email = email;
            Name = name;
            Surname = surname;
            DateOfBirth = dateOfBirth;
            OperateZodiac zodiac = new OperateZodiac();
            _westernZodiac = zodiac.FindWestZodiac(DateOfBirth);
            _chineseZodiac = zodiac.FindChineseZodiac(DateOfBirth.Year);
            _isBirthday = zodiac.isBirthday(DateOfBirth);
            if (DateTime.Today > DateOfBirth)
            {
                if (DateTime.Today.Month > DateOfBirth.Month)
                {
                    Age = DateTime.Today.Year - DateOfBirth.Year;
                }
                else if (DateTime.Today.Month == DateOfBirth.Month && DateTime.Today.Day > DateOfBirth.Day)
                {
                    Age = DateTime.Today.Year - DateOfBirth.Year;
                }
                else if (DateTime.Today.Month == DateOfBirth.Month && DateTime.Today.Day == DateOfBirth.Day)
                {
                    Age = DateTime.Today.Year - DateOfBirth.Year;
                }
                else
                {
                    Age = DateTime.Today.Year - DateOfBirth.Year - 1;
                }
            }
            else
            {
                Age = 0;
            }
            _isAdult = CalcAdult();
        }

        public void IsCorrectDateOfBirth(DateTime date)
        {
            int age = DateTime.Today.Year - date.Year;

            if (date > DateTime.Today)
                throw new IsNotBirthException();
            else if (age > 135)
                throw new IsDeadException();
        }

        public bool IsEmailValid(string emailaddress)
        {
            if (Regex.IsMatch(emailaddress, pattern, RegexOptions.IgnoreCase))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool CalcAdult()
        {
            int age = DateTime.Today.Year - DateOfBirth.Year;
            if (age > 17)
                return true;
            return false;
        }
    }
}