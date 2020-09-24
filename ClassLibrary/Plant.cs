using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    internal abstract class Plant
    {
        #region Описание класса
        /*По сути это абстрактный класс содержащий общие для всех объектов свойства поля и методы вопрос необходимости создания проводников свойств в данном классе*/
        #endregion

        #region Поля класса
        public int Id { get; set; }
        public string Number { get; set; }
        public string PlantType { get; set; }
        public string Species { get; set; }
        public string Characteristic { get; set; }
        public string Cause { get; set; }
        public string Proposal { get; set; }
        public bool Natural_Monument { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime EditDate { get; set; } = DateTime.Now;

        // проводники свойств
        public virtual RegisterMagazine RegisterMagazines { get; set; }
        public virtual User CreateUser { get; set; }
        public virtual User EditUser { get; set; }
        public virtual Group GroupNumber { get; set; }
        #endregion

        #region Свойства класса

        #endregion

        #region Конструкторы класса

        #endregion

        #region Методы класса

        #endregion

        #region События класса

        #endregion
    }
}
