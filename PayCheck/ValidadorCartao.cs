using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCheck
{
    internal class ValidadorCartao
    {
        public string IdentificarBandeiraCartao(string numeroCartao)
        {
            // Remove espaços e caracteres não numéricos
            numeroCartao = new string(numeroCartao.Where(char.IsDigit).ToArray());

            // Verifica se o número é válido
            if (string.IsNullOrEmpty(numeroCartao))
                return "Número de cartão inválido";

            // Visa - começa com 4
            if (numeroCartao.StartsWith("4"))
                return "Visa";

            // MasterCard - começa com 51-55 ou 2221-2720
            if ((numeroCartao.StartsWith("51") || numeroCartao.StartsWith("52") ||
                 numeroCartao.StartsWith("53") || numeroCartao.StartsWith("54") ||
                 numeroCartao.StartsWith("55")) ||
                (numeroCartao.StartsWith("2") &&
                 int.Parse(numeroCartao.Substring(0, 4)) >= 2221 &&
                 int.Parse(numeroCartao.Substring(0, 4)) <= 2720))
                return "MasterCard";

            // American Express - começa com 34 ou 37
            if (numeroCartao.StartsWith("34") || numeroCartao.StartsWith("37"))
                return "American Express";

            // Discover - começa com 6011, 65 ou 644-649
            if (numeroCartao.StartsWith("6011") || numeroCartao.StartsWith("65") ||
                (numeroCartao.StartsWith("64") &&
                 int.Parse(numeroCartao.Substring(0, 3)) >= 644 &&
                 int.Parse(numeroCartao.Substring(0, 3)) <= 649))
                return "Discover";

            // Hipercard - começa com 6062
            if (numeroCartao.StartsWith("6062"))
                return "Hipercard";

            // Elo - verifica os intervalos específicos
            string[] prefixosElo = { "4011", "4312", "4389" };
            if (prefixosElo.Any(prefix => numeroCartao.StartsWith(prefix)))
                return "Elo";

            return "Bandeira não identificada";
        }
    }
}
