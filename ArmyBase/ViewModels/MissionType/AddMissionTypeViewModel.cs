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

        public string ButtonLabel { get; set; }

        public AddMissionTypeViewModel(MissionTypeDTO missionType)
        {
            IsEdit = true;
            ButtonLabel = "Edit";
            this.toEdit = missionType;
            Type = missionType.Name;
            NotifyOfPropertyChange(() => Type);
        }

        public AddMissionTypeViewModel()
        {
            IsEdit = false;
            ButtonLabel = "Add";
        }

        public void Add()
        {
            if (!IsEdit)
            {
                string x = MissionTypeService.Add(Type);
                if (x == null)
                {
                    TryClose();
                }
                else
                    Error = x;
            }
            else
            {
                toEdit.Name = Type;
                string x = MissionTypeService.Edit(toEdit);
                if (x == null)
                {
                    TryClose();
                }
                else
                    Error = x;
            }
        }

        public void Close()
        {
            TryClose();
        }

        private string error;

        public string Error
        {
            get { return error; }
            set
            {
                error = value;
                NotifyOfPropertyChange(() => Error);
            }
        }
    }
}
