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
    public async Task<IActionResult> CadastrarMedico()
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

    [HttpGet]
    public async Task<IActionResult> EditarMedico(Guid id)
    {
        var entity = await _medicosService.BuscarId(id);
        if (entity != null)
            return View(entity);
        else
            return NotFound();
    }
    [HttpPost]
    public async Task<IActionResult> EditarMedico(MedicoModel medico)
    {
        var entity = await _medicosService.EditarMedico(medico);
        if (entity == true)
            return RedirectToAction("index");
        else
            return View(medico.Id);
    }


    [HttpGet]
    public async Task<IActionResult> ExcluirMedico(Guid id)
    {
        var entity = await _medicosService.BuscarId(id);
        return View(entity);
    }

    [HttpPost]
    public async Task<IActionResult> ExcluirMedico(MedicoModel model)
    {
        var entity = await _medicosService.DeletarMedico(model);
        return RedirectToAction("Index");
    }
}
