using ArmyBase.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyBase.DesignPattern.Observer
{
    public interface ISubject
    {
        void AddObserver(List<IMyObserver> o);
        void RemoveObserver(IMyObserver o);
        void InformObservers();
    }


    public interface IMyObserver
    {
        void ObserverUpdate();
    }
}
