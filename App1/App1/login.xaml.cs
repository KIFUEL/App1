using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class login : ContentPage
    {
        public void Verificar() 
        {
            string strUsuario = txtUsuario.Text;
            string strPasword = txtPassword.Text;
            string paswordBD = "123";
            string usuarioBD = "ADMIN";
            //verifica que el uusario y la contrsaeña sean los correctos
            if ((strUsuario == usuarioBD) && (strPasword == paswordBD))
            {

                Navigation.PushAsync(new Inicio());
            }
            else 
            {
                label_estado.Text = "El usuario o la contraseña no es correcta";
            }
        }

        public login()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Verificar();
        }
    }
}