using AutoMapper;
using QuebraCuca.Aplicacao.Modulos.ModuloCheque;

namespace QuebraCuca.WebApp.Modulos.ModuloCheque;

public class ChequeProfile : Profile
{
    public ChequeProfile()
    {
        CreateMap<ChequeViewModel, GerarChequeDto>();
        CreateMap<ResultadoChequeDto, ChequeViewModel>();
    }
}