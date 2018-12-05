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
        public string Type { get; set; }

        private MissionTypeDTO missionType { get; set; }

        public AddMissionTypeViewModel(MissionTypeDTO missionType)
        {
            this.missionType = missionType;
        }

        public AddMissionTypeViewModel()
        {

        }

        public void Add()
        {
            MissionTypeService.Add(Type);
            TryClose();
        }

        public void Close()
        {
            TryClose();
        }
    }
}
