using System;

namespace CasloFirstProjectPerson.Model
{
    [Serializable]
    public class Units
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Exp { get; set; }
        public int ExpOneUnit { get; set; }

        public Units(string name, int exp) : this(name, exp, 0) { }

        public Units(string name, int exp, int exponeunit)
        {
            //TODO: Проверка

            Name = name;
            Exp = exp;
            ExpOneUnit = exponeunit;
        }
    }
}
