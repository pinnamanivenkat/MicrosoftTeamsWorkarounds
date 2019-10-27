using System;
using System.Data.SQLite;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace TeamsContactsGroupCreator
{
    /// <summary>
    /// Interaction logic for SignIn.xaml
    /// </summary>
    public partial class SignIn : Page
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private void SignIn_Button_Click(object sender, RoutedEventArgs e)
        {
            string strPath = GetChromeCookiePath();
            if (strPath == string.Empty)
            {
                MessageBox.Show("Please try again after installing Google Chrome");
            }
            else
            {
                try
                {
                    string strDb = "Data Source=" + strPath + ";pooling=false";

                    using (SQLiteConnection conn = new SQLiteConnection(strDb))
                    {
                        using (SQLiteCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = "SELECT encrypted_value from cookies where host_key like '%teams.microsoft.com%' and name like '%authtoken%'";

                            conn.Open();
                            bool found = false;
                            var plainText = "";
                            using (SQLiteDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var data = (byte[])reader[0];
                                    var decodedData = System.Security.Cryptography.ProtectedData.Unprotect(data, null, System.Security.Cryptography.DataProtectionScope.CurrentUser);
                                    plainText = Encoding.ASCII.GetString(decodedData);
                                    if (plainText.Contains("Bearer"))
                                    {
                                        found = true;
                                        break;
                                    }
                                }
                            }
                            conn.Close();
                            if (found)
                            {
                                string bearerValue = plainText.Replace("&Origin=https://teams.microsoft.com","");
                                bearerValue = bearerValue.Replace("Bearer=", "");
                                App.ParentWindow.ParentFrame.Navigate(new GraphPage(bearerValue));
                            }
                            else
                            {
                                MessageBox.Show("Please login into Microsoft Teams using Google Chrome browser and try again");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        private static string GetChromeCookiePath()
        {
            string s = Environment.GetFolderPath(
                Environment.SpecialFolder.LocalApplicationData);
            s += @"\Google\Chrome\User Data\Default\cookies";

            if (!File.Exists(s))
                return string.Empty;

            return s;
        }
    }
}
