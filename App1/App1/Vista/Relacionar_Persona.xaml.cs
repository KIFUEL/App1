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
    public partial class Relacionar_Persona : ContentPage
    {
        public Relacionar_Persona()
        {
            InitializeComponent();
        }

        public async void Mostrar_Personas()
        {

            List<usuario> result = App.SQLiteDB.GetUsuariosAsync().Result;

            if (result.Count != 0)
            {
                int randomNumber = new Random().Next(1,result.Count+1);
                List<usuario> Relacion = App.SQLiteDB.GetUsuariotoID(randomNumber).Result;
              
                if (Relacion.Count != 0){
                    Usuario_ref.ItemsSource = Relacion;
                }
                else
                {
                    await DisplayAlert("Alerta", "No se encontraron Usuarios registrados", "OK");
                }

                
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