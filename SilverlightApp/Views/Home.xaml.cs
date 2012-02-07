using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using SilverlightApp.UnityDataService;

namespace SilverlightApp
{
    public partial class Home : Page, INotifyPropertyChanged
    {
        private DataServiceClient _client;
        private ObservableCollection<LiquidsDataContract> liquidsDataContracts;
        public ObservableCollection<LiquidsDataContract> LiquidsDataContracts
        {
            get { return liquidsDataContracts ?? (liquidsDataContracts = new ObservableCollection<LiquidsDataContract>()); }
            set 
            { 
                liquidsDataContracts = value;
                OnPropertyChanged("LiquidsDataContracts");
            }
        }


        public Home()
        {
            _client = new DataServiceClient();
            _client.GetLiquidsLevelCompleted += GetLiquidsLevelCompleted;
            _client.ReallyLongDataPullCompleted += ReallyLongDataPullCompleted;
            InitializeComponent();
        }

        private void ReallyLongDataPullCompleted(object sender, ReallyLongDataPullCompletedEventArgs e)
        {
            if(e.Result.IsSuccess)
            {
                LiquidsDataContracts = e.Result.Response.Data;
                dataGrid1.ItemsSource = LiquidsDataContracts;
                lblTankInfo.Content = "";
                lblEditWellInfo.Visibility = Visibility.Visible;
                btnEditWellInfo.Visibility = Visibility.Visible;
                
            }
            else
            {
                lblTankInfo.Content = "An error occured: " + e.Result.Error;
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void GetLiquidsLevelCompleted(object sender, GetLiquidsLevelCompletedEventArgs e)
        {
            if (e.Result.IsSuccess)
            {
                var dataContract = e.Result.Response;
                lblTankInfo.Content = "Tank Name: " + dataContract.Name + " and the level: " + dataContract.Level;
            }
            else
            {
                lblTankInfo.Content = e.Result.Error;
            }
        }

        private void btnGetTankInfo_Click(object sender, RoutedEventArgs e)
        {
            lblTankInfo.Content = "Retrieving Tank Info..";
            var tankId = int.Parse(txtTankId.Text);
            _client.GetLiquidsLevelAsync(new GetLiquidsLevelRequest() { Id = tankId, UserName = txtUserName.Text });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void btnGetWellInfo_Click(object sender, RoutedEventArgs e)
        {
            lblTankInfo.Content = "Retrieving Well Info..";
            lblEditWellInfo.Visibility = Visibility.Collapsed;
            btnEditWellInfo.Visibility = Visibility.Collapsed;
            var wellNumber = int.Parse(txtWellId.Text);
            _client.ReallyLongDataPullAsync(new ReallyLongDataPullRequest() { WellNumber = wellNumber, UserName = txtUserName.Text});
        }


        
    }
}