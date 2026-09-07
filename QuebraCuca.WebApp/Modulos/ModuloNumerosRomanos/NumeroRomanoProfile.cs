using AutoMapper;
using QuebraCuca.Aplicacao.Modulos.ModuloNumerosRomanos;

namespace QuebraCuca.WebApp.Modulos.ModuloNumerosRomanos;

public class NumerosRomanosProfile : Profile
{
    public NumerosRomanosProfile()
    {
        CreateMap<NumerosRomanosViewModel, GerarNumerosRomanosDto>();
        CreateMap<ResultadoNumerosRomanosDto, NumerosRomanosViewModel>();
    }
}