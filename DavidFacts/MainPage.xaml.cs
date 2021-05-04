using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DavidFacts
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        
        void OnSelection(object sender, SelectedItemChangedEventArgs e) {
            if (e.SelectedItem == null)
            {
                return; }
            DavidData fact = (DavidData)e.SelectedItem;
            DisplayAlert(fact.Title, fact.Description, "Ok");
        }
    }
}