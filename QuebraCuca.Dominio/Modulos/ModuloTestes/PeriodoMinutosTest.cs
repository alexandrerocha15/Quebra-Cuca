 /* namespace QuebraCuca4.Tests
{
    [TestClass]
    public sealed class PeriodoMinutosTest
    {
        [TestMethod]
        public void Deve_retornar_Um_Minuto()
        {
            var dataPassada = DateTime.Now.AddMinutes(-1);
            var dataPresente = DateTime.Now;
            var p = new PeriodoMinutosTest();

            var resultado = p.HumanizarDataEmMinutos(dataPresente, dataPassada);

            Assert.AreEqual("Há 1 minuto", resultado);
        }

        [TestMethod]
        public void Deve_retornar_Dois_Minutos()
        {
            var dataPassada = DateTime.Now.AddMinutes(-2);
            var dataPresente = DateTime.Now;
            var p = new PeriodoMinutosTest();

            var resultado = p.HumanizarDataEmMinutos(dataPresente, dataPassada);

            Assert.AreEqual("Há 2 minutos", resultado);
        }

        [TestMethod]
        public void Deve_retornar_Tres_Minutos()
        {
            var dataPassada = DateTime.Now.AddMinutes(-3);
            var dataPresente = DateTime.Now;
            var p = new PeriodoMinutosTest();

            var resultado = p.HumanizarDataEmMinutos(dataPresente, dataPassada);

            Assert.AreEqual("Há 3 minutos", resultado);
        }


        private string? HumanizarDataEmMinutos(DateTime dataPresente, DateTime dataPassada)
        {
            var diferenca = (dataPresente - dataPassada).Minutes;

            if (diferenca != 1)
                return($"Há {diferenca} minutos");

            return ("Há 1 minuto");
        }
    }


   
        
        diffSegundo = 
        diffminuto = 
        diffHora
                
    if (diffsegund == 0)
        return "Agora mesmo";
                
        if (diff) == 1
        return a um segundo                
    else      
        minuto plu
    */

