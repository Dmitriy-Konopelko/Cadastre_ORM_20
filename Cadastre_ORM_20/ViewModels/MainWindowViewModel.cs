using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Cadastre_ORM_20.Data;
using Cadastre_ORM_20.Infrastructure.Commands;
using Cadastre_ORM_20.ViewModels.Base;
using Cadastre_ORM_20.ViewModels.Pages;
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
            DataContext _dataContext = new DataContext();
            // все справочники будем получать из соответствующих моделей
            Users = new ObservableCollection<User>(_dataContext.Users);
            Sites = new ObservableCollection<Site>(_dataContext.Sites);

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
