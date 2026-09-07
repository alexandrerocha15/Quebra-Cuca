using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using QuebraCuca.Aplicacao.Modulos.ModuloNumerosRomanos;

namespace QuebraCuca.WebApp.Modulos.ModuloNumerosRomanos;

public class NumerosRomanosController : Controller
{
    private readonly ServicoNumerosRomanos servicoNumerosRomanos;
    private readonly IMapper mapper;

    public NumerosRomanosController(
        ServicoNumerosRomanos servicoNumerosRomanos,
        IMapper mapper)
    {
        this.servicoNumerosRomanos = servicoNumerosRomanos;
        this.mapper = mapper;
    }

    [HttpGet]
    public IActionResult IndexNumerosRomanos()
    {
        return View(new NumerosRomanosViewModel());
    }

    [HttpPost]
    public IActionResult IndexNumerosRomanos(NumerosRomanosViewModel viewModel)
    {
        GerarNumerosRomanosDto dto = mapper.Map<GerarNumerosRomanosDto>(viewModel);

        Result<ResultadoNumerosRomanosDto> resultado =
            servicoNumerosRomanos.Gerar(dto);

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