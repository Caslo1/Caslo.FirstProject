using CasloFirstProjectPerson.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace CasloFirstProjectPerson.Controller
{
    public class ExpController : ControllerBase
    {
        private readonly User user;

        public List<Units> Unites { get; }
        public CharacterLvlUp lvlUps { get; }
        
        public ExpController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Пользователь не должен быть пустым ", nameof(user));

            Unites = GetAllUnits();

            lvlUps = GetLvl();
        }

        public void Add(Units units, int exp)
        {
            var lvl = Unites.FirstOrDefault(l => l.Exp == units.Exp);

            if(lvl == null)
            {
                Unites.Add(units);
                lvlUps.Add(units, exp);
                Save();
            }
            else
            {
                Unites.Add(lvl);
                Save();
            }
        }
        private CharacterLvlUp GetLvl()
        {
            return Load<CharacterLvlUp>().FirstOrDefault() ?? new CharacterLvlUp(user);
        }


        private List<Units> GetAllUnits()
        {
            return Load<Units>() ?? new List<Units>();
        }

        private void Save()
        {
            Save(Unites);
            Save(new List<CharacterLvlUp>() { lvlUps});
        }
    }
}