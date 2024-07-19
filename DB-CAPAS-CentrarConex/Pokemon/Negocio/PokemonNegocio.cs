using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using ConexionCentral;

namespace Negocio
{
    public class PokemonNegocio
    {
        public List<Pokemon> Listar()
        {
            List<Pokemon> listaPokemones = new List<Pokemon>();
            AccesoCentral acceso = new AccesoCentral();

            try
            {
                acceso.setearConsulta("select P.Numero, P.Nombre, P.Descripcion, P.UrlImagen, E.Descripcion Tipo, D.Descripcion Debilidad from POKEMONS P, ELEMENTOS E, ELEMENTOS D where P.IdTipo = E.Id and P.IdDebilidad = D.Id");
                acceso.ejecutarLectura();

                while (acceso.Lector.Read())
                {
                    Pokemon auxPokemon = new Pokemon();
                    auxPokemon.Numero = (int)acceso.Lector["Numero"];
                    auxPokemon.Nombre = (string)acceso.Lector["Nombre"];
                    auxPokemon.Descripcion = (string)acceso.Lector["Descripcion"];
                    auxPokemon.UrlImagen = (string)acceso.Lector["UrlImagen"];
                    auxPokemon.Tipo = new Elemento();
                    auxPokemon.Tipo.Descripcion = (string)acceso.Lector["Tipo"];
                    auxPokemon.Debilidad = new Elemento();
                    auxPokemon.Debilidad.Descripcion = (string)acceso.Lector["Debilidad"];

                    listaPokemones.Add(auxPokemon);

                }


                return listaPokemones;
            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                acceso.cerrarConexion();
            }
        }
    }
}
