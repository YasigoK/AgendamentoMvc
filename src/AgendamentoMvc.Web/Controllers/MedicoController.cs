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
}
