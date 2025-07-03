using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace RJ_Login_WPF.ViewModel
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        //abstract class
        //define a method to raise the event when a property has changed
        public event PropertyChangedEventHandler PropertyChanged;
        //속성이 변경될 때 발생하는 이벤트 

        public void OnPropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            //Invoke 이벤트를 발생시킴
            //PropertyChangedEventArgs: 어떤 속성이 변경되었는지 정보를 담음


        }
    }
}
