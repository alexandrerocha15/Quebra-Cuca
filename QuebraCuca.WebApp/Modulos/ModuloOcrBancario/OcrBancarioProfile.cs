using AutoMapper;
using QuebraCuca.Aplicacao.Modulos.ModuloOcrBancario;

namespace QuebraCuca.WebApp.Modulos.ModuloOcrBancario;

public class OcrBancarioProfile : Profile
{
    public OcrBancarioProfile()
    {
        CreateMap<OcrBancarioResultadoDto, OcrBancarioViewModel>();
    }
}