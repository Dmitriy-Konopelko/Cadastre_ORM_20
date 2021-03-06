﻿using Cadastre_ORM_20.Infrastructure.Commands.Base;
using System;
using System.Windows;

namespace Cadastre_ORM_20.Infrastructure.Commands
{
    internal class RegistrationUserCommand : Command
    {
        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty((string)parameter);
        }

        public override void Execute(object parameter)
        {
            MessageBox.Show("Данная команда находится в разработке!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
