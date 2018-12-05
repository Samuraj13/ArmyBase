using ArmyBase.DTO;
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
        private bool IsEdit { get; set; }

        private BarrackDTO toEdit { get; set; }

        public AddBarrackViewModel(BarrackDTO barrack)
        {
            IsEdit = true;
            this.toEdit = barrack;
            Name = barrack.Name;
            Capacity = barrack.Capacity;
            NotifyOfPropertyChange(() => Name);
            NotifyOfPropertyChange(() => Capacity);
        }

        public AddBarrackViewModel()
        {
            IsEdit = false;
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public void Add()
        {
            if (!IsEdit)
            {
                BarrackService.Add(Name, Capacity);
                TryClose();
            }
            else
            {
                toEdit.Name = Name;
                toEdit.Capacity = Capacity;
                BarrackService.Edit(toEdit);
                TryClose();
            }
        }

        public void Close()
        {
            TryClose();
        }

    }
}
