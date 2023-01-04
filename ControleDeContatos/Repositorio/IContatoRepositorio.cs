using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio
{
    public interface IContatoRepositorio
    {
        ContatoModel ListarPorId(int id); //contrato da interface - Metodo

        List<ContatoModel> BuscarTotos();//metodo de buscar todos os clientes

        ContatoModel Acicionar(ContatoModel contato); //criando metodo

        ContatoModel Atualizar(ContatoModel contato);

        bool Apagar(int id);
    }
}
