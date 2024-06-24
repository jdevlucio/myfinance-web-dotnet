using System.Diagnostics;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using myfinance_web_dotnet.infraestructure;
using myfinance_web_dotnet.Models;
using myfinance_web_dotnet.Services;

namespace myfinance_web_dotnet.Controllers;
    
    [Route("[controller]")]
    public class TransacaoController : Controller
    {
    private readonly ILogger<TransacaoController> _logger;

    private readonly ITransacaoService _transacaoService;

     private readonly IPlanoService _planoService;


    public TransacaoController(ILogger<TransacaoController> logger,  ITransacaoService  transacaoService, IPlanoService  planoService)
    {
        _logger = logger;
        _transacaoService = transacaoService;
        _planoService = planoService;

    }

    public IActionResult Index()
    {
        var lista = _transacaoService.listarRegistros();
        ViewBag.ListaTransacao = lista;
        return View();
    }

    [HttpPost] 
    [Route("Cadastro")]
    [Route("Cadastro/{id}")]
    public IActionResult Cadastro (TransacaoModel model, int? id)
    {
       
        if (ModelState.IsValid)
        {
          _transacaoService.salvar(model);
          return RedirectToAction("Cadastro");
        }
       
        else
        {
          var listaPlanoConta = _planoService.listarRegistros();
          var selectListPlanoContas = new SelectList(listaPlanoConta, "Id", "Descricao"); 
          model.PlanoContas = selectListPlanoContas;
          return View(model);
        }
    }


    [HttpGet]
    [Route("Cadastro")]
    [Route("Cadastro/{id}")]
    public IActionResult Cadastro (int? id)
    {
        var listaPlanoConta = _planoService.listarRegistros();
        var selectListPlanoContas = new SelectList(listaPlanoConta, "Id", "Descricao"); 
 
        if (id != null)
        {
           var model = _transacaoService.retornarRegistro((int)id);
           model.PlanoContas = selectListPlanoContas;
          return View(model);
        }
      
        else
        {
          var model = new TransacaoModel();
          model.PlanoContas = selectListPlanoContas;
          return View(model);
        }
    }
    

     [HttpGet]
     [Route("Excluir/{id}")]
     public IActionResult Excluir(int id)
    {
       _transacaoService.excluir(id);
       return RedirectToAction("Index");
    }
    }
