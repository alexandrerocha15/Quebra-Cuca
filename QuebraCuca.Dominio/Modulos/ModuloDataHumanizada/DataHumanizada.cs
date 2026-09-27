using QuebraCuca.Dominio.Compartilhado;

namespace QuebraCuca.Dominio.Modulos.ModuloDataHumanizada;

public sealed class DataHumanizada : EntidadeBase<DataHumanizada>
{
    public DateTime Data { get; private set; }
    public DateTime DataReferencia { get; private set; }

    public DataHumanizada(DateTime data, DateTime dataReferencia)
    {
        Data = data;
        DataReferencia = dataReferencia;
    }

    public override List<string> Validar()
    {
        List<string> erros = new();

        if (Data == default)
            erros.Add("Informe uma data.");

        if (DataReferencia == default)
            erros.Add("A data de referência é inválida.");

        if (Data != default && DataReferencia != default)
        {
            if (Data > DataReferencia)
                erros.Add("A data não pode estar no futuro.");
        }

        return erros;
    }

    public string Humanizar()
    {
        TimeSpan diferenca = DataReferencia - Data;

        // Segundos
        if (diferenca.TotalSeconds < 1)
            return "Agora mesmo";

        if (diferenca.TotalSeconds < 60)
        {
            int segundos = (int)diferenca.TotalSeconds;

            if (segundos == 1)
                return "Há 1 segundo";
            else
                return $"Há {segundos} segundos";
        }

        // Minutos
        if (diferenca.TotalMinutes < 60)
        {
            int minutos = (int)diferenca.TotalMinutes;

            if (minutos == 1)
                return "Há 1 minuto";
            else
                return $"Há {minutos} minutos";
        }

        // Horas
        if (diferenca.TotalHours < 24)
        {
            int horas = (int)diferenca.TotalHours;

            if (horas == 1)
                return "Há 1 hora";
            else
                return $"Há {horas} horas";
        }

        // Converter o intervalo em dias completos
        int diasTotais = (int)diferenca.TotalDays;

        // Calcular anos, meses, semanas e dias
        int anos = diasTotais / 365;

        int diasRestantes = diasTotais % 365;

        int meses = diasRestantes / 30;

        diasRestantes = diasRestantes % 30;

        int semanas = diasRestantes / 7;

        int dias = diasRestantes % 7;

        // Ano
        if (anos > 0)
        {
            if (anos == 1)
                return "Um ano atrás";
            else
                return $"{anos} anos atrás";
        }

        // Mes
        if (meses > 0)
        {
            string textoMeses;

            if (meses == 1)
                textoMeses = "Um mês";
            else if (meses == 2)
                textoMeses = "Dois meses";
            else
                textoMeses = $"{meses} meses";

            // Mes e semana
            if (semanas > 0)
            {
                if (semanas == 1)
                    return $"{textoMeses} e uma semana atrás";
                else if (semanas == 2)
                    return $"{textoMeses} e duas semanas atrás";
                else
                    return $"{textoMeses} e {semanas} semanas atrás";
            }

            // Mes e dia
            if (dias > 0)
            {
                if (dias == 1)
                    return $"{textoMeses} e um dia atrás";
                else if (dias == 2)
                    return $"{textoMeses} e dois dias atrás";
                else
                    return $"{textoMeses} e {dias} dias atrás";
            }

            return $"{textoMeses} atrás";
        }

        // Semana
        if (semanas > 0)
        {
            if (semanas == 1)
                return "Uma semana atrás";
            else if (semanas == 2)
                return "Duas semanas atrás";
            else
                return $"{semanas} semanas atrás";
        }

        // Dia
        if (dias == 1)
            return "Um dia atrás";
        else
            return $"{dias} dias atrás";
    }
}
