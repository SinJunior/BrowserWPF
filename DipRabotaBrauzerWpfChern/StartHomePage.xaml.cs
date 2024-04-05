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

namespace DipRabotaBrauzerWpfChern
{
    /// <summary>
    /// Логика взаимодействия для StartHomePage.xaml
    /// </summary>
    public partial class StartHomePage : Page
    {
        public StartHomePage()
        {
            InitializeComponent();
        }

        private void TabPageProfil_Click(object sender, RoutedEventArgs e)
        {
            frameSettings.Navigate(new ProfilPage());
        }
    }
}
