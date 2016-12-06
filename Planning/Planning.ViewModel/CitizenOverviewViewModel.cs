﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.Model;
using Planning.Model.Modules;
using System.Collections.ObjectModel;

namespace Planning.ViewModel
{
    public class CitizenOverviewViewModel: ViewModelClass
    {
        public CitizenAdmin CitizenAdmin { get; private set; }

        private TaskDescription _selectedTask;
        public TaskDescription SelectedTask
        {
            get
            {
                return _selectedTask;
            }
            set
            {
                _selectedTask = value;
                OnPropertyChanged("SelectedTask");
            }
        }




        public ObservableCollection<Citizen> Citizens
        {
            get;
        }

        public CitizenOverviewViewModel()
        {
            CitizenAdmin = new CitizenAdmin();
            Citizens = new ObservableCollection<Citizen>(CitizenAdmin.GetCitizens());
        }



    }
}
