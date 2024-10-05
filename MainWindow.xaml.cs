using System.IO;
using System.Windows;
using Gaming_Voice_Assistant.Data;
using Microsoft.Data.SqlClient;
using Gaming_Voice_Assistant.Models;

namespace Gaming_Voice_Assistant
{
    public partial class MainWindow : Window
    {
        private LanguageDictionaryContext context = new LanguageDictionaryContext();

        public MainWindow()
        {
            InitializeComponent();  
            Initialize();
        }

        private void Initialize()
        {
            string appdataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\LB\GVA\";
            string databaseFile = "Command_Dictionary.mdf";
            string databaseLogFile = "Command_Dictionary_log.ldf";

            if (!Directory.Exists(appdataPath))
            {
                Directory.CreateDirectory(appdataPath);
                File.Copy($@"{AppContext.BaseDirectory}\Data\{databaseFile}", $@"{appdataPath}{databaseFile}", true);
                File.Copy($@"{AppContext.BaseDirectory}\Data\{databaseLogFile}", $@"{appdataPath}{databaseLogFile}", true);
            }
            else
            {
                if(Directory.GetFiles(appdataPath).Length == 0)
                {
                    File.Copy($@"{AppContext.BaseDirectory}\Data\{databaseFile}", $@"{appdataPath}{databaseFile}", true);
                    File.Copy($@"{AppContext.BaseDirectory}\Data\{databaseLogFile}", $@"{appdataPath}{databaseLogFile}", true);
                }
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to exit? ", "Exit Confirmation", MessageBoxButton.YesNo);

            if(result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}

