using AgendamentoMvc.Business.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AgendamentoMvc.Web.Controllers;

public class AgendamentoController : Controller
{
    private readonly IAgendamentoService _agendamentoService;
    private readonly IMedicosService _medicoService;

    public AgendamentoController(IAgendamentoService agendamentoService, IMedicosService medicoService)
    {
        _agendamentoService = agendamentoService;
        _medicoService = medicoService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var entity = await _agendamentoService.ListarTodos();
        var listagem = await _medicoService.ListarNomeId();
        ViewBag.NomesMedicos = new SelectList(listagem, "NomeCompleto");
        return View(entity);
    }
}
