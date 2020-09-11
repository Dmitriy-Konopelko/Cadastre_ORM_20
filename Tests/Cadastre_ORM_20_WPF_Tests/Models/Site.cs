using Cadastre_ORM_20_WPF_Tests.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastre_ORM_20.Models
{
    internal class Site
    {
        #region Поля класса
        public int Id { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime EditDate { get; set; }

        public virtual User CreateUser { get; set; }
        public virtual User EditUser { get; set; }
        public virtual ICollection<RegisterMagazine> RegisterMagazines { get; set; }
        #endregion
    }
}
