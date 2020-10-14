using System;
using System.Collections.Generic;
using System.Linq;

namespace CasloFirstProjectPerson.Model
{
    [Serializable]
    public class CharacterLvlUp
    {
        public int Id { get; set; }
        public int LvlUp { get; set; }
        public int CharacterLvl { get; }
        public Dictionary<Units, int> Unites { get; }
        public int UserId { get; set; }
        public virtual User User { get; set; }

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

        public int UpLvl()
        {
            if (User.exp > 1000)
            {
                LvlUp++;
            }

            return LvlUp;
        }
    }
}
