using System;

namespace Lab02.Models
{
    public class Storage
    {
        public event Action<Person> InfoChanged;
        public Person Info { get; private set; }

        public void ChangeInfo(Person info)
        {
            Info = info;
            InfoChanged?.Invoke(info);
        }
    }
}