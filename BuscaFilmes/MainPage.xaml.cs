using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using BuscaFilmes.Resources;
using BuscaFilmes.Classes;
using Newtonsoft.Json.Linq;

namespace BuscaFilmes
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        public void BuscarFilme()
        {
            WebClient filmeClient = new WebClient();

            filmeClient.DownloadStringCompleted += filmeClient_DownloadStringCompleted;

            filmeClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(filmeClient_DownloadStringCompleted);

            filmeClient.DownloadStringAsync(new Uri(@"http://www.omdbapi.com/?s=" + txt_filme.Text));

        }

        void filmeClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            botar_json(e.Result);
            throw new NotImplementedException();
        }

        public void botar_json(String json)
        {
            List<Filme> filmes = new List<Filme>();
            if (json != null)
            {
                JObject jobject = JObject.Parse(json);
                JObject achou_filme = (JObject)jobject["Response"];
                if (achou_filme.Count == 1)
                {
                    status.Text = "Não achou";
                }
                else
                {

                }
            }
            else
            {
                status.Text = "Erro ao procurar Filmes";
            }
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}