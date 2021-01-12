using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastre_ORM_20.Data
{
    public class DataContext
    {
        public ObservableCollection<User> Users { get; set; }
        public ObservableCollection<Site> Sites { get; set; }

        public DataContext()
        {
            var users = Enumerable.Range(1, 5).Select(i => new User
            {
                Id = i,
                Name = $"User {i}",
                Password = $"12{i}",
                Role = 1
            });
            // создаем коллекцию на базе списка
            Users = new ObservableCollection<User>(users);

            var registerNumber = 1;

            var registerMagazines = Enumerable.Range(1, 3).Select(i => new RegisterMagazine
            {
                Id = i,
                Number = $"RegisterMagazine_{registerNumber++}",
                CreateDate = DateTime.UtcNow,
                EditDate = DateTime.UtcNow,
                CreateUser = Users.ElementAt(i),
                EditUser = Users.ElementAt(i)
            });

            var sites = Enumerable.Range(1, 4).Select(i => new Site
            {
                Id = i,
                Number = $"10.{i}",
                Name = $"Site_{i}",
                CreateDate = DateTime.UtcNow,
                EditDate = DateTime.UtcNow,
                CreateUser = Users.ElementAt(i),
                EditUser = Users.ElementAt(i),
                RegisterMagazines = new ObservableCollection<RegisterMagazine>(registerMagazines)
            });
            // создаем коллекцию на базе списка
            Sites = new ObservableCollection<Site>(sites);
        }

    }
}
