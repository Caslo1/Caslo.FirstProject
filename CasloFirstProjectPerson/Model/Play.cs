using System;
using System.Collections.Generic;

namespace CasloFirstProjectPerson.Model
{
    [Serializable]
    public class Play
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int QuantityUnits { get; set; }
        public virtual ICollection<Dungeon> Dungeons { get; set; }
        public Play() { }

        public Play(string name, int quantityunits)
        {
            //Проверка

            Name = name;
            QuantityUnits = quantityunits;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
