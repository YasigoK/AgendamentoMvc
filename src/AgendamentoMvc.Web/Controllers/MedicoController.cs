using AgendamentoMvc.Business.Models;
using AgendamentoMvc.Business.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace AgendamentoMvc.Web.Controllers;

public class MedicoController : Controller
{
    private readonly IMedicosService _medicosService;

    public MedicoController(IMedicosService medicosService)
    {
        _medicosService = medicosService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var lista = await _medicosService.ListarTodos();
        return View(lista);
    }

    [HttpGet]
    public async Task<IActionResult> CadastrarCadastrarMedico()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CadastrarMedico(MedicoModel medico)
    {
        var entity = await _medicosService.CriarMedico(medico);

        if(entity==null)
            return View(medico);
        else
            return RedirectToAction("index");
    }
}
