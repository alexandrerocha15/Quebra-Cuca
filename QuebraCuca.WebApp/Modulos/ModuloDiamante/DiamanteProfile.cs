using AutoMapper;
using QuebraCuca.Aplicacao.Modulos.ModuloDiamante;

namespace QuebraCuca.WebApp.Modulos.ModuloDiamante;

public class DiamanteProfile : Profile
{
    public DiamanteProfile()
    {
        CreateMap<DiamanteViewModel, GerarDiamanteDto>();

        CreateMap<ResultadoDiamanteDto, DiamanteViewModel>();
    }
}