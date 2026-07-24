using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using QuebraCuca.Aplicacao.Modulos.ModuloDiamante;
using QuebraCuca.WebApp.Modulos.ModuloDiamante.ViewModels;

namespace QuebraCuca.WebApp.Modulos.ModuloDiamante;

public class DiamanteController : Controller
{
    private readonly ServicoDiamante servicoDiamante;
    private readonly IMapper mapper;

    public DiamanteController(
        ServicoDiamante servicoDiamante,
        IMapper mapper)
    {
        this.servicoDiamante = servicoDiamante;
        this.mapper = mapper;
    }

    [HttpGet]
    public IActionResult IndexDiamante()
    {
        return View(new DiamanteViewModel());
    }

    [HttpPost]
    public IActionResult IndexDiamante(DiamanteViewModel viewModel)
    {
        GerarDiamanteDto dto = mapper.Map<GerarDiamanteDto>(viewModel);

        Result<ResultadoDiamanteDto> resultado = servicoDiamante.Gerar(dto);

        if (resultado.IsFailed)
        {
            foreach (IError erro in resultado.Errors)
                ModelState.AddModelError(string.Empty, erro.Message);

            return View(viewModel);
        }

        mapper.Map(resultado.Value, viewModel);

        return View(viewModel);
    }
}