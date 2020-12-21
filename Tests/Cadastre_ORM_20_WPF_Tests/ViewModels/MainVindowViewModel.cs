using Cadastre_ORM_20.Models;
using Cadastre_ORM_20_WPF_Tests.Models;
using Cadastre_ORM_20_WPF_Tests.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Cadastre_ORM_20_WPF_Tests.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        // создаем коллекции объектов
        public ObservableCollection<User> Users { get; set; }
        public ObservableCollection<Site> Sites { get; set; }
        public ObservableCollection<RegisterMagazine> RegisterMagazines { get; set; }

        private Site _SelectedSite;
        #region Выбор объектов

        #region Site
        public Site SelectedSite
        {
            get => _SelectedSite;
            set => Set(ref _SelectedSite, value);
        }
        #endregion

        #endregion

        public MainWindowViewModel()
        {
            #region Инициализация заполнения справочников

            var users = Enumerable.Range(1, 5).Select(i => new User
            {
                Id = i,
                Name = $"User {i}",
                Password = $"12 {i}",
                Role = 1
            });
            // создаем коллекцию на базе списка
            Users = new ObservableCollection<User>(users);

            var registerMagazines = Enumerable.Range(1, 3).Select(i => new RegisterMagazine
            {
                Id = i,
                Number = $"RegisterMagazine_{i}",
                CreateDate = DateTime.UtcNow,
                EditDate = DateTime.UtcNow,
                CreateUser = Users.ElementAt(i),
                EditUser = Users.ElementAt(i)
            });
            // создаем коллекцию на базе списка
            RegisterMagazines = new ObservableCollection<RegisterMagazine>(registerMagazines);


            var sites = Enumerable.Range(1, 4).Select(i => new Site
            {
                Id = i,
                Number = $"10.{i}",
                Name = $"Site_{i}",
                CreateDate = DateTime.UtcNow,
                EditDate = DateTime.UtcNow,
                CreateUser = Users.ElementAt(i),
                EditUser = Users.ElementAt(i),
                RegisterMagazines = RegisterMagazines
            });
            // создаем коллекцию на базе списка
            Sites = new ObservableCollection<Site>(sites);

            #endregion
        }

        #region Вывод данных в форму



        #endregion
    }
}


