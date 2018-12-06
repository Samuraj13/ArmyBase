using ArmyBase.DTO;
using ArmyBase.Service;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyBase.ViewModels.Permission
{
    public class AddPermissionViewModel : Screen
    {
        private PermissionDTO toEdit { get; set; }

        public BindableCollection<RankDTO> Ranks { get; set; }

        public RankDTO SelectedRank { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int? ActualRank { get; set; }

        public bool IsEdit { get; set; }

        public AddPermissionViewModel(PermissionDTO permission)
        {
            Ranks = RankService.GetAllBindableCollection();
            IsEdit = true;

            int i = 0;
            while (ActualRank == null)
            {
                if (Ranks[i].Id == permission.MinRankId)
                {
                    ActualRank = i;
                    break;
                }
                else
                {
                    i++;
                }
            }

            this.toEdit = permission;
            Name = permission.Name;
            Description = permission.Description;
            NotifyOfPropertyChange(() => Name);
            NotifyOfPropertyChange(() => Description);
        }

        public AddPermissionViewModel()
        {
            IsEdit = false;
            Ranks = RankService.GetAllBindableCollection();
        }

        public void Add()
        {
            if (!IsEdit)
            {
                PermissionService.Add(Name, Description, SelectedRank.Id);
                TryClose();
            }
            else
            {
                toEdit.Name = Name;
                toEdit.Description = Description;
                toEdit.MinRankId = SelectedRank.Id;
                PermissionService.Edit(toEdit);
                TryClose();
            }
        }

        public void Close()
        {
            TryClose();
        }
    }
}
