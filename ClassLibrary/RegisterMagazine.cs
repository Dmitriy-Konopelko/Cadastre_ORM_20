using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class RegisterMagazine
    {
        #region Описание класса
        /*Это класс описывающий таксационный журнал содержащий данные по номеру жрнала к какому объекту он принадлежит
         кто его создатель, дату создания, дату редактирования и данные о том кто редактировал, а так же список объектов
        растительного мира анесеннызх ва данный журнал*/
        #endregion

        #region Поля класса
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime EditDate { get; set; }

        // проводники свойств
        public virtual Site Site { get; set; }
        public virtual User CreateUser { get; set; }
        public virtual User EditUser { get; set; }
        public virtual ICollection<Plant> Plants { get; set; }

        #endregion

        #region Свойства класса
       
        #endregion

        #region Конструкторы класса
        

        public RegisterMagazine()
        {
            Plants = new List<Plant>();
        }
        #endregion

        #region Методы класса
        
        #endregion

        #region События класса
        // события изменения свойств объекта
        //public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}
