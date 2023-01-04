using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ControleDeContatos.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;

        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }

        public IActionResult Index() //metodo get
        {
            List<ContatoModel> contatos = _contatoRepositorio.BuscarTotos();

            return View(contatos);
        }
        public IActionResult Criar() 
        {
           return View();
        }
        public IActionResult Editar(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
             return View(contato);
        }
        public IActionResult ApagarConfirmacao(int id) //pergunta se exclui
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        public IActionResult Apagar(int id) //apaga o contato
        {
            try
            {
                bool apagado =  _contatoRepositorio.Apagar(id);
                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Contato apagado com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = "Opa, nã foi possivel apagar seu contato!";
                }
                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Opa, nã foi possivel apagar seu contato! Detalhe do erro :{erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato) //metodo post
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Acicionar(contato);
                    TempData["MensagemSucesso"] = "Contato Cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(contato);
            }
            catch(System.Exception erro)
            {
                TempData["MensagemErro"] = $"Opa, não foi possivel cadastrar seu contato, tente novamente! Detalhe do erro:{erro}";
                return RedirectToAction("Index");
                //throw;
            }
        }

        [HttpPost]
        public IActionResult Alterar(ContatoModel contato) //metodo post
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Atualizar(contato);
                    TempData["MensagemSucesso"] = "Contato alterado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View("Editar", contato); //Força a view, pois não tem Alterar mas sim editar'
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Opa, não foi possivel atualizarseu contato, tente novamente! Detalhe do erro:{erro}";
                return RedirectToAction("Index");
            }
        }
    }
}
