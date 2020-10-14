using System;

namespace CasloFirstProjectPerson.Model
{
    [Serializable]
    public class User
    {
        public int Id { get; set; }
        #region Свойства
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Персонаж
        /// </summary>
        public Character Character { get; set; }
        /// <summary>
        /// Количество
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// Уровень
        /// </summary>
        public int Lvl { get; set; }
        /// <summary>
        /// Опыт
        /// </summary>
        public int exp { get; set; }
        #endregion

        /// <summary>
        /// Создать новый аккаунт
        /// </summary>
        /// <param name="name"> Имя. </param>
        /// <param name="character"> Персонаж. </param>
        /// <param name="quantity"> Количество. </param>
        /// <param name="lvl"> Уровень. </param>
        public User(string name,
                    Character character,
                    int quantity,
                    int lvl)
        {
            #region Проверка входных данных
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя персонажа не может быть пустым. ", nameof(name));
            }

            if(character == null)
            {

            }

            if(quantity <= 0 && quantity >10)
            {
                throw new ArgumentNullException("Количество персонажа не может быть больше 10.", nameof(quantity));
            }

            if(lvl < 0 && lvl > 100)
            {
                throw new ArgumentNullException("Уровень персонажа не может быть нулевым.", nameof(lvl));
            }
            #endregion

            Name = name;
            Character = character;
            Quantity = quantity;
            Lvl = lvl;
        }

        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя персонажа не может быть пустым. ", nameof(name));
            }

            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
