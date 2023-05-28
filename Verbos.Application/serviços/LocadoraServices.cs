using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verbos.Domain.Contratos;
using Verbos.Domain.Entidades;
using Verbos.Infrastructure;

namespace Verbos.Application.serviços
{
    public class LocadoraServices:ILocadora
    {
        private readonly IBancoDados _bancoDado;
        public List<Filme> Filmes { get; set; }

        public LocadoraServices(IBancoDados bancoDado)
        {
            _bancoDado = bancoDado;           
        }
      
        public void AddFilme(Filme filme)
        {
            _bancoDado.Adicionar(filme);           
        }

        public void alterarFilme(Filme filme)
        {
            _bancoDado.Alterar(filme);
        }

        public void DeletarFilme(int id)
        {
            _bancoDado.Deletar(id);            
        }

        public List<Filme> ExbirFilmes()
        {
            return _bancoDado.Consultar();            
        }
    }
}
