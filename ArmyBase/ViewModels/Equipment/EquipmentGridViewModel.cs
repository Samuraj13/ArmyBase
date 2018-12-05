using ArmyBase.DTO;
using ArmyBase.Service;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyBase.ViewModels.Equipment
{
    public class EquipmentGridViewModel : Screen
    {
        public List<EquipmentDTO> Equipments { get; set; } = new List<EquipmentDTO>();
        public EquipmentGridViewModel()
        {
            Reload();
        }

        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
        }

        public void LoadAddEquipmentPage()
        {
            IWindowManager manager = new WindowManager();
            AddEquipmentViewModel add = new AddEquipmentViewModel();
            manager.ShowDialog(add, null, null);
            Reload();
        }

        public void LoadModifyEquipmentPage(EquipmentDTO equipment)
        {
            IWindowManager manager = new WindowManager();
            ModifyEquipmentViewModel modify = new ModifyEquipmentViewModel(equipment);
            manager.ShowDialog(modify, null, null);
            Reload();
        }//trzeba zrobic ModifyBarrackViewModel

        /*
         * u nas chyb nie bedzie detali zadnych
         * 
         * public void LoadDetailsBarrackPage(BarrackDTO barrack)
        {

            IWindowManager manager = new WindowManager();
            BarrackDetailsViewModel details = new BarrackDetailsViewModel(barrack);
            manager.ShowDialog(details, null, null);
            Reload();
        }*/

        public void Reload()
        {
            Equipments = EquipmentService.GetAll();
            NotifyOfPropertyChange(() => Equipments);
        }
    }
}