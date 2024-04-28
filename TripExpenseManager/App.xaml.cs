using TripExpenseManager.Services;

namespace TripExpenseManager
{
    public partial class App : Application
    {
        private readonly SeeDataService _seeDataService;

        public App(SeeDataService seeDataService)
        {
            InitializeComponent();

            MainPage = new MainPage();
            _seeDataService = seeDataService;
        }
        protected override async void OnStart()
        {
            base.OnStart();
            await _seeDataService.SeedDataAsync();
        }
    }
}
