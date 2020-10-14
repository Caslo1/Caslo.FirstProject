using CasloFirstProjectPerson.Model;
using System.Data.Entity;

namespace CasloFirstProjectPerson.Controller
{
    class GameContext : DbContext
    {
        public GameContext() : base("DBConnection") {}

        public DbSet<Play> Plays { get; set; }
        public DbSet<Units> Units { get; set; }
        public DbSet<Dungeon> Dungeons { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<CharacterLvlUp> CharacterLvlUps { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
