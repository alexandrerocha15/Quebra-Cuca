using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuebraCuca.Aplicacao.Modulos.ModuloDataHumanizada;

namespace QuebraCuca.WebApp.Modulos.ModuloDataHumanizada;

public class DataHumanizadaController : Controller
{
    private readonly ServicoDataHumanizada servico;
    private readonly IMapper mapper;

    public DataHumanizadaController(
        ServicoDataHumanizada servico,
        IMapper mapper)
    {
        this.servico = servico;
        this.mapper = mapper;
    }

    [HttpGet]
    public IActionResult IndexDataHumanizada()
    {
        DataHumanizadaViewModel viewModel = new()
        {
            DataReferencia = DateTime.Now
        };

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult IndexDataHumanizada(DataHumanizadaViewModel viewModel)
    {
        if (!ModelState.IsValid)
            return View(viewModel);

        HumanizarDataDto dto =
            mapper.Map<HumanizarDataDto>(viewModel);

        var resultado = servico.Humanizar(dto);

        if (resultado.IsFailed)
        {
            foreach (var erro in resultado.Errors)
            {
                ModelState.AddModelError(
                    string.Empty,
                    erro.Message
                );
            }

            return View(viewModel);
        }

        mapper.Map(resultado.Value, viewModel);

        return View(viewModel);
    }
}
