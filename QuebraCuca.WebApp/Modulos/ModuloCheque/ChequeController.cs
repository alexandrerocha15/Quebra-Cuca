using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using QuebraCuca.Aplicacao.Modulos.ModuloCheque;
using QuebraCuca.WebApp.Modulos.ModuloCheque;

public class ChequeController : Controller
{
    private readonly ServicoCheque servicoCheque;
    private readonly IMapper mapper;

    public ChequeController(
        ServicoCheque servicoCheque,
        IMapper mapper)
    {
        this.servicoCheque = servicoCheque;
        this.mapper = mapper;
    }

    [HttpGet]
    public IActionResult IndexCheque()
    {
        return View(new ChequeViewModel());
    }

    [HttpPost]
    public IActionResult IndexCheque(ChequeViewModel viewModel)
    {
        GerarChequeDto dto = mapper.Map<GerarChequeDto>(viewModel);

        Result<ResultadoChequeDto> resultado = servicoCheque.Gerar(dto);

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