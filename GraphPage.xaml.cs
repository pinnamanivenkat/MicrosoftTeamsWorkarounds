using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using Refit;
using System.Net.Http;
using System.Net.Http.Headers;
using TeamsContactsGroupCreator.Model;
using System.Net;
using System.Threading.Tasks;

namespace TeamsContactsGroupCreator
{
    /// <summary>
    /// Interaction logic for GraphPage.xaml
    /// </summary>
    public partial class GraphPage : Page, INotifyPropertyChanged
    {
        #region properties
        public event PropertyChangedEventHandler PropertyChanged;
        private DebounceDispatcher debounceDispatcher;
        private IRefitInterface refitInterface;

        private List<SearchResult> dlListItems;
        private bool _ErrorTextVisibility;
        private bool _ContinueButtonVisibility;
        #endregion

        #region Fields
        public string DLName { get; set; }

        public List<SearchResult> DLList { 
            get
            {
                return dlListItems;
            }
            set
            {
                dlListItems = value;
                NotifyPropertyChange("DLList");
            }
        }

        public Boolean ErrorTextVisibility
        {
            get
            {
                return _ErrorTextVisibility;
            }
            set
            {
                _ErrorTextVisibility = value;
                NotifyPropertyChange("ErrorTextVisibility");
            }
        }

        public Boolean ContinueButtonVisibility
        {
            get
            {
                return _ContinueButtonVisibility;
            }
            set
            {
                _ContinueButtonVisibility = value;
                NotifyPropertyChange("ContinueButtonVisibility");
            }
        }
        #endregion

        public GraphPage(string bearerValue)
        {
            InitializeComponent();
            DataContext = this;
            ErrorTextVisibility = false;
            debounceDispatcher = new DebounceDispatcher();
            debounceDispatcher.Idled+=debounceDispatcher_IdledAsync;

            ContinueButtonVisibility = false;

            var configuredHttpClient = new HttpClient();
            configuredHttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",bearerValue);
            configuredHttpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/77.0.3865.90 Safari/537.36");
            configuredHttpClient.BaseAddress = new Uri("https://teams.microsoft.com/api/mt/amer/beta");
            refitInterface = RestService.For<IRefitInterface>(configuredHttpClient);
        }

        private async void debounceDispatcher_IdledAsync(object sender, EventArgs e)
        {
            if (DLName == null || DLName.Length == 0)
            {
                ErrorTextVisibility = true;
            }
            else
            {
                ErrorTextVisibility = false;
                try
                {
                    var result = await refitInterface.GetDLSearchResults(DLName);
                    SearchDLModel searchDLModel = (SearchDLModel)result;
                    List<SearchResult> validSearchItems = new List<SearchResult>();
                    foreach(SearchResult searchResult in searchDLModel.Value)
                    {
                        if (searchResult.MailEnabled != null && searchResult.MailEnabled.Value)
                        {
                            validSearchItems.Add(searchResult);
                        }
                    }
                    DLList = validSearchItems;
                }
                catch (ApiException exception)
                {
                    if(exception.StatusCode==HttpStatusCode.Unauthorized)
                    {
                        MessageBox.Show("You are not authorised to perform this operation");
                    }
                    else if(exception.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        MessageBox.Show("Some error occured in the server");
                    }
                }
            }
        }

        private void NotifyPropertyChange(string p)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(p));
            }
        }

        private void DLNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (debounceDispatcher != null)
            {
                debounceDispatcher.TextChanged();
            }
        }

        private void DL_List_Box_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ValidateSelectionChange();
        }

        private void ValidateSelectionChange()
        {
            SearchResult searchResult = (SearchResult)DL_List_Box.SelectedItem;
            if (searchResult != null && DLContactGroup.Text.Length != 0)
            {
                ContinueButtonVisibility = true;
                Console.WriteLine(searchResult.Email);
            }
            else
            {
                ContinueButtonVisibility = false;
            }
        }

        private void DLContactGroup_TextChanged(object sender, TextChangedEventArgs e)
        {
            ValidateSelectionChange();
        }

        private async void ContinueButton_Click(object sender, RoutedEventArgs e)
        {
            ContinueButton.IsEnabled = false;
            SearchResult searchResult = (SearchResult)DL_List_Box.SelectedItem;
            try
            {
                var result = await refitInterface.GetDistributionListUsers(searchResult.ObjectId);
                DistributionListModel distributionListModel = result;

                GroupModel groupModel = new GroupModel();
                groupModel.DisplayName = DLContactGroup.Text;
                groupModel.DistributionListUsers = distributionListModel.DistributionListUsers;
                var createGroupResult = await refitInterface.CreateContactsGroup(groupModel);
                CreateGroupResponseModel createGroupResponseModel = (CreateGroupResponseModel) createGroupResult;
                MessageBox.Show("Creation of group successful");
            }
            catch (ApiException exception)
            {
                if (exception.StatusCode == HttpStatusCode.Unauthorized)
                {
                    MessageBox.Show("You are not authorised to perform this operation");
                }
                else if (exception.StatusCode == HttpStatusCode.InternalServerError)
                {
                    MessageBox.Show("Some error occured in the server");
                }
            }
            ContinueButton.IsEnabled = true;
        }
    }
}
