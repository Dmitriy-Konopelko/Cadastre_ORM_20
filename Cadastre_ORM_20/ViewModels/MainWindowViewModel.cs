using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Cadastre_ORM_20.Infrastructure.Commands;
using Cadastre_ORM_20.ViewModels.Base;

namespace Cadastre_ORM_20.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        #region Заголовок окна
        private string _Title = "Кадастр объектов растительного мира";
        /// <summary>
        /// Заголовок окна
        /// </summary>
        public string Title
        {
            get => _Title;
            //set
            //{
            //    // 1 вариант присовения
            //    if (Equals(_Title, value)) return;
            //    _Title = value;
            //    OnPropertyChanged();
            //    // 2 вариант присовения
            //    Set(ref _Title, value);
            //}
            // 3 вариант присвоения
            set => Set(ref _Title, value);
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
        public ICommand CloseApplicationCommand { get; }

        private void OnCloseApplicationCommandExecuted(object p)
        {
            Application.Current.Shutdown();
        }

        private bool CanCloseApplicationCommandExecute(object p) => true; 
        #endregion

        #endregion

        public MainWindowViewModel()
        {
            #region Команды

            CloseApplicationCommand = new LamdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);
            
            #endregion

        }
    }
}
