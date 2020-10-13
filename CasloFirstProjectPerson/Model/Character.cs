using System;

namespace CasloFirstProjectPerson.Model
{
    [Serializable]
    public class Character
    {
        public string Name { get; set; }
        public Character(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя персонажа не может быть пустым. ", nameof(name));
            }

            Name = name;

        }

        public override string ToString()
        {
            return Name;
        }
    }
}
