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
        
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            
            DavidFactDatabase database = await DavidFactDatabase.Instance;

            var items = await database.GetItemsAsync();
            items.ForEach(async item => await database.DeleteItemAsync(item));
            
            var facts = new List<DavidFact>()
            {
                new DavidFact() { Title = "Early Years", Description = "He was born in Milwaukee, but grew up in Brazil.", Image = "boy.png"},
                new DavidFact() { Title = "Sports", Description = "Started playing tennis at 10 years old.", Image = "tennis.png"},
                new DavidFact() { Title = "Getting into Technology", Description = "URL of the first website he made was pingpongdude.com.br", Image = "data-management.png"},
                new DavidFact() { Title = "Kids", Description = "Has two beautiful kids, and another on the way!", Image = "children.png"},
                new DavidFact() { Title = "Summer Camp", Description = "Worked at a summer camp in Wautoma, WI for five summers.", Image = "tent.png"},
            };

            facts.ForEach(async fact =>
            {
                await database.SaveItemAsync(fact);
            });
            
            ListView.ItemsSource = await database.GetItemsAsync();
        }
        
        void OnSelection(object sender, SelectedItemChangedEventArgs e) {
            if (e.SelectedItem == null)
            {
                return;
            }
            DavidFact fact = (DavidFact)e.SelectedItem;
            DisplayAlert(fact.Title, fact.Description, "Ok");
        }
    }
}