using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using MiRMWPFDesktopUserInterface.EventModels;

namespace MiRMWPFDesktopUserInterface.ViewModels
{
    public class ShellViewModel:Conductor<object>, IHandle<LogOnEvent>
    {
        private IEventAggregator _events;
        private SalesViewModel _salesVM;
        private SimpleContainer _container;
        public ShellViewModel( IEventAggregator events, SalesViewModel salesVM,
            SimpleContainer container)
        {
            _events = events;
            _salesVM = salesVM;
            _container = container;
            _events.Subscribe(this); //used to remember who's subscribing and then send them to all subscribers.
            ActivateItem(_container.GetInstance<LoginViewModel>()); // not a singleton but gets an instance per request. 

        }

        //triggers from successfull login.
        public void Handle(LogOnEvent message)
        {
            ActivateItem(_salesVM);
        }
    }
}
