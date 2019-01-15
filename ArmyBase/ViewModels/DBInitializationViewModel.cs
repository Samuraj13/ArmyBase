using ArmyBase.Models;
using ArmyBase.Models.Initializer;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ArmyBase.ViewModels
{
    public class DBInitializationViewModel : Screen
    {
        private readonly ArmyBaseContext context;

        public Visibility DbNotCreated { get; set; }

        public Visibility IsInitClicked { get; set; }

        public bool WithSeed { get; set; }

        public DBInitializationViewModel(ArmyBaseContext context)
        {
            this.context = context;
            DbNotCreated = Visibility.Visible;
            IsInitClicked = Visibility.Hidden;
        }

        public void InitDB()
        {
            if (context.Database.Exists())
                TryClose();

            Task.Run(() => { CreatDB(); TryClose(); });
            ReloadGrid();
        }

        public void CreatDB()
        {
            context.Database.Create();
            if(WithSeed)
                ArmyBaseDBInitializer.Seed(context);
        }

        public void ReloadGrid()
        {
            DbNotCreated = Visibility.Hidden;
            IsInitClicked = Visibility.Visible;
            NotifyOfPropertyChange(() => DbNotCreated);
            NotifyOfPropertyChange(() => IsInitClicked);
        }

        public void Exit()
        {
            Application.Current.Shutdown();
        }
    }
}
