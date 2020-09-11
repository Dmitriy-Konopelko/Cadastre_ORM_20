using Cadastre_ORM_20.Models;
using Cadastre_ORM_20_WPF_Tests.Models;
using Cadastre_ORM_20_WPF_Tests.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastre_ORM_20_WPF_Tests.ViewModels
{
    internal class MainVindowViewModel : ViewModel
    {
        // создаем коллекции объектов
        public ObservableCollection<User> Users { get; }
        public ObservableCollection<Site> Sites { get; }
        public ObservableCollection<RegisterMagazine> RegisterMagazines { get; }

        public MainVindowViewModel()
        {
            var Users = Enumerable.Range(1, 5).Select(i => new User
            {
                Id = i,
                Name = $"User {i}",
                Password = $"12 {i}",
                Role = 1
            });

            var RegisterMagazines = Enumerable.Range(1, 3).Select(i => new RegisterMagazine
            {
                Id = i,
                Number = $"RegisterMagazine_{i}",
                CreateDate = DateTime.Now,
                EditDate = DateTime.Now,
                CreateUser = Users.ElementAt(i),
                EditUser = Users.ElementAt(i)
            });

            var Sites = Enumerable.Range(1, 4).Select(i => new Site
            {
                Id = i,
                Number = $"10.{i}",
                Name = $"Site_{i}",
                CreateDate = DateTime.Now,
                EditDate = DateTime.Now,
                CreateUser = Users.ElementAt(i),
                EditUser = Users.ElementAt(i)
            });
        }
        
    }
}
