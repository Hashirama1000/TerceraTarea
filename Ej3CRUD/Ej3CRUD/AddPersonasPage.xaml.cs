using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ej3CRUD
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPersonasPage : ContentPage
    {
        Personas personasDetails;
        public AddPersonasPage (Personas details)
        {
            InitializeComponent();
            if (details != null)
            {
                personasDetails = details;
                PopulateDetails(personasDetails);
            }
        }

        private void PopulateDetails(Personas details)
        {
            txtNombre.Text = details.Nombre;
            txtApellido.Text = details.Apellido;
            txtEdad.Text = details.Edad;
            txtCorreo.Text = details.Correo;
            txtDireccion.Text = details.Direccion;
            saveBtn.Text = "Actualizar";
            this.Title = "Modificar Perona";
        }
        private void saveBtn_Clicked(object sender, EventArgs e)
        {
            if (saveBtn.Text == "Guardar")
            {
                Personas personas = new Personas();
                personas.Nombre = txtNombre.Text;
                personas.Apellido = txtApellido.Text;
                personas.Edad = txtEdad.Text;
                personas.Correo = txtCorreo.Text;
                personas.Direccion = txtDireccion.Text;



                bool res = DependencyService.Get<ISQLite>().SavePersonas(personas);
                if (res)
                {
                    Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("Aviso", "No Se Pudieron Guardar los Datos", "Ok");
                }
            }
            else
            {
                // Actualizar
                personasDetails.Nombre = txtNombre.Text;
                personasDetails.Apellido = txtApellido.Text;
                personasDetails.Edad = txtEdad.Text;
                personasDetails.Correo = txtCorreo.Text;
                personasDetails.Direccion = txtDireccion.Text;

                bool res = DependencyService.Get<ISQLite>().UpdatePersonas(personasDetails);
                if (res)
                {
                    Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("Aviso", "No Se Pudieron Actualizar los Datos", "Ok");
                }
            }
        }
    }
}