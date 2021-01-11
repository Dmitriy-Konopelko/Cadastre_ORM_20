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

namespace Cadastre_ORM_20.ViewModels.Pages
{
    internal class AutorizationViewModel : ViewModel
    {
        public ObservableCollection<User> Users { get; set; }

        public AutorizationViewModel()
        {
            var users = Enumerable.Range(1, 5).Select(i => new User
            {
                Id = i,
                Name = $"User {i}",
                Password = $"12 {i}",
                Role = 1
            });
            // создаем коллекцию на базе списка
            Users = new ObservableCollection<User>(users);

        }
    }
}
