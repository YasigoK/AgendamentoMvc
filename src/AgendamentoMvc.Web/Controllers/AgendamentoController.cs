using AgendamentoMvc.Business.Models;
using AgendamentoMvc.Business.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AgendamentoMvc.Web.Controllers;

public class AgendamentoController : Controller
{
    private readonly IAgendamentoService _agendamentoService;
    private readonly IMedicosService _medicoService;
    private readonly IPacienteService _pacienteService;

    public AgendamentoController(IAgendamentoService agendamentoService, IMedicosService medicoService, IPacienteService pacienteService)
    {
        _agendamentoService = agendamentoService;
        _medicoService = medicoService;
        _pacienteService = pacienteService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var entity = await _agendamentoService.ListarTodos();
        return View(entity);
    }

    [HttpGet]
    public async Task<IActionResult> CadastrarAgendamento()
    {
        var listagemMedico = await _medicoService.ListarNomeId();
        var listagemPaciente = await _pacienteService.ListarNomeId();
        ViewBag.Medicos = new SelectList(listagemMedico, "Id", "nomeCompleto");
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CadastrarAgendamento(AgendamentoModel agendamento)
    {
        return RedirectToAction("Index");
    }
}
