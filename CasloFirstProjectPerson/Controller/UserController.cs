using CasloFirstProjectPerson.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace CasloFirstProjectPerson.Controller
{
    public class UserController : ControllerBase
    {
        private const string USER_FILE_NAME = "Users.dat";
        public List<User> Users;
        public User CurrentUser { get; }
        public bool IsNewUser { get; } = false;

        public UserController(string userName)
        {
            if(string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Имя персонажа не может быть пустым", nameof(userName));
            }

            Users = GetUsersData();

            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            if(CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }
        }

        private List<User> GetUsersData()
        {
            return Load<List<User>>(USER_FILE_NAME) ?? new List<User>();
        }

        public void SetNewUserData(string character, int quantity = 1, int lvl = 1)
        {
            // proverka

            CurrentUser.Character = new Character(character);
            CurrentUser.Quantity = quantity;
            CurrentUser.Lvl = lvl;
            Save();
        }

        public void Save()
        {
            Save(USER_FILE_NAME, Users);
        }

    }
}
