using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripExpenseManager.Extensions
{
    //navigationManager.Uri -> http://0.0.0.0/trips/add
    //navigationManager.BaseUri -> http://0.0.0.0/
    //GetCurrentPageUrl -> /trips/add
    public static class NavigationManagerExtensions
    {
        public static string GetCurrentPageUrl(this NavigationManager navigationManager) =>
        
            $"/{navigationManager.Uri.Replace(navigationManager.BaseUri, string.Empty).TrimStart('/')}";
        
        public static void GoToInnerPage(this NavigationManager navigationManager, string innerPageUrl)
        {
            navigationManager.NavigateTo(innerPageUrl, new NavigationOptions
            {
                HistoryEntryState = navigationManager.GetCurrentPageUrl()
            });
        }

        public static void GoBack(this NavigationManager  navigationManager, string? fallback = "/home")
        {
            var previousPageUrl = navigationManager.HistoryEntryState ?? fallback;
            navigationManager.NavigateTo(previousPageUrl, new NavigationOptions
            {
                HistoryEntryState = null,
                ReplaceHistoryEntry = true
            });
        }
    }
}
