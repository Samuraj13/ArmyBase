using ArmyBase.DTO;
using ArmyBase.Service;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyBase.ViewModels.Specialization
{
    public class AddSpecializationViewModel : Screen
    {
        private bool IsEdit { get; set; }

        private SpecializationDTO toEdit { get; set; }

        public BindableCollection<EquipmentDTO> AvailableEquipment { get; set; }

        public BindableCollection<EquipmentDTO> ActualEquipment { get; set; }

        public List<EquipmentDTO> SelectedEquipment { get; set; }

        public BindableCollection<PermissionDTO> AvailablePermissions { get; set; }

        public BindableCollection<PermissionDTO> ActualPermissions { get; set; }

        public List<PermissionDTO> SelectedPermissions { get; set; }

        public string ButtonLabel { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public AddSpecializationViewModel(SpecializationDTO specialization)
        {
            AvailableEquipment = new BindableCollection<EquipmentDTO>(EquipmentService.GetAll().ToList());
            BindableCollection<EquipmentDTO> abc = new BindableCollection<EquipmentDTO>();
            foreach(var a in AvailableEquipment)
            {
                bool toDelete = false;
                foreach(var b in a.Specialization)
                {
                    if (b.Id == specialization.Id)
                    {
                        toDelete = true;
                    }
                }
                if (toDelete)
                {
                    abc.Add(a);
                }
            }
            AvailableEquipment.RemoveRange(abc);
            ActualEquipment = new BindableCollection<EquipmentDTO>(EquipmentService.GetAll().Where(x => x.Specialization.Where(y => y.Id == specialization.Id).Any()).ToList());
            
            AvailablePermissions = new BindableCollection<PermissionDTO>(PermissionService.GetAll().ToList());
            BindableCollection<PermissionDTO> abc1 = new BindableCollection<PermissionDTO>();
            foreach (var a in AvailablePermissions)
            {
                bool toDelete = false;
                foreach (var b in a.Specialization)
                {
                    if (b.Id == specialization.Id)
                    {
                        toDelete = true;
                    }
                }
                if (toDelete)
                {
                    abc1.Add(a);
                }
            }
            AvailablePermissions.RemoveRange(abc1);
            ActualPermissions = new BindableCollection<PermissionDTO>(PermissionService.GetAll().Where(x => x.Specialization.Where(y => y.Id == specialization.Id).Any()).ToList());
            IsEdit = true;
            ButtonLabel = "Edit";

            this.toEdit = specialization;
            Name = toEdit.Name;
            Description = toEdit.Description;
            NotifyOfPropertyChange(() => Name);
            NotifyOfPropertyChange(() => Description);
        }

        public AddSpecializationViewModel()
        {
            AvailableEquipment = new BindableCollection<EquipmentDTO>(EquipmentService.GetAll().ToList());
            ActualEquipment = new BindableCollection<EquipmentDTO>();
            AvailablePermissions = new BindableCollection<PermissionDTO>(PermissionService.GetAll().ToList());
            ActualPermissions = new BindableCollection<PermissionDTO>();
            IsEdit = false;
            ButtonLabel = "Add";
        }

        public void ClickPermissions()
        {
            ActualPermissions.AddRange(AvailablePermissions.Where(x => x.IsSelected).ToList());
            AvailablePermissions.RemoveRange(ActualPermissions);
            NotifyOfPropertyChange(() => AvailablePermissions);
            NotifyOfPropertyChange(() => ActualPermissions);

        }

        public void ClickBackPermissions()
        {

            AvailablePermissions.AddRange(ActualPermissions.Where(x => x.IsSelected).ToList());
            ActualPermissions.RemoveRange(AvailablePermissions);
            NotifyOfPropertyChange(() => AvailablePermissions);
            NotifyOfPropertyChange(() => ActualPermissions);

        }

        public void ClickEquipment()
        {
            ActualEquipment.AddRange(AvailableEquipment.Where(x => x.IsSelected).ToList());
            AvailableEquipment.RemoveRange(ActualEquipment);
            NotifyOfPropertyChange(() => AvailableEquipment);
            NotifyOfPropertyChange(() => ActualEquipment);

        }

        public void ClickBackEquipment()
        {

            AvailableEquipment.AddRange(ActualEquipment.Where(x => x.IsSelected).ToList());
            ActualEquipment.RemoveRange(AvailableEquipment);
            NotifyOfPropertyChange(() => AvailableEquipment);
            NotifyOfPropertyChange(() => ActualEquipment);

        }

        public void Add()
        {
            if (!IsEdit)
            {
                SelectedEquipment = ActualEquipment.ToList();
                SelectedPermissions = ActualPermissions.ToList();
                string x = SpecializationService.Add(Name, Description,SelectedEquipment,SelectedPermissions);
                if (x == null)
                {
                    TryClose();
                }
                else
                    Error = x;
            }
            else
            {
                toEdit.Name = Name;
                toEdit.Description = Description;
                SelectedEquipment = ActualEquipment.ToList();
                SelectedPermissions = ActualPermissions.ToList();
                string x = SpecializationService.Edit(toEdit, SelectedEquipment, SelectedPermissions);
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
