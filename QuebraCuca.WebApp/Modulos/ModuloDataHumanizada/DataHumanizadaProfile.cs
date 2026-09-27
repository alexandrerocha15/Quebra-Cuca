using AutoMapper;
using QuebraCuca.Aplicacao.Modulos.ModuloDataHumanizada;

namespace QuebraCuca.WebApp.Modulos.ModuloDataHumanizada;

public class DataHumanizadaProfile : Profile
{
    public DataHumanizadaProfile()
    {
        CreateMap<DataHumanizadaViewModel, HumanizarDataDto>();
        CreateMap<DataHumanizadaResultadoDto, DataHumanizadaViewModel>();
    }
}
