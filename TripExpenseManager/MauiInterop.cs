using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripExpenseManager
{
    public class MauiInterop
    {
        private readonly AppViewModel _appViewModel;

        public MauiInterop(AppViewModel appViewModel)
        {
            _appViewModel = appViewModel;
        }

        public void ShowLoader() => _appViewModel.ToggleIsBusy(true);
        public void HideLoader() => _appViewModel.ToggleIsBusy(false);

        public async Task ShowErrorAlertAsync(string message, string? title = "Error") =>
            await App.Current.MainPage.DisplayAlert(title, message, "Ok");

        public async Task ShowSuccesAlertAsync(string message, string? title = "Success") =>
          await App.Current.MainPage.DisplayAlert(title, message, "Ok");
    }
}
