using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using VCheckbook.Models;

namespace VCheckbook
{
    public partial class BalanceList : ContentPage
    {
        public BalanceList()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var bals = new List<Balances>();

            var files = Directory.EnumerateFiles(App.FolderPath, "*.balancedata.txt");
            foreach (var filename in files)
            {
                bals.Add(new Balances
                {
                    Filename = filename,
                    BName = File.ReadAllText(filename),
                    BAmount = File.ReadAllText(filename),
                });
            }

            blist.ItemsSource = bals.ToList();
        }
        async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BalanceEntry());
        }

        private void blist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            var files = Directory.EnumerateFiles(App.FolderPath, "*.balancedata.txt");
            foreach (var filename in files)
            {
                if (File.Exists(filename))
                {
                    File.Delete(filename);
                }
            }

            blist.ItemsSource = files.ToList();
        }
    }
}
