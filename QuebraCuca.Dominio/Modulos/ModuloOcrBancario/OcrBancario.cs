
using QuebraCuca.Dominio.Compartilhado;

namespace QuebraCuca.Dominio.Modulos.ModuloOcrBancario;

public sealed class OcrBancario : EntidadeBase<OcrBancario>
{
    public List<string> Linhas { get; private set; }

    public OcrBancario(List<string> linhas)
    {
        Linhas = linhas;
    }

    public override List<string> Validar()
    {
        List<string> erros = new();

        if (Linhas == null || Linhas.Count == 0)
        {
            erros.Add("Informe um arquivo com pelo menos uma conta.");
            return erros;
        }

        if (Linhas.Count % 4 == 3)
            Linhas.Add(string.Empty);

        if (Linhas.Count % 4 != 0)
            erros.Add("O arquivo deve conter registros de quatro linhas.");

        int quantidadeContas = Linhas.Count / 4;

        if (quantidadeContas > 500)
            erros.Add("O arquivo não pode conter mais de 500 contas.");

        for (int i = 0; i < Linhas.Count; i++)
        {
            if (i % 4 == 3)
            {
                if (!string.IsNullOrEmpty(Linhas[i]))
                    erros.Add($"A linha {i + 1} deve estar vazia.");
            }
            else
            {
                if (Linhas[i] == null || Linhas[i].Length != 27)
                {
                    erros.Add($"A linha {i + 1} deve conter exatamente 27 caracteres.");
                    continue;
                }

                foreach (char caractere in Linhas[i])
                {
                    if (caractere != ' ' &&
                        caractere != '_' &&
                        caractere != '|')
                    {
                        erros.Add($"A linha {i + 1} contém caracteres inválidos.");
                        break;
                    }
                }
            }
        }

        return erros;
    }

    public List<string> Processar()
    {
        Dictionary<string, char> digitos = CriarMapaDigitos();
        List<string> contas = new();

        for (int registro = 0; registro < Linhas.Count; registro += 4)
        {
            string conta = string.Empty;

            for (int coluna = 0; coluna < 27; coluna += 3)
            {
                string bloco =
                    Linhas[registro].Substring(coluna, 3) +
                    Linhas[registro + 1].Substring(coluna, 3) +
                    Linhas[registro + 2].Substring(coluna, 3);

                if (digitos.TryGetValue(bloco, out char digito))
                    conta += digito;
                else
                    conta += "?";
            }

            contas.Add(conta);
        }

        return contas;
    }

    private Dictionary<string, char> CriarMapaDigitos()
    {
        return new Dictionary<string, char>
        {
            { " _ " + "| |" + "|_|", '0' },
            { "   " + "  |" + "  |", '1' },
            { " _ " + " _|" + "|_ ", '2' },
            { " _ " + " _|" + " _|", '3' },
            { "   " + "|_|" + "  |", '4' },
            { " _ " + "|_ " + " _|", '5' },
            { " _ " + "|_ " + "|_|", '6' },
            { " _ " + "  |" + "  |", '7' },
            { " _ " + "|_|" + "|_|", '8' },
            { " _ " + "|_|" + " _|", '9' }
        };
    }
}
