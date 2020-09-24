using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    internal class Site
    {
        #region Описание класса
        /*Класс описывает данные участка обследования, его номер и название, а также информацию 
         о том кто и когда создал и редактировал данный участок и список таксационных журналов 
        зарегестрированных для данного участка*/
        #endregion

        #region Поля класса
        public int Id { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime EditDate { get; set; }

        // Проводники свойств для связи с внешними таблицами данных
        public virtual User CreateUser { get; set; }
        public virtual User EditUser { get; set; }
        public virtual ICollection<RegisterMagazine> RegisterMagazines { get; set; }
        #endregion

        #region Свойства класса
        
        #endregion

        #region Конструкторы класса Убираем свойства зависимостей для модели
        public Site()
        {
            RegisterMagazines = new List<RegisterMagazine>();
        }
        #endregion

        #region Методы класса

        

        #endregion

        #region События класса
       
        #endregion
    }
}
