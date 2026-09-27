using FluentResults;
using QuebraCuca.Aplicacao.Compartilhado;
using QuebraCuca.Dominio.Modulos.ModuloDataHumanizada;

namespace QuebraCuca.Aplicacao.Modulos.ModuloDataHumanizada;

public class ServicoDataHumanizada : ServicoBase<DataHumanizada>
{
    public Result<DataHumanizadaResultadoDto> Humanizar(HumanizarDataDto dto)
    {
        DataHumanizada dataHumanizada = new(
            dto.Data,
            dto.DataReferencia
        );

        Result resultadoValidacao = ValidarEntidade(dataHumanizada);

        if (resultadoValidacao.IsFailed)
            return Result.Fail<DataHumanizadaResultadoDto>(
                resultadoValidacao.Errors
            );

        DataHumanizadaResultadoDto resultado = new()
        {
            TextoHumanizado = dataHumanizada.Humanizar()
        };

        return Result.Ok(resultado);
    }
}
