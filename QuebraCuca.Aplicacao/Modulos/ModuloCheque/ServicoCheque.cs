using FluentResults;
using QuebraCuca.Aplicacao.Compartilhado;
using QuebraCuca.Dominio.Modulos.ModuloCheque;

namespace QuebraCuca.Aplicacao.Modulos.ModuloCheque;

public class ServicoCheque : ServicoBase<Cheque>
{
    public Result<ResultadoChequeDto> Gerar(GerarChequeDto dto)
    {
        Cheque cheque = new(dto.Valor);

        Result resultadoValidacao = ValidarEntidade(cheque);

        if (resultadoValidacao.IsFailed)
            return Result.Fail(resultadoValidacao.Errors);

        ResultadoChequeDto resultado = new()
        {
            ValorPorExtenso = cheque.GerarValorPorExtenso()
        };

        return Result.Ok(resultado);
    }
}
