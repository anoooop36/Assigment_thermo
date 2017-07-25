using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SampleMvvmApplication.Annotations;
using SampleMvvmApplication.Commands;

namespace SampleMvvmApplication.ViewModels
{
    public class SampleViewModel : INotifyPropertyChanged
    {

        #region Private Members

        private ObservableCollection<string> names;
        private ICommand addCommand;
        private int id;
        #endregion

        #region Properties

        public ObservableCollection<string> Names
        {
            get { return names; }
            set { names = value;}
        }

        public ICommand AddCommand
        {
            get { return addCommand; }
            set { addCommand = value; NotifyPropertyChanged("AddCommand"); }
        }
        #endregion

        #region INotifyPropertyChanged Implentation

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        //This is to notify the view that a property has changed
        #endregion

        #region Constructor
        public SampleViewModel()
        {
            Names = new ObservableCollection<string>();
            AddCommand = new RelayCommand(AddName,CanAddExecute);
        }
        #endregion

        #region Private Methods

        private bool CanAddExecute(object param)
        {
            return true;
        }

        private void AddName(object param)
        {
            Names.Add(string.Format("Name {0}",id));
            id++;
        }
        
        //There is something called CommandParameter
        //It is any property from the view that you want to pass as an input for your logic.
        //That's why the signature for AddName is AddName(object param)
        #endregion
    }
}
