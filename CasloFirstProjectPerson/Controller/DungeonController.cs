using CasloFirstProjectPerson.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace CasloFirstProjectPerson.Controller
{
    public class DungeonController : ControllerBase
    {
        private readonly User user;
        public List<Dungeon> Dungeons { get; }
        public List<Play> Plays { get; }
    public DungeonController(User user)
        {
            this.user = user ?? throw new ArgumentNullException(nameof(user));

            Dungeons = GetAllDungeons();
            Plays = GetAllPlays();
        }

        private List<Play> GetAllPlays()
        {
            return Load<Play>() ?? new List<Play>();
        }

        public void Add(Play play, int begin, int end)
        {
            var playes = Plays.SingleOrDefault(p => p.Name == play.Name);

            if(playes == null)
            {
                Plays.Add(play);

                var dungeon = new Dungeon(begin, end, play, user);
                Dungeons.Add(dungeon);
            }
            else
            {
                var dungeon = new Dungeon(begin, end, play, user);
                Dungeons.Add(dungeon);
            }

            Save();
        }

        private List<Dungeon> GetAllDungeons()
        {
            return Load<Dungeon>() ?? new List<Dungeon>();
        }

        private void Save()
        {
            Save(Dungeons);
            Save(Plays);
        }
    }
}
