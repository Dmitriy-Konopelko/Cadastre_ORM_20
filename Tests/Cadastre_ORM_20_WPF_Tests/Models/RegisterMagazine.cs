using Cadastre_ORM_20.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastre_ORM_20_WPF_Tests.Models
{
    internal class RegisterMagazine
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime EditDate { get; set; }


        //public virtual Site Site { get; set; }
        public virtual User CreateUser { get; set; }
        public virtual User EditUser { get; set; }
    }
}
