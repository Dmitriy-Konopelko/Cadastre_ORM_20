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
using Cadastre_ORM_20.Views.Windows;
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

        #region Переменные для ViewModels

        public AutorizationViewModel autorizationViewModel { get; set; }
        // создаем коллекции объектов
        public ObservableCollection<User> Users { get; set; }
        public ObservableCollection<Site> Sites { get; set; }
        public ObservableCollection<RegisterMagazine> RegisterMagazines { get; set; }

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


        #region Блок свойств

        private string _newUserName;
        public string NewUserName
        {
            get => _newUserName;

            set => Set(ref _newUserName, value);

        }

        private string _newPassword_1;
        public string NewPassword_1
        {
            get => _newPassword_1;
            set => Set(ref _newPassword_1, value);
        }

        private string _newPassword_2;
        public string NewPassword_2
        {
            get => _newPassword_2;
            set => Set(ref _newPassword_2, value);
        } 
        #endregion

        #region Выбор объектов
        private Site _selectedSite;
        private User _selectedUserItem;
        #region Site
        public Site SelectedSite
        {
            get => _selectedSite;
            set => Set(ref _selectedSite, value);
        }

        public User SelectedUserItem
        {
            get => _selectedUserItem;
            set => Set(ref _selectedUserItem, value);
        }

        #endregion

        #endregion

       
        public MainWindowViewModel()
        {
            #region Инициализация переменных и заполнения справочников
            
            var dataContext = new DataContext();

            // все справочники будем получать из соответствующих моделей
            Users = new ObservableCollection<User>(dataContext.Users);
            Sites = new ObservableCollection<Site>(dataContext.Sites);

            autorizationViewModel = new AutorizationViewModel(this);

            NewUserName = "Vadim";
            NewPassword_1 = "***";
            NewPassword_2 = "****";

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
