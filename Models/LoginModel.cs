using System;

namespace Lab02.Models
{
    public class LoginModel 
    {
        public readonly Storage _storage;
        public Person MainPerson { get; private set; }
        public event Action<Person> UInfoChanged;

        public LoginModel(Storage storage)
        {
            _storage = storage;
            storage.InfoChanged += OnInfoChanged;
        }

        private void OnInfoChanged(Person info)
        {
            UInfoChanged?.Invoke(info);
        }
    }
}