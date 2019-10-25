using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool validarNombre() {
            if (textBoxNombre.Text == "")
            {
                //campo vacio 
                MessageBox.Show("El campo nombre no puede estar vacio");
                return false;
            }
            else {
                //es valido
                return true;
            }
            return false;
        }

        private float validarPrecioUnitario() {
            float output;
            if (float.TryParse(textBoxPrecioUnitario.Text, out output))
            {
                if (output >= 0)
                {
                    return output;
                }
                else {
                    MessageBox.Show("El campo Precio Unitario tiene que ser positivo");
                    return -1;
                }
            }
            else {
                MessageBox.Show("Inserte un numero entero o decimal en el campo Precio Unitario");
                return -1;
            }
            return -1;
        }

        private int validarCantidad() {
            int output;
            if (Int32.TryParse(textBoxCantidad.Text, out output))
            {
                if (output >= 0)
                {
                    return output;
                }
                else
                {
                    MessageBox.Show("El campo Cantidad tiene que ser positivo");
                    return -1;
                }
            }
            else
            {
                MessageBox.Show("Solo es valido un numero entero en el campo Cantidad");
                return -1;
            }
            return -1;
        }

        private float calcularDescuento(float total) {
            if (total >= 500) {
                return total * 0.25f;
            }
            else if (total >= 300)
            {
                return total * 0.17f;
            }
            else if (total >= 200)
            {
                return total * 0.11f;
            }
            else if (total >= 100)
            {
                return total * 0.07f;
            }
            return 0;
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            //declaracion de variables
            bool entradasValidas = true;

            string Nombre = "";
            float PrecioUnitario = 0.0f;
            int Cantidad = 0;

            //validar nombre
            if (validarNombre())
            {
                Nombre = textBoxNombre.Text;
            }
            else {
                entradasValidas = false;
            }

            //validar precio unitario
            PrecioUnitario = validarPrecioUnitario();
            if (PrecioUnitario == -1)
            {
                entradasValidas = false;
            }

            //validar cantidad
            Cantidad = validarCantidad();
            if (Cantidad == -1)
            {
                entradasValidas = false;
            }


            if (entradasValidas) {
                MessageBox.Show("Validacion exitosa");

                //calcular totales y descuentos
                float subTotal = PrecioUnitario * Cantidad;
                float descuento = calcularDescuento(subTotal);

                float total = subTotal - descuento;
                float totalMasIVA = total * 1.13f;

                //arreglo del producto
                string[] product_info = new string[6];
                int nameIndex = 0;
                int priceIndex = 1;
                int amountIndex = 2;
                int discountIndex = 3;
                int IVAIndex = 4;
                int TotalIndex = 5;

                //poner la informacion en el array
                product_info[nameIndex] = Nombre;
                product_info[priceIndex] = PrecioUnitario.ToString("C");
                product_info[amountIndex] = Cantidad.ToString();
                product_info[discountIndex] = descuento.ToString("C");
                product_info[IVAIndex] = (total * 0.13f).ToString("C");
                product_info[TotalIndex] = totalMasIVA.ToString("C");

                //precentarlo en GridBox
                dataGridView.Rows.Add();
                

                //limpiar cajas de texto
                textBoxNombre.Text = "";
                textBoxPrecioUnitario.Text = "";
                textBoxCantidad.Text = "";
            }
        }
    }
}
