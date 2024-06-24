using System.Diagnostics;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using myfinance_web_dotnet.infraestructure;
using myfinance_web_dotnet.Models;
using myfinance_web_dotnet.Services;

namespace myfinance_web_dotnet.Controllers;

[Route("[controller]")]
public class PlanoContaController : Controller
{
    private readonly ILogger<PlanoContaController> _logger;

    private readonly IPlanoService _planoService;

    public PlanoContaController(ILogger<PlanoContaController> logger,  IPlanoService  planoService)
    {
        _logger = logger;
        _planoService = planoService;

    }

    public IActionResult Index()
    {
        var lista = _planoService.listarRegistros();
        ViewBag.ListaPlanoConta = lista;
        return View();
    }

    [HttpPost] 
    [Route("Cadastro")]
    [Route("Cadastro/{id}")]
    public IActionResult Cadastro (PlanoContaModel model, int? id)
     {
          _planoService.salvar(model);
           return RedirectToAction("Cadastro");
           

    }

   
    [HttpGet]
    [Route("Cadastro")]
    [Route("Cadastro/{id}")]
    public IActionResult Cadastro (int? id)
     {
         if (id != null)
         {
             var registro = _planoService.retornarRegistro ((int)id); 
             return View(registro);    
         }
        
            return View();

           

    }

    

     [HttpGet]
     [Route("Excluir/{id}")]
     public IActionResult Excluir(int id)
    {
       _planoService.excluir(id);
       return RedirectToAction("Index");
    }


}
