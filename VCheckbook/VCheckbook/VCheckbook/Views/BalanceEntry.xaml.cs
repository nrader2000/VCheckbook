using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using VCheckbook.Models;

namespace VCheckbook
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BalanceEntry : ContentPage
    {
        public BalanceEntry()
        {
            InitializeComponent();

            BindingContext = new Balances();
        }

        async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                var bal = (Balances)BindingContext;

                //Save the Balance Name and Amount
                if (string.IsNullOrWhiteSpace(bal.Filename))
                {
                    var filename = Path.Combine(App.FolderPath, $"{Path.GetRandomFileName()}.balancedata.txt");
                    File.WriteAllText(filename, bal.BName);
                }
                if (string.IsNullOrWhiteSpace(bal.Filename))
                {
                    var filename = Path.Combine(App.FolderPath, $"{Path.GetRandomFileName()}.balancedata.txt");
                    File.WriteAllText(filename, bal.BAmount);
                }
                await Navigation.PopAsync();
            }
            catch
            {
                await DisplayAlert("Error", "Error saving data.Make sure a Name is enetred for your Balance", "OK");
            }

        }
    }
}