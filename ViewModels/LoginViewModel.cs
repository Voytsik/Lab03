using Lab02.Manager;
using Lab02.Models;
using Lab02.Tools;
using System;
using Lab02.Exceptions;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Lab02.ViewModels
{
    class LoginViewModel : INotifyPropertyChanged
    {
        public LoginModel _loginModel { get; private set; }
        private ICommand _loginCommand;
        private DateTime _birthDate;
        private string _name;
        private string _surname;
        private string _email;
        private int _age;
        private string _westernZodiac;
        private string _chineseZodiac;

        public LoginViewModel(Storage storage)
        {
            _loginModel = new LoginModel(storage);
            BirthDate = DateTime.Today.Date;
            _loginModel.UInfoChanged += UIOnDateChanged;
        }

        public ICommand LoginCommand
        {
            get
            {
                if (_loginCommand == null)
                {
                    _loginCommand = new RelayCommand<object>(LoginExecute, LoginCanExecute);
                }
                return _loginCommand;
            }
            set { _loginCommand = value; }
        }
        public DateTime BirthDate
        {
            get { return _birthDate; }
            set
            {
                _birthDate = value;
                InvokePropertyChanged("BirthDate");
            }
        }
        public string UserName
        {
            get { return _name; }
            set
            {
                _name = value;
                InvokePropertyChanged("UserName");
            }
        }
        public string UserSurname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                InvokePropertyChanged("UserSurname");
            }
        }
        public string UserEmail
        {
            get { return _email; }
            set
            {
                _email = value;
                InvokePropertyChanged("UserEmail");
            }
        }
        public int Age
        {
            get { return _age; }
            set
            {
                if (_age != value)
                {
                    _age = value;
                    InvokePropertyChanged("Age");
                }
            }
        }
        public string WesternZodiac
        {
            get { return _westernZodiac; }
            set
            {
                if (_westernZodiac != value)
                {
                    _westernZodiac = value;
                    InvokePropertyChanged("WesternZodiac");
                }
            }
        }
        public string ChineseZodiac
        {
            get { return _chineseZodiac; }
            set
            {
                if (_chineseZodiac != value)
                {
                    _chineseZodiac = value;
                    InvokePropertyChanged("ChineseZodiac");
                }
            }
        }
        public DateTime Date
        {
            get { return _birthDate; }
            set
            {
                if (_birthDate != value)
                {
                    _birthDate = value;
                    InvokePropertyChanged("Date");
                }
            }
        }
        public string EnteredName
        {
            get { return _email; }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    InvokePropertyChanged("EnteredName");
                }
            }
        }
        public string EnteredSurname
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    InvokePropertyChanged("EnteredSurname");
                }
            }
        }
        public string EnteredEmail
        {
            get { return _surname; }
            set
            {
                if (_surname != value)
                {
                    _surname = value;
                    InvokePropertyChanged("EnteredEmail");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void CheckDate(DateTime date)
        {
            var age = DateTime.Today.Date.Year - date.Date.Year;
            OperateZodiac zodiac = new OperateZodiac();
            if (zodiac.isBirthday(date.Date))
            {
                MessageBox.Show("Вітаємо з днем народження!");
            }
            try
            {
                Person TestPerson = new Models.Person();
                TestPerson.IsCorrectDateOfBirth(date);
                if(TestPerson.IsEmailValid(_email))
                {
                    MessageBox.Show("Email правильний");
                }
                else
                {
                    throw new IllegalEmailException();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            Person _mainPerson = new Person(_email, _name, _surname, date);

            _loginModel._storage.ChangeInfo(_mainPerson);
        }

        private bool LoginCanExecute(object obj)
        {
            return true;
        }

        private void LoginExecute(object obj)
        {
            CheckDate(Date);
        }

        private void InvokePropertyChanged(string propertyName)
        {
            var e = new PropertyChangedEventArgs(propertyName);
            PropertyChanged?.Invoke(this, e);
        }

        private void UIOnDateChanged(Person info)
        {
            EnteredName = info.Name;
            EnteredSurname = info.Surname;
            EnteredEmail = info.Email;
            Age = info.Age;
            WesternZodiac = info.getWesternZodiac;
            ChineseZodiac = info.getChineseZodiac;
        }
    }
}