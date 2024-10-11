using System.IO;
using System.Windows;
using Gaming_Voice_Assistant.Data;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using Gaming_Voice_Assistant.Models;

namespace Gaming_Voice_Assistant
{
    public partial class MainWindow : Window
    {
        private LanguageDictionaryContext context = new LanguageDictionaryContext();

        private SpeechSynthesizer synthesizer = new SpeechSynthesizer();
        private SpeechRecognitionEngine sreMain = new SpeechRecognitionEngine();

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

        private void Start()
        {
            Choices choices = new Choices();

            var commands = from command in context.Commands
                           select command.CMD;

            choices.Add(commands.ToArray());

            Grammar grammar = new Grammar(new GrammarBuilder(choices));

            try
            {
                sreMain.LoadGrammar(grammar);
                sreMain.RequestRecognizerUpdate();
                sreMain.SpeechRecognized -= Sre_SpeechRecognized;
                sreMain.SpeechRecognized += Sre_SpeechRecognized;
                sreMain.SetInputToDefaultAudioDevice();
                sreMain.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch
            {
                return;
            }
        }

        private void Sre_SpeechRecognized(object? sender, SpeechRecognizedEventArgs e)
        {
            Speak(e.Result.Text);
        }

        private void Speak(string phrases)
        {
            synthesizer.Speak(phrases);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to exit? ", "Exit Confirmation", MessageBoxButton.YesNo);

            if(result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateDataGrid();
            Start();
        }

        private void UpdateDataGrid()
        {
/*            var commands = from command in context.Commands
                           select new
                           {
                               command.CMD,
                               command.RESPONSE,
                               command.EXECPATH
                           };
            dataGrid1.ItemsSource = commands.ToList();*/
        }

        private void OnExitItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

