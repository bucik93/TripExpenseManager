using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripExpenseManager.Models
{
    public readonly record struct  TabBarItem(string Icon, Action? OnTap) 
    {
    }
}
