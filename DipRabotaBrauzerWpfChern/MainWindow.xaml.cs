using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using CefSharp;
using CefSharp.Wpf;
using System.Windows.Media.Imaging;
using System.Collections.Generic;

namespace DipRabotaBrauzerWpfChern
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ChromiumWebBrowser chromiumWebBrowser;

        string urls = "https://www.google.ru/";

        int counter = 0;

        event EventHandler<LoadingStateChangedEventArgs> LoadingStateChanged;

        public List<string> favouritesWebList;

        public bool provMenu = false;
        public int provCount;

        public MainWindow()
        {
            InitializeComponent();       
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CefSettings cefSettings = new CefSettings();
            Cef.Initialize(cefSettings);

            TabControlBrows.SelectedIndex = 0;
            chromiumWebBrowser = new ChromiumWebBrowser();
            chromiumWebBrowser.AddressChanged += ChromiumWebBrowser_AddressChanged;
            //chromiumWebBrowser = new ChromiumWebBrowser("https://www.google.ru/");
            //TabControlBrows.Items.Add(chromiumWebBrowser);
        }

        private void ChromiumWebBrowser_AddressChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            throw new NotImplementedException();       
        }

        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NewTab(null, "Вкладка" + counter);
            }
            catch
            { }
        }

        private void ButtonNewTab_Click(object sender, RoutedEventArgs e)
        {
            NewTab(urls,"Вкладка" + counter);
        }

        private void ButtonRefresh_Click(object sender, RoutedEventArgs e)
        {
            if (TabControlBrows.SelectedIndex != 0 && TabControlBrows.SelectedIndex != provCount)
            {
                try
                {
                    chromiumWebBrowser.Reload();
                }
                catch { }
            }
        }

        private void ButtonBackWeb_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                chromiumWebBrowser.Back();
            }
            catch { }
        }

        private void ButtonNextWeb_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                chromiumWebBrowser.Forward();
            }
            catch { }
        }

        private void ButtonClouseTab_Click(object sender, RoutedEventArgs e)
        {
            if (TabControlBrows.SelectedIndex != 0)
            {
                if (TabControlBrows.SelectedIndex == provCount)
                {
                    provMenu = false;
                }
                TabControlBrows.Items.Remove(TabControlBrows.SelectedItem);
                counter--;
            }
        }

        private void ButtonHome_Click(object sender, RoutedEventArgs e)
        {
            TabControlBrows.SelectedIndex = 0;
        }

        public void CreateStartHome()
        {
            counter++;
            try
            {
                chromiumWebBrowser = new ChromiumWebBrowser();
                TabControlBrows.Items.Add(new TabItem
                {
                    Header = new TextBlock { Text = "Домашняя страница" },
                    Content = new Image
                    {
                        Source = new BitmapImage(new Uri("C:\\Users\\romac\\source\\repos\\DipRabotaBrauzerWpfChern\\DipRabotaBrauzerWpfChern\\Prop\\browserHomeStartTab.png")),
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        Width = 100,
                        Height = 100
                    },
                    Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FF02799A")
                });
                TabControlBrows.SelectedIndex = counter;
                
            }
            catch { }
        }
        public void NewTab(string url, string title)
        {
            counter++;
            string urlsProv = url;
            if (url == null)
            {
                urlsProv = TextBoxSearch.Text;
            }
            else
            {
                urlsProv = url;
            }
            try
            {
                chromiumWebBrowser = new ChromiumWebBrowser(urlsProv);
                TabControlBrows.Items.Add(new TabItem
                {
                    Header = new TextBlock { Text = title },
                    Content = chromiumWebBrowser,

                    Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FF02799A")

                });
                TabControlBrows.SelectedIndex = counter;
            }
            catch { }
        }

        private void ButtonSetting_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ButtonMenu_Click(object sender, RoutedEventArgs e)
        {
            if (provMenu == false)
            {
                BorderMenu.Visibility = Visibility.Visible;
                provMenu = true;
                return;
            }
            if (provMenu == true)
            {
                BorderMenu.Visibility = Visibility.Collapsed;
                provMenu = false;
                return;
            }
        }

        private void MenuItemSetting_Click(object sender, RoutedEventArgs e)
        {
            if (provMenu == false)
            {
                counter++;
                provCount = counter;
                StartHomePage startHomePage = new StartHomePage();
                try
                {
                    chromiumWebBrowser = new ChromiumWebBrowser();
                    TabControlBrows.Items.Add(new TabItem
                    {
                        Header = new TextBlock { Text = "Настройки" },
                        Content = new Frame
                        {
                            HorizontalAlignment = HorizontalAlignment.Stretch,
                            VerticalAlignment = VerticalAlignment.Stretch,
                            Content = startHomePage
                        },
                        Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FF02799A")
                    });
                }
                catch { }

                provMenu = true;
            }
            TabControlBrows.SelectedIndex = provCount;
        }
    }
}
