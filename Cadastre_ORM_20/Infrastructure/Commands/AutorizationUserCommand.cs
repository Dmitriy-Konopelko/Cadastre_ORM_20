using Cadastre_ORM_20.Infrastructure.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Cadastre_ORM_20.Infrastructure.Commands
{
    internal class AutorizationUserCommand : Command
    {
        public override bool CanExecute(object parameter)
        {
            if (parameter != null)
                return true;
            else
                return false;
            //return !string.IsNullOrEmpty(parameter.ToString());
        }

        public override void Execute(object parameter)
        {
            MessageBox.Show("Данная команда находится в разработке!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
