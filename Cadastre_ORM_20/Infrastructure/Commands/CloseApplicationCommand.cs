using Cadastre_ORM_20.Infrastructure.Commands.Base;
using System;
using System.Windows;

namespace Cadastre_ORM_20.Infrastructure.Commands
{
    internal  class CloseApplicationCommand : Command
    {
        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter) => Application.Current.Shutdown();
    }
}
