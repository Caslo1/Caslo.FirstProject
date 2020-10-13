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
        private const string UNIT_FILE_NAME = "Units.dat";
        private const string CHARACTER_FILE_LVL = "lvls.dat";
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
            var lvl = Unites.SingleOrDefault(l => l.Exp == units.Exp);

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
            return Load<CharacterLvlUp>(CHARACTER_FILE_LVL) ?? new CharacterLvlUp(user);
        }


        private List<Units> GetAllUnits()
        {
            return Load<List<Units>>(UNIT_FILE_NAME) ?? new List<Units>();
        }

        private void Save()
        {
            Save(UNIT_FILE_NAME, Unites);
            Save(CHARACTER_FILE_LVL, lvlUps);
        }
    }
}
