﻿using System;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace CommandingWithMvvm.ViewModels
{

    public class Binding1ViewModel : ViewModelBase
    {

        public Binding1ViewModel()
        {
            InitializeCommands();

            if (IsInDesignMode)
                Count = 3;
        }

        #region Logic

        private void InitializeCommands()
        {
            // Action that command will perform
            Action incrementAction = () => PerformIncrementCount();
            // Predicate for whether or not action is allowed to execute
            Func<bool> incrementPredicate = () => Count >= 0;

            // Set Command property to new RelayCommand Object
            IncrementCount = new RelayCommand(incrementAction, incrementPredicate);
        }

        #endregion

        #region Public Members


        public void PerformIncrementCount()
        {
            Count++;
        }


        #region Count Property (INotify Property Changed)

        /// <summary>
        /// The <see cref="Count" /> property's name.
        /// </summary>
        public const string CountPropertyName = "Count";

        private int _Count = 0;

        /// <summary>
        /// Gets the Count property.
        /// TODO Update documentation:
        /// Changes to that property's value raise the PropertyChanged event. 
        /// This property's value is broadcasted by the Messenger's default instance when it changes.
        /// </summary>

        #endregion

        public int Count
        {
            get
            {
                return _Count;
            }

            set
            {
                if (_Count == value)
                {
                    return;
                }

                var oldValue = _Count;
                _Count = value;

                // Tell the UI to refresh its predicate
                IncrementCount.RaiseCanExecuteChanged();
                // Tell the UI to refresh databinding of Count Property
                RaisePropertyChanged(CountPropertyName);

            }
        }

        /// <summary>
        /// Command that will increment the count property
        /// </summary>
        public RelayCommand IncrementCount { get; set; }

        #endregion

    }
}