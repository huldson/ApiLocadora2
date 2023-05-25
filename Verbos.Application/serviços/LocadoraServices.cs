using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verbos.Domain.Contratos;
using Verbos.Domain.Entidades;

namespace Verbos.Application.serviços
{
    public class LocadoraServices:ILocadora
    {
        public List<Filme> Filmes { get; set; }

        public LocadoraServices()
        {
            Filmes = new List<Filme>(); // Inicializa a lista de filmes
        }

        public void AddFilme(Filme filme)
        {
            
            Filmes.Add(filme);
            foreach(Filme film in Filmes)
            {
                Console.WriteLine(film.Name);
            }
        }

        public void alterarFilme(Filme filme)
        {
            foreach(Filme film in Filmes)
            {
                if (film.id == filme.id)
                {
                    film.Name = filme.Name;
                    film.Genero=filme.Genero;
                }
            }
        }

        public void DeletarFilme(int id)
        {
            foreach (Filme film in Filmes)
            {
                if (film.id == id)
                {
                    Filmes.Remove(film);
                    break;
                }
            }

            
        }

        public List<Filme> ExbirFilmes()
        {
            Console.WriteLine(Filmes.Count());
            return Filmes;
        }
    }
}
