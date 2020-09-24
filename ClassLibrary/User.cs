using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    internal class User
    {
        #region Описание класса
        /**/
        #endregion

        #region Поля класса
        public int Id { get; set; }                 //индитификатор учетной записи
        public string Name { get; set; }           //Имя пользователя
        public string Password { get; set; }       //Пароль
        public int Role { get; set; }              //Роль
        #endregion

        #region Свойства класса Не используем

        #endregion

        #region Конструкторы класса

        public User(string Name, string Password, int Role)
        {
            this.Name = Name;
            this.Password = Password;
            this.Role = Role;
        }

        public User() : this("Default_User", "12345", 1)
        {

        }

        public User(string Name, string Password) : this(Name, Password, 1)
        {

        }
        #endregion

        #region Методы класса
        // Метод проверяющий совпадени имени пользователя, возвращаемо значение истина если совпадает
        public bool NameCompare(string outName)
        {
            if (Name == outName)
            {
                return true;
            }
            return false;
        }
        // Метод проверяющий сопадение пароля пользователя, метод возвращает истину если пароль совпадает
        public bool PasswordCompare(string outPassword)
        {
            if (Password == outPassword)
            {
                return true;
            }
            return false;
        }
        // Метод возвращает права пользователя, возвращаемое значение число
        public int GetPermissions()
        {
            return Role;
        }

        public bool IsUserExist(IEnumerable<User> users, User newuser)
        {
            foreach (var UserExist in users)
            {
                if (newuser.Name == UserExist.Name)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region События класса

        #endregion
    }
}
