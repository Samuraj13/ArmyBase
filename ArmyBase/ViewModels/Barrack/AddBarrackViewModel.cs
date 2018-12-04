using ArmyBase.Service;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyBase.ViewModels.Barrack
{
    public class AddBarrackViewModel : Screen
    {
        public string Name { get; set; }

        public int Capacity { get; set; }

        public void Add()
        {
            BarrackService.Add(Name,Capacity);
            TryClose();
        }

        public void Close()
        {
            TryClose();
        }
    }
}
