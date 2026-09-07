using QuebraCuca.Dominio.Compartilhado;

namespace QuebraCuca.Dominio.Modulos.ModuloRomano;

public class NumerosRomanos : EntidadeBase<NumerosRomanos>
{
    public string Entrada { get; set; }

    public NumerosRomanos(string entrada)
    {
        Entrada = entrada;
    }

    public override List<string> Validar()
    {
        List<string> erros = [];

        if (string.IsNullOrWhiteSpace(Entrada))
        {
            erros.Add("A entrada deve ser preenchida.");
            return erros;
        }

        string tipoEntrada = ValidarEntrada();

        if (tipoEntrada == "Invalido")
        {
            erros.Add("A entrada deve conter somente números ou somente algarismos romanos.");
            return erros;
        }

        if (tipoEntrada == "Numero")
        {
            if (!int.TryParse(Entrada, out int numero) || numero < 1 || numero > 3999)
                erros.Add("O número deve estar entre 1 e 3999.");
        }
        else if (!RomanoValido(Entrada.ToUpper()))
        {
            erros.Add("O número romano informado é inválido.");
        }

        return erros;
    }

    public string ValidarEntrada()
    {
        if (Entrada.All(c => char.IsDigit(c)))
            return "Numero";

        if (Entrada.All(c => char.IsLetter(c)))
            return "Romano";

        return "Invalido";
    }

    public string Gerar()
    {
        List<string> erros = Validar();

        if (erros.Count > 0)
            return erros.First();

        if (ValidarEntrada() == "Numero")
            return GerarRomano();

        return GerarNumero();
    }

    public string GerarNumero()
    {
        string romano = Entrada.ToUpper();
        int total = 0;

        for (int i = 0; i < romano.Length; i++)
        {
            int valorAtual = ObterValor(romano[i]);

            if (i + 1 < romano.Length)
            {
                int proximoValor = ObterValor(romano[i + 1]);

                if (valorAtual < proximoValor)
                    total -= valorAtual;
                else
                    total += valorAtual;
            }
            else
                total += valorAtual;
        }

        return total.ToString();
    }

    public string GerarRomano()
    {
        int numero = int.Parse(Entrada);

        (int Valor, string Simbolo)[] valoresRomanos =
        [
            (1000, "M"),
            (900, "CM"),
            (500, "D"),
            (400, "CD"),
            (100, "C"),
            (90, "XC"),
            (50, "L"),
            (40, "XL"),
            (10, "X"),
            (9, "IX"),
            (5, "V"),
            (4, "IV"),
            (1, "I")
        ];

        string resultado = "";

        foreach ((int valor, string simbolo) in valoresRomanos)
        {
            while (numero >= valor)
            {
                resultado += simbolo;
                numero -= valor;
            }
        }

        return resultado;
    }

    private bool RomanoValido(string romano)
    {
        if (romano.Any(c => ObterValor(c) == 0))
            return false;

        int total = 0;

        for (int i = 0; i < romano.Length; i++)
        {
            int valorAtual = ObterValor(romano[i]);

            if (i + 1 < romano.Length && valorAtual < ObterValor(romano[i + 1]))
                total -= valorAtual;
            else
                total += valorAtual;
        }

        if (total < 1 || total > 3999)
            return false;

        string entradaOriginal = Entrada;
        Entrada = total.ToString();
        string romanoCanonico = GerarRomano();
        Entrada = entradaOriginal;

        return romano == romanoCanonico;
    }

    private int ObterValor(char romano)
    {
        return romano switch
        {
            'I' => 1,
            'V' => 5,
            'X' => 10,
            'L' => 50,
            'C' => 100,
            'D' => 500,
            'M' => 1000,
            _ => 0
        };
    }
}
