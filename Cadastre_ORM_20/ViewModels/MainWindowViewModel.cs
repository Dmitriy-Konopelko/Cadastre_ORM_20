using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
