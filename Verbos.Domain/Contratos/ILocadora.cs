using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verbos.Domain.Entidades;

namespace Verbos.Domain.Contratos
{
    public interface ILocadora
    {
        List<Filme> ExbirFilmes();
        void AddFilme(Filme filme);
        void DeletarFilme(int id);
        void alterarFilme(Filme filme);
    }
}
