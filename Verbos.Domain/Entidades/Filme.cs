using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verbos.Domain.Entidades
{
    public class Filme
    {
        public string Nome { get; set; }
        public string Genero { get; set; }
        public int id  { get; set; }
        
        public Filme(string name, string genero, int id)
        {
            Nome = name;
            Genero = genero;
            this.id = id;
        }
        public Filme() { }
    }
}
