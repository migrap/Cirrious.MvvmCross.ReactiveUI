using Cirrious.CrossCore;
using ReactiveUI;
using System;

namespace Cirrious.MvvmCross.ViewModels {
    public abstract class MvxReactiveViewModel : MvxViewModel, IReactiveNotifyPropertyChanged<IReactiveObject>, IHandleObservableErrors, IReactiveObject {
        private readonly MvxReactiveObject _mvxro = new MvxReactiveObject();

        public IObservable<IReactivePropertyChangedEventArgs<IReactiveObject>> Changed {
            get { return _mvxro.Changed; }
        }

        public IObservable<IReactivePropertyChangedEventArgs<IReactiveObject>> Changing {
            get { return _mvxro.Changing; }
        }

        public IObservable<Exception> ThrownExceptions {
            get { return _mvxro.ThrownExceptions; }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public void RaisePropertyChanging(PropertyChangingEventArgs args) {
            _mvxro.RaisePropertyChanging(args.PropertyName);
        }

        public IDisposable SuppressChangeNotifications() {
            return _mvxro.SuppressChangeNotifications();
        }

        public TService GetService<TService>() where TService : class {
            return Mvx.Resolve<TService>();
        }
    }
}
