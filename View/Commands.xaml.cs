using Gaming_Voice_Assistant.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Gaming_Voice_Assistant.View
{
    /// <summary>
    /// Interaction logic for Commands.xaml
    /// </summary>
    public partial class Commands : UserControl
    {
        LanguageDictionaryContext context = new();
        public Commands()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var cmd = from command in context.Commands
                      select new
                      {
                          command.CMD,
                          command.RESPONSE,
                          command.EXECPATH
                      };
            dataGrid1.ItemsSource = cmd.ToList();
        }
    }
}
