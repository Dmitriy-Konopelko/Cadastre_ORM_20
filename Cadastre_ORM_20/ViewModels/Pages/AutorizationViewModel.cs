using Cadastre_ORM_20.ViewModels.Base;
using Cadastre_ORM_20.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Cadastre_ORM_20.ViewModels.Pages
{
    internal class AutorizationViewModel : ViewModel
    {
        // Пока используем общую ViewModel
        #region Переменные

        //public MainWindowViewModel MainWindowViewModel { get; set; }
        //public ObservableCollection<User> Users { get; set; }
        //public User SelectedItem { get; set; }

        //private string _newUserName;
        //public string NewUserName
        //{
        //    get => _newUserName;
            
        //    set => Set(ref _newUserName, value);
            
        //}

        //private string _newPassword_1;
        //public string NewPassword_1
        //{
        //    get => _newPassword_1;
        //    set => Set(ref _newPassword_1, value);
        //}

        //private string _newPassword_2;
        //public string NewPassword_2
        //{
        //    get => _newPassword_2;
        //    set => Set(ref _newPassword_2, value);
        //}

        #endregion

        #region Конструктор
        // отладочный
        //public AutorizationViewModel() : this(null)
        //{
        //    var users = Enumerable.Range(1, 5).Select(i => new User
        //    {
        //        Id = i,
        //        Name = $"User {i}",
        //        Password = $"12{i}",
        //        Role = 1
        //    });
        //    // создаем коллекцию на базе списка
        //    Users = new ObservableCollection<User>(users);
        //}

        // основной
        //public AutorizationViewModel(MainWindowViewModel ViewModel)
        //{
        //    //MainWindowViewModel = ViewModel;
        //    //Users = MainWindowViewModel.Users;
        //    //SelectedItem = Users.First();
        //    //NewUserName = "Vadim";
        //    //NewPassword_1 = "***";
        //    //NewPassword_2 = "****";
        //} 
        #endregion
    }
}
