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
