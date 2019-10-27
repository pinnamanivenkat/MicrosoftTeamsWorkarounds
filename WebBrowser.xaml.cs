using System.Windows;

namespace TeamsContactsGroupCreator
{
    /// <summary>
    /// Interaction logic for WebBrowser.xaml
    /// </summary>
    public partial class WebBrowser : Window
    {
        public WebBrowser()
        {
            InitializeComponent();
            DataContext = this;
            Init();
        }

        private void Init()
        {
            Browser.Navigate("https://teams.microsoft.com",null,null, "User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/77.0.3865.90 Safari/537.36\r\n");
        }
    }
}
