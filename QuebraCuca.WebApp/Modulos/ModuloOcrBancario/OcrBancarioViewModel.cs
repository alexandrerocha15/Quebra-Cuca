using Microsoft.AspNetCore.Http;

namespace QuebraCuca.WebApp.Modulos.ModuloOcrBancario;

public class OcrBancarioViewModel
{
    public IFormFile? Arquivo { get; set; }
    public List<string> Contas { get; set; } = new();
}