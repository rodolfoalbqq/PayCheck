using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCheck
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var validador = new ValidadorCartao();
        
        while (true)
        {
            Console.WriteLine("\nDigite o número do cartão de crédito (ou 'sair' para encerrar):");
            string numeroCartao = Console.ReadLine();

            if (numeroCartao?.ToLower() == "sair")
            {
                Console.WriteLine("Programa encerrado.");
                break;
            }

            string resultado = validador.IdentificarBandeiraCartao(numeroCartao);
            Console.WriteLine(resultado);
            Console.WriteLine("----------------------------------------");
        }
        }
    }
}
