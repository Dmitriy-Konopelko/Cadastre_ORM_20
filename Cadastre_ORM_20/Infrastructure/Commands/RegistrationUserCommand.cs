using Cadastre_ORM_20.Infrastructure.Commands.Base;
using System;

namespace Cadastre_ORM_20.Infrastructure.Commands
{
    internal class RegistrationUserCommand : Command
    {
        public override bool CanExecute(object parameter)
        {
            if (parameter != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public override void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
