using QuebraCuca.Dominio.Compartilhado;

namespace QuebraCuca.Dominio.Modulos.ModuloDiamante;

public class Diamante : EntidadeBase<Diamante>
{
    public int Tamanho { get; set; }

    public override List<string> Validar()
    {
        List<string> erros = [];

        if (Tamanho <= 0)
            erros.Add("O tamanho deve ser maior que zero.");

        if (Tamanho % 2 == 0)
            erros.Add("O tamanho deve ser ímpar.");

        return erros;
    }
    
    public Diamante(int tamanho)
    {
        Tamanho = tamanho;
    }

    public List<string> Gerar()
    {
        List<string> linhas = [];

        int linhaCentral = Tamanho / 2;

        for (int linha = 0; linha < Tamanho; linha++)
        {
            int espacos;
            int quantidadeX;

            if (linha <= linhaCentral)
            {
                espacos = linhaCentral - linha;
                quantidadeX = linha * 2 + 1;
            }
            else
            {
                espacos = linha - linhaCentral;
                quantidadeX = (Tamanho - linha - 1) * 2 + 1;
            }

            string resultado =
                new string(' ', espacos) +
                new string('X', quantidadeX);

            linhas.Add(resultado);
        }

        return linhas;
    }
}