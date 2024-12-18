﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TripExpenseManager.States
{
    public class AppState : INotifyPropertyChanged
    {
        //public event EventHandler<string> SelectedMenuItemChanged;
        public event PropertyChangedEventHandler? PropertyChanged;

        public string SelectedMenuItem { get; private set; } = AppConstants.MenuItems.Home;
        public string PageTitle => SelectedMenuItem switch
        {
            AppConstants.MenuItems.Home => AppConstants.AppName,
            _ => SelectedMenuItem
        };
        private string _innerPageTitle = string.Empty;

        public string InnerPageTitle
        {
            get => _innerPageTitle;
            private set
            {
                _innerPageTitle = value;
                // Notify(nameof(InnerPageTitle));
                Notify();
            }
        }

        public TabBarItem[] TabBarItems { get; set; } = Array.Empty<TabBarItem>();

        public void AddTabBarItems(params TabBarItem[] tabBarItems)
        {
            TabBarItems = tabBarItems;
            Notify(nameof(TabBarItems));
        }

        public void NoTabBarItems()
        {
            AddTabBarItems(Array.Empty<TabBarItem>());
        }
        public void SetSelectedMenuItem(string pageName)
        {
            SelectedMenuItem = pageName;
            //SelectedMenuItemChanged?.Invoke(this, pageName);
            Notify(nameof(SelectedMenuItem));
        }

        public void SetInnerPageTitle(string pageTitle)
        {
            InnerPageTitle = pageTitle;
        }
       

        private void Notify([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
