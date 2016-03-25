using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DataTransfer5
{
    public class AppData
    {
        public AppData()
        {
            InfoCollection = new ObservableCollection<InformationViewModel>();
        }

        public IList<InformationViewModel> InfoCollection { private set; get; }

        public InformationViewModel CurrentInfo { set; get; }
    }
}
