using FluentResults;
using QuebraCuca.Aplicacao.Compartilhado;
using QuebraCuca.Dominio.Modulos.ModuloOcrBancario;

namespace QuebraCuca.Aplicacao.Modulos.ModuloOcrBancario;

public class ServicoOcrBancario : ServicoBase<OcrBancario>
{
    public Result<OcrBancarioResultadoDto> Processar(ProcessarOcrDto dto)
    {
        OcrBancario ocrBancario = new(dto.Linhas);

        Result resultadoValidacao = ValidarEntidade(ocrBancario);

        if (resultadoValidacao.IsFailed)
            return Result.Fail(resultadoValidacao.Errors);

        OcrBancarioResultadoDto resultado = new()
        {
            Contas = ocrBancario.Processar()
        };

        return Result.Ok(resultado);
    }
}
