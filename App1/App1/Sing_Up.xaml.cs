using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Sing_Up : ContentPage
    {
        
        public Sing_Up()
        {
            InitializeComponent();
        }

        public void Button_Registro(object sender, EventArgs e)
        {
            bool verific = VerificarR();
            if (verific == true)
            {
                //Prueba
                Campo_Obligatorio.IsVisible = false;
                wrongMail.IsVisible = false;

                Registrar();
            }
            
        }

        private bool VerificarR()
        {
            string capNombres = txtNombres.Text;
            string capApellidoP = txtApP.Text;
            string capApellidoM = txtApM.Text;
            string capCorreo = txtCorreo.Text;
            string capEstado = txtCorreo.Text;
            string capCiudad = txtCiudad.Text;
            string capMatricula = txtMatricula.Text;

            

                //cadena o expresion regular que verifica a un formato de correo electrónico
                string expresion = "^[_a-z0-9-]+(.[_a-z0-9-]+)*@[a-z0-9-]+(.[a-z0-9-]+)*(.[a - z]{ 2,4})$";
                //verifica que el email ingresado corresponda con la expresio válida
                if (capNombres == null || capApellidoM == null || capApellidoP == null || capCorreo == null || capEstado == null || capMatricula == null || capCiudad == null)
                {
                    Campo_Obligatorio.IsVisible = true;
                return false;
                }
                else
                {
                    if (Regex.IsMatch(capCorreo, expresion))
                    {
                        //verifica que la direccion corresponda y que la longitud    de la cadena noesté vacía
                        if (Regex.Replace(capCorreo, expresion, string.Empty).Length == 0)
                        {
                        //habilitar advertencia de correo mal escrito
                        Campo_Obligatorio.IsVisible = true;
                        return false;
                        }
                        else
                        {
                        return true;
                        }
                    }
                    else
                    {
                    wrongMail.IsVisible = true;
                    return false;
                    }
                }
                
        
        }

        public void Registrar()
        {
            string capNombres = txtNombres.Text;
            string capApellidoP = txtApP.Text;
            string capApellidoM = txtApM.Text;
            string capCorre = txtCorreo.Text;
            string capEstado = txtCorreo.Text;
            string capCiudad = txtCiudad.Text;
            string capMatricula = txtMatricula.Text;
        }
    }
}