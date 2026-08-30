// See https://aka.ms/new-console-template for more information

/*using System.Globalization;

Console.WriteLine("Digite o valor do cheque por extenso: ");
int valorInformado = 232;

int valorConvertido = Convert.ToInt32(valorInformado);

string[] unidades =
{
    "",
    "um",
    "dois",
    "três",
    "quatro",
    "cinco",
    "seis",
    "sete",
    "oito",
    "nove",
};

string[] dezenas =
{
    "vinte",
    "trinta",
    "quarenta",
    "cinquenta",
    "sessenta",
    "setenta",
    "oitenta",
    "noventa",
    "cento",
};

string[] numEspeciais =
{
    "",
    "dez",
    "onze",
    "doze",
    "treze",
    "quatorze",
    "quinze",
    "dezeseis",
    "dezoito",
    "dezenove"
};

string[] centenas =
{
    "cento",
    "duzentos",
    "trezentos",
    "quatrocentos",
    "quinhentos",
    "seiscentos",
    "setecentos",
    "oitocentos",
    "novecentos"
};

string[] milhoes =
{
    "",
    "um milhão",
    "dois milhões",
    "três milhões",
    "quatro milhões",
    "cinco milhões",
    "seis milhões",
    "sete milhões",
    "oito milhões",
    "nove milhões",
};

string saida = "Seu cheque é de: ";

if (valorConvertido < 10)
{
    int posDez = valorConvertido % 10;
    saida += $"{unidades[posDez]} reais";

    Console.WriteLine();
    Console.WriteLine(saida);
}
else if (valorConvertido < 100)
{
    int posDez = valorConvertido / 10-2;
    saida += $"{dezenas[posDez]} e ";

    int posUni = valorConvertido % 10;
    saida += $"{unidades[posUni]} reais";

    Console.WriteLine();
    Console.WriteLine(saida);

}
else if (valorConvertido < 1000)
{
    int posCen = valorConvertido / 100 - 1;
        saida += $"{centenas[posCen]} e ";

    int posDez = valorConvertido % 10;
        saida += $"{dezenas[posDez]} e ";

    int posUni = valorConvertido % 10;
        saida += $"{unidades[posUni]} reais";

    Console.WriteLine();
    Console.WriteLine(saida);

}
 
*/