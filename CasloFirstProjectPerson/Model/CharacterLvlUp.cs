using System;
using System.Collections.Generic;
using System.Linq;

namespace CasloFirstProjectPerson.Model
{
    [Serializable]
    public class CharacterLvlUp
    {
        public int LvlUp { get; }
        public int CharacterLvl { get; }
        public Dictionary<Units, int> Unites { get; }
        public User User { get; }

        public CharacterLvlUp(User user)
        {
            User = user ?? throw new ArgumentNullException("Имя пользователя не может быть пустым ", nameof(user));

            Unites = new Dictionary<Units, int>();

            CharacterLvl = User.Lvl;

            LvlUp = CharacterLvl + 1;
        }

        public void Add(Units units, int exp)
        {
           var unit = Unites.Keys.FirstOrDefault(f => f.Exp.Equals(units.Exp));

           if(unit == null)
           {
                Unites.Add(units, exp);
           }
           else
           {
                Unites[unit] += exp;
           }
        }
    }
}
