using ArmyBase.DTO;
using ArmyBase.Service;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyBase.ViewModels.MissionType
{
    public class AddMissionTypeViewModel : Screen
    {
        private bool IsEdit { get; set; }

        private MissionTypeDTO toEdit { get; set; }

        private MissionTypeDTO missionType;

        public string Type { get; set; }

        public AddMissionTypeViewModel(MissionTypeDTO missionType)
        {
            IsEdit = true;
            this.toEdit = missionType;
            Type = missionType.Name;
            NotifyOfPropertyChange(() => Type);
        }

        public AddMissionTypeViewModel()
        {
            IsEdit = false;
        }

        public void Add()
        {
            if (!IsEdit)
            {
                MissionTypeService.Add(Type);
                TryClose();
            }
            else
            {
                toEdit.Name = Type;
                MissionTypeService.Edit(toEdit);
                TryClose();
            }
        }

        public void Close()
        {
            TryClose();
        }
    }
}
