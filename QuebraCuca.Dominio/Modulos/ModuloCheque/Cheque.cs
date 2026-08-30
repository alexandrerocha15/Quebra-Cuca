using QuebraCuca.Dominio.Compartilhado;

namespace QuebraCuca.Dominio.Modulos.ModuloCheque;

public class Cheque : EntidadeBase<Cheque>
{
    public decimal Valor { get; set; }
    public int Valor1  { get; set; } = 2;
    public decimal Valor2  { get; set; } = 2.2m;

    public Cheque(decimal valor)
    {
        Valor = valor;
    }

    public override List<string> Validar()
    {
        List<string> erros = [];

        if (Valor <= 0)
            erros.Add("O valor deve ser maior que zero.");

        return erros;
    }

    public string GerarValorPorExtenso()
    {
        int reais = (int)Valor;
        int centavos = (int)((Valor - reais) * 100);

        string valorPorExtenso = "";

        // Reais
        if (reais > 0)
        {
            valorPorExtenso = GerarNumeroPorExtenso(reais);

            if (reais == 1)
                valorPorExtenso += " real";
            else
                valorPorExtenso += " reais";
        }

        // Centavos
        if (centavos > 0)
        {
            if (reais > 0)
                valorPorExtenso += " e ";

            valorPorExtenso += GerarNumeroPorExtenso(centavos);

            if (centavos == 1)
                valorPorExtenso += " centavo";
            else
                valorPorExtenso += " centavos";
        }

        return valorPorExtenso;
    }

    private string GerarNumeroPorExtenso(int numero)
    {
        if (numero < 10)
            return GerarUnidade(numero);

        if (numero <= 19)
            return GerarEspeciais(numero);

        if (numero < 100)
            return GerarDezena(numero);

        return "O valor excede o limite disponível.";
    }

    private string GerarUnidade(int unidade)
    {
        string[] unidades =
        [
            "",
            "um",
            "dois",
            "três",
            "quatro",
            "cinco",
            "seis",
            "sete",
            "oito",
            "nove"
        ];

        return unidades[unidade];
    }

    private string GerarEspeciais(int especial)
    {
        string[] especiais =
        [
            "dez",
            "onze",
            "doze",
            "treze",
            "quatorze",
            "quinze",
            "dezesseis",
            "dezessete",
            "dezoito",
            "dezenove"
        ];

        return especiais[especial - 10];
    }

    private string GerarDezena(int numero)
    {
        int dezena = numero / 10;
        int unidade = numero % 10;

        string[] dezenas =
        [
            "",
            "dez",
            "vinte",
            "trinta",
            "quarenta",
            "cinquenta",
            "sessenta",
            "setenta",
            "oitenta",
            "noventa"
        ];

        if (unidade == 0)
            return dezenas[dezena];

        return $"{dezenas[dezena]} e {GerarUnidade(unidade)}";
    }

}