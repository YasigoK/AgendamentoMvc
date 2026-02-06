using AgendamentoMvc.Business.Models;
using AgendamentoMvc.Business.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace AgendamentoMvc.Web.Controllers;

public class PacienteController : Controller
{
    private readonly IPacienteService _pacienteService;
public PacienteController(IPacienteService pacienteService)
    {
        _pacienteService = pacienteService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var entity = await _pacienteService.ListarTodos();
        return View(entity);
    }

    [HttpGet]
    public async Task<IActionResult> CadastrarPaciente()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CadastrarPaciente(PacienteModel paciente)
    {
        var entity = await _pacienteService.CriarPaciente(paciente);
        if (entity != null)
            return RedirectToAction("Index");
        else
            return View();
    }


    [HttpGet]
    public async Task<IActionResult> EditarPaciente(Guid id)
    {
        var paciente = await _pacienteService.ListarPorId(id);
        if (paciente != null)
            return View(paciente);
        else
            return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> EditarPaciente(PacienteModel paciente)
    {
        var entity = await _pacienteService.EditarPaciente(paciente);
        if (entity == true)
            return RedirectToAction("Index");
        else
            return View(paciente.Id);
    }

    [HttpGet]
    public async Task<IActionResult> ExcluirPaciente(Guid id)
    {
        var paciente = await _pacienteService.ListarPorId(id);
        if (paciente != null)
            return View(paciente);
        else
            return NotFound();
    }
    [HttpPost]
    public async Task<IActionResult> ExcluirPaciente(PacienteModel paciente)
    {
        var entity = await _pacienteService.ExcluirPaciente(paciente);
        if (entity != null)
            return RedirectToAction("Index");
        else
            return NotFound();
    }
}
