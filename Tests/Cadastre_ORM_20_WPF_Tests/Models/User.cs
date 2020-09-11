using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastre_ORM_20.Models
{
    internal class User
    {
        #region Поля класса
        public int Id { get; set; }                 //индитификатор учетной записи
        public string Name { get; set; }           //Имя пользователя
        public string Password { get; set; }       //Пароль
        public int Role { get; set; }              //Роль
        #endregion
    }
}
