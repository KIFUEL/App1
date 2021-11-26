using App1.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Mostrar_Usuarios : ContentPage
    {
        public Mostrar_Usuarios()
        {
            InitializeComponent();
        }

        public async void Mostrar_Personas()
        {

            List<usuario> result = App.SQLiteDB.GetUsuariosAsync().Result;

            if (result.Count != 0)
            {
                Lista_Usuarios.ItemsSource = result;
            }
            else
            {
                await DisplayAlert("Alerta", "No se encontraron Usuarios registrados", "OK");
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Mostrar_Personas();
        }
    }
}