using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using QuebraCuca.Aplicacao.Modulos.ModuloOcrBancario;

namespace QuebraCuca.WebApp.Modulos.ModuloOcrBancario;

public class OcrBancarioController : Controller
{
    private readonly ServicoOcrBancario servico;
    private readonly IMapper mapper;

    public OcrBancarioController(ServicoOcrBancario servico, IMapper mapper)
    {
        this.servico = servico;
        this.mapper = mapper;
    }

    [HttpGet]
    public IActionResult IndexOcrBancario()
    {
        return View(new OcrBancarioViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> IndexOcrBancario(OcrBancarioViewModel viewModel)
    {
        if (viewModel.Arquivo == null || viewModel.Arquivo.Length == 0)
        {
            ModelState.AddModelError(string.Empty, "Selecione um arquivo TXT.");
            return View(viewModel);
        }

        if (!string.Equals(
            Path.GetExtension(viewModel.Arquivo.FileName),
            ".txt",
            StringComparison.OrdinalIgnoreCase))
        {
            ModelState.AddModelError(string.Empty, "O arquivo deve ser do tipo TXT.");
            return View(viewModel);
        }

        List<string> linhas = new();

        using (StreamReader leitor = new(viewModel.Arquivo.OpenReadStream()))
        {
            while (!leitor.EndOfStream)
            {
                string? linha = await leitor.ReadLineAsync();
                linhas.Add(linha ?? string.Empty);
            }

            Console.WriteLine($"Quantidade de linhas: {linhas.Count}");

            for (int i = 0; i < linhas.Count; i++)
            {
                Console.WriteLine($"Linha {i + 1}: {linhas[i].Length} caracteres");
            }
        }

        ProcessarOcrDto dto = new()
        {
            Linhas = linhas
        };

        Result<OcrBancarioResultadoDto> resultado = servico.Processar(dto);

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