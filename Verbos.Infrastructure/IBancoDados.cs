using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verbos.Domain.Entidades;

namespace Verbos.Infrastructure
{
    public interface IBancoDados
    {
        List<Filme> Consultar();
        void Adicionar(Filme filme);
        void Alterar(Filme filme);
        void Deletar(int id);
    }
}
