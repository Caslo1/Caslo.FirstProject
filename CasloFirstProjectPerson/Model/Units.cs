using System;

namespace CasloFirstProjectPerson.Model
{
    [Serializable]
    public class Units
    {
        public string Name { get; }
        public int Exp { get; }
        public int ExpOneUnit { get; }

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
