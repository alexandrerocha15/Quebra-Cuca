using FluentResults;
using QuebraCuca.Aplicacao.Compartilhado;
using QuebraCuca.Dominio.Modulos.ModuloRomano;

namespace QuebraCuca.Aplicacao.Modulos.ModuloNumerosRomanos;

public class ServicoNumerosRomanos : ServicoBase<NumerosRomanos>
{
    public Result<ResultadoNumerosRomanosDto> Gerar(GerarNumerosRomanosDto dto)
    {
        NumerosRomanos numerosRomanos = new(dto.Entrada);

        Result resultadoValidacao = ValidarEntidade(numerosRomanos);

        if (resultadoValidacao.IsFailed)
            return Result.Fail(resultadoValidacao.Errors);

        ResultadoNumerosRomanosDto resultado = new()
        {
            Resultado = numerosRomanos.Gerar()
        };

        return Result.Ok(resultado);
    }
}