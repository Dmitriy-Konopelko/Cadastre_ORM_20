using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    internal class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Проводники свойств для связи с внешними таблицами данных
        public virtual Site Site { get; set; }
        public virtual ICollection<Plant> PlantsList { get; set; }
    }
}
