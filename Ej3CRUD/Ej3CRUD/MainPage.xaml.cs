using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ej3CRUD
{
    public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }
    protected override void OnAppearing()
    {
        PopulateEmployeeList();
    }
    public void PopulateEmployeeList()
    {
            PersonasList.ItemsSource = null;
            PersonasList.ItemsSource = DependencyService.Get<ISQLite>().GetPersonas();
    }

    private void AddPersonas(object sender, EventArgs e)
    {
        Navigation.PushAsync(new AddPersonasPage(null));
    }

    private void EditPersonas(object sender, ItemTappedEventArgs e)
    {
       Personas details = e.Item as Personas;
        if (details != null)
        {
            Navigation.PushAsync(new AddPersonasPage(details));
        }
    }

    private async void DeletePersonas(object sender, EventArgs e)
    {
        bool res = await DisplayAlert("Aviso", "Seguro que quieres eliminarlo?", "Ok", "Cancelar");
        if (res)
        {
            var menu = sender as MenuItem;
            Personas details = menu.CommandParameter as Personas;
            DependencyService.Get<ISQLite>().DeletePersonas(details.Id);
                PopulateEmployeeList();
        }
    }

  }
}
