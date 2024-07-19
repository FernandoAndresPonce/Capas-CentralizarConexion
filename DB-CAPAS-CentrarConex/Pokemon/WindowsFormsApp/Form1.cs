using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace WindowsFormsApp
{
    public partial class Form1 : Form


    {
        private List<Pokemon> listaPokemones;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PokemonNegocio negocioPokemon = new PokemonNegocio();
            listaPokemones = negocioPokemon.Listar();
            dataGridView1.DataSource = listaPokemones;
            dataGridView1.Columns["UrlImagen"].Visible = false;

            pictureBox1.Load(listaPokemones[0].UrlImagen);

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            Pokemon seleccionado = (Pokemon)dataGridView1.CurrentRow.DataBoundItem;

            mostrarImagen(seleccionado.UrlImagen);
        }

        public void mostrarImagen(string imagen)
        {
            try
            {
                pictureBox1.Load(imagen);
            }
            catch (Exception ex)
            {
                pictureBox1.Load("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRerSliF3g0fe7jTs-YMteksQNJErQutOIWow&s");
                
            }
        }
    }
}
