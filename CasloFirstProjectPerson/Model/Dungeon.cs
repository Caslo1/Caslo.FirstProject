using System;

namespace CasloFirstProjectPerson.Model
{
    [Serializable]
    public class Dungeon
    {
        public int Id { get; set; }
        public int Start { get; set; }
        public int Finish { get; set; }
        public int PlayId { get; set; }
        public virtual Play Play { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public Dungeon(int start, int finish, Play play, User user)
        {
            //Проверка

            Start = start;
            Finish = finish;
            Play = play;
            User = user;
        }
    }
}