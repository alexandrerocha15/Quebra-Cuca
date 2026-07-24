using AutoMapper;
using QuebraCuca.Aplicacao.Modulos.ModuloDiamante;
using QuebraCuca.WebApp.Modulos.ModuloDiamante.ViewModels;

namespace QuebraCuca.WebApp.Modulos.ModuloDiamante;

public class DiamanteProfile : Profile
{
    public DiamanteProfile()
    {
        CreateMap<DiamanteViewModel, GerarDiamanteDto>();

        CreateMap<ResultadoDiamanteDto, DiamanteViewModel>();
    }
}