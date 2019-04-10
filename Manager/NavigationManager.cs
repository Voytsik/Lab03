﻿using Lab02.Models;

namespace Lab02.Manager
{
    class NavigationManager
    {
        private static NavigationManager _instance;
        private static object _lock = new object();
        private NavigationModel _navigationModel;

        public static NavigationManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        _instance = new NavigationManager();
                    }
                }
                return _instance;
            }
        }

        public void Initialize(NavigationModel navigationModel)
        {
            _navigationModel = navigationModel;
        }

        public void Navigate()
        {
            _navigationModel?.Navigate();
        }
    }
}