using FluentResults;
using QuebraCuca.Aplicacao.Compartilhado;
using QuebraCuca.Dominio.Modulos.ModuloDiamante;

namespace QuebraCuca.Aplicacao.Modulos.ModuloDiamante;

public class ServicoDiamante : ServicoBase<Diamante>
{
    public Result<ResultadoDiamanteDto> Gerar(GerarDiamanteDto dto)
    {
        Diamante diamante = new(dto.Tamanho);

        Result resultadoValidacao = ValidarEntidade(diamante);

        if (resultadoValidacao.IsFailed)
            return Result.Fail(resultadoValidacao.Errors);

        ResultadoDiamanteDto resultado = new()
        {
            Linhas = diamante.Gerar()
        };

        return Result.Ok(resultado);
    }
}