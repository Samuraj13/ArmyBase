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
    public class SpecializationGridViewModel : Screen
    {
        public List<SpecializationDTO> Specializations { get; set; } = new List<SpecializationDTO>();
        public SpecializationGridViewModel()
        {
            Reload();
        }

        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
        }

        public void LoadAddBarrackPage()
        {
            IWindowManager manager = new WindowManager();
            AddSpecializationViewModel add = new AddSpecializationViewModel();
            manager.ShowDialog(add, null, null);
            Reload();
        }

        public void LoadModifySpecializationPage(BarrackDTO specialization)
        {
            IWindowManager manager = new WindowManager();
            ModifySpecializationViewModel modify = new ModifySpecializationViewModel(specialization);
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
            Specializations = SpecializationService.GetAll();
            NotifyOfPropertyChange(() => Specializations);
        }
    }
}
