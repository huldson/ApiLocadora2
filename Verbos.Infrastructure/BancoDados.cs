using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verbos.Domain.Entidades;

namespace Verbos.Infrastructure
{
    public class BancoDados :IBancoDados
    {
        private readonly IConfiguration _configuration;
        private readonly SqlConnection bancoDado;
     public BancoDados(IConfiguration configuration)
        {
            _configuration = configuration;
            bancoDado = new SqlConnection(_configuration.GetSection("BancoDedados").GetSection("StringDeConexao").Value);
        }
        public List<Filme> Consultar()
        {
            List<Filme>filmes= new List<Filme>();
            bancoDado.Open();
            SqlCommand comando = new SqlCommand("select * from Tabela_Filmes", this.bancoDado);
            SqlDataReader resultado = comando.ExecuteReader();
            while(resultado.Read()) 
            { Filme ffilme = new Filme(resultado["Nome"].ToString(), resultado["Genero"].ToString(), (int)resultado["Id"]);
                filmes.Add(ffilme);
            }
            bancoDado.Close();
            return filmes;
        }
        public void Adicionar(Filme filme)
        {
            try
            {
                bancoDado.Open();
                SqlCommand comando = new SqlCommand("INSERT INTO Tabela_Filmes(Nome,Genero) VALUES ('" + filme.Nome + "','" + filme.Genero + "')", this.bancoDado);
                comando.ExecuteNonQuery();
                bancoDado.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void Alterar(Filme filme) 
        {
            bancoDado.Open();
            if (filme.Nome != "" || filme.Genero != "")
            {
                if(filme.Nome != "")
                {
                    SqlCommand comando = new SqlCommand("UPDATE Tabela_Filmes SET Nome = '" + filme.Nome + "' WHERE id =" + filme.id, this.bancoDado);
                    comando.ExecuteNonQuery();
                    
                }
                else 
                {
                    SqlCommand comando = new SqlCommand("UPDATE Tabela_Filmes SET Genero = '" + filme.Genero + "' WHERE id =" + filme.id, this.bancoDado);
                    comando.ExecuteNonQuery();
                    
                }
                bancoDado.Close();
            }
        }
        public void Deletar(int id)
        {
            bancoDado.Open();
            SqlCommand comando = new SqlCommand("delete from Tabela_Filmes where Id ="+id,bancoDado);
            comando.ExecuteNonQuery();
            bancoDado.Close();
        }
    }
}
