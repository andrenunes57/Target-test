using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography.X509Certificates;

namespace TargetTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TargetController : ControllerBase
    {
        [HttpGet]
        [Route("PrimeiroTeste")]
        public async Task<IActionResult> PrimeiroTeste()
        {
            int INDICE = 13, SOMA = 0, K = 0;

            while (K < INDICE)
            {
                K = K + 1;
                SOMA = SOMA + K;
            }

            return Ok(SOMA);
        }


        [HttpGet]
        [Route("ChecarNumeroFibonacci")]
        public async Task<IActionResult> ChecarNumeroFibonacci(int numberParam)
        {

            bool isFibonacciNumber(int numberParam)
            {
                bool boolValue = false;

                int a = 0;
                int b = 1;

                while (b < numberParam)
                {
                    int c = a + b;
                    a = b;
                    b = c;
                }

                if (b == numberParam || a == numberParam)
                {
                    boolValue = true;
                    return boolValue;
                }
                else if (b > numberParam)
                {
                    boolValue = false;
                    return boolValue;
                }
                else { return false; }
            }

            string message = "";

            if (isFibonacciNumber(numberParam))
            {
                message = $"{numberParam} é Fibonacci";
            }
            else
            {
                message = $"{numberParam} NÃO é Fibonacci";
            }

            return Ok(message);
        }

        [HttpPost]
        [Route("VetorDeFaturamento")]
        public async Task<IActionResult> VetorDeFaturamento([FromBody] JArray arrDays)
        {
            List<decimal> ValuesList = new List<decimal>();

            decimal minValue = 0.0M;
            decimal maxValue = 0.0M;
            decimal mediaMensal = 0.0M;
            int numerDiasSuperiorMediaMensal = 0;

            foreach (JObject obj in arrDays)
            {
                ValuesList.Add(Convert.ToDecimal(obj["valor"]));
            }

            minValue = ValuesList.Min();
            maxValue = ValuesList.Max();

            mediaMensal = ValuesList.Average();

            foreach (JObject obj in arrDays)
            {
                if (Convert.ToDecimal(obj["valor"]) > mediaMensal)
                {
                    numerDiasSuperiorMediaMensal++;
                }
            }

            return Ok($"O menor valor de faturamento ocorrido em um dia do mês = {minValue}{Environment.NewLine}" +
                $"O maior valor de faturamento ocorrido em um dia do mês = {maxValue}{Environment.NewLine}" +
                $"Número de dias no mês em que o valor de faturamento diário foi superior à média mensal = {numerDiasSuperiorMediaMensal}");
        }

        [HttpGet]
        [Route("PorcentagemDeFaturamento")]
        public async Task<IActionResult> PorcentagemDeFaturamento() 
        {
            List<decimal> valoresDeFaturamento = new List<decimal>
            { 67836.43M, 36678.66M, 29229.88M, 27165.48M, 19849.53M };

            decimal valorTotal = valoresDeFaturamento.Sum();

            decimal porcentagemSP = (valoresDeFaturamento[0] / valorTotal) * 100;
            decimal porcentagemRJ = (valoresDeFaturamento[1] / valorTotal) * 100;
            decimal porcentagemMG = (valoresDeFaturamento[2] / valorTotal) * 100;
            decimal porcentagemES = (valoresDeFaturamento[3] / valorTotal) * 100;
            decimal porcentagemOutros = (valoresDeFaturamento[4] / valorTotal) * 100;

            return Ok($"SP: {decimal.Round(porcentagemSP,2)}%{Environment.NewLine}" +
                $"RJ: {decimal.Round(porcentagemRJ, 2)}%{Environment.NewLine}" +
                $"MG: {decimal.Round(porcentagemMG, 2)}%{Environment.NewLine}" +
                $"ES: {decimal.Round(porcentagemES, 2)}%{Environment.NewLine}" +
                $"Outros: {decimal.Round(porcentagemOutros, 2)}%{Environment.NewLine}");
        }

        [HttpGet]
        [Route("InverterString")]
        public async Task<IActionResult> InverterString(string stringToReverse)
        {
            
            string ReverseStringWithoutInbuiltMethod(string stringToReverse)
            {
                string reversestring = "";
                int length;

                length = stringToReverse.Length - 1;

                while (length >= 0)
                {
                    reversestring = reversestring + stringToReverse[length];
                    length--;
                }

                return reversestring;
            }

            return Ok(ReverseStringWithoutInbuiltMethod(stringToReverse));
        }
    }
}
