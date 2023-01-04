using ControleDeContatos.Data;
using ControleDeContatos.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleDeContatos.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _bancoContext; //criando uma variavel

        public ContatoRepositorio(BancoContext bancoContext)
        {
            this._bancoContext= bancoContext;
        }

        public ContatoModel ListarPorId(int id)
        {
            return _bancoContext.Contatos.FirstOrDefault(x => x.Id == id);
        }

        public List<ContatoModel> BuscarTotos()
        {
            return  _bancoContext.Contatos.ToList();
        }

        public ContatoModel Acicionar(ContatoModel contato)
        {
            // gravar dados no Banco de Dados]
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges(); //commitar - confirma
            return contato;
        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatoDB = ListarPorId(contato.Id);

            if (contatoDB == null) throw new System.Exception("OH!Houve um erro na atualização do contato!!!");

            contatoDB.Name= contato.Name;
            contatoDB.Email= contato.Email;
            contatoDB.Celular = contato.Celular;

            _bancoContext.Contatos.Update(contatoDB);
            _bancoContext.SaveChanges();

            return contatoDB;

        }

        public bool Apagar(int id)
        {
            ContatoModel contatoDB = ListarPorId(id);

            if (contatoDB == null) throw new System.Exception("OH!Houve um erro na deleção do contato!!!");

            _bancoContext.Contatos.Remove(contatoDB);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}
