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
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            {
                bool verific = VerificarR();
                if (verific == true)
                {
                    Campo_Obligatorio.Text = " ";
                    Registrar();
                    Navigation.PushAsync(new grupo());
                }
                else
                {
                    Campo_Obligatorio.Text = "Rellena los campos obligatorios";
                }

            }
        }
        private bool VerificarR()
        {
            bool Respuesta;
            if (string.IsNullOrEmpty(txtGrupo.Text))
            {
                Respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtApP.Text))
            {
                Respuesta = false;
            }
        }

}