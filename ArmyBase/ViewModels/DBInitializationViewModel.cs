using ArmyBase.Models;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ArmyBase.ViewModels
{
    public class DBInitializationViewModel : Screen
    {
        private readonly ArmyBaseContext context;

        public Visibility DbNotCreated { get; set; }

        public Visibility IsInitClicked { get; set; }

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

            DbNotCreated = Visibility.Hidden;
            IsInitClicked = Visibility.Visible;
            NotifyOfPropertyChange(() => DbNotCreated);
            NotifyOfPropertyChange(() => IsInitClicked);
            CreatDB();
            return;
        }

        public void CreatDB()
        {
            context.Database.Create();
        }
    }
}
