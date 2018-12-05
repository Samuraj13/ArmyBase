using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyBase.ViewModels
{
    public class DeleteConfirmationViewModel : Screen
    {

        public void Yes()
        {
            TryClose(true);
        }

        public void No()
        {
            TryClose(false);
        }
    }
}
