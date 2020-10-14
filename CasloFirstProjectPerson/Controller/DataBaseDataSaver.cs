using System.Collections.Generic;
using System.Linq;

namespace CasloFirstProjectPerson.Controller
{
    public class DataBaseDataSaver : IDataSaver
    {
        public List<T> Load<T>() where T : class
        {
            using (var db = new GameContext()) 
            {
                var result = db.Set<T>().Where(t => true).ToList();
                return result;
            }
        }

        public void Save<T>(List<T> item) where T : class
        {
            using (var db = new GameContext())
            {
                db.Set<T>().AddRange(item);
                db.SaveChanges();
            }
        }
    }
}
