using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Cadastre_ORM_20.Infrastructure.Commands;
using Cadastre_ORM_20.ViewModels.Base;
using ClassLibrary;

namespace Cadastre_ORM_20.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        #region Переменные отвечающие за локализацию программы
        /// <summary>
        /// Заголовок окна
        /// </summary>
        private string _title = "Кадастр объектов растительного мира";
       
        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }
        
        #endregion

        #region Статус програмы
        /// <summary>Статус программы</summary>
        private string _Status = "Готов!";
        /// <summary>Статус программы</summary>
        /// 
        public string Status
        {
            get => _Status;
            set => Set(ref _Status, value);
        }
        #endregion

        #region Команды

        #region CloseApplicationCommand
        // Старый вариант сохранено для примера работы с командами, по новому методу командывынесены в отдельные файли и привязаны через ресурсы
        // Создание параметров для команды закрытия приложения
        //public ICommand CloseApplicationCommand { get; }
        //private void OnCloseApplicationCommandExecuted(object p)
        //{
        //    Application.Current.Shutdown();
        //}
        //private bool CanCloseApplicationCommandExecute(object p) => true;
        #endregion

        #endregion

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
            // создаем коллекцию на базе списка
            //RegisterMagazines = new ObservableCollection<RegisterMagazine>(registerMagazines);


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

            #endregion

            #region Команды
            // Создание команды закрытия приложения
            //CloseApplicationCommand =
            //    new LamdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);
            // Старый вариант сохранено для примера работы с командами, по новому методу командывынесены в отдельные файли и привязаны через ресурсы

            #endregion
        }

        #region Вывод данных в форму



        #endregion


    }
}
