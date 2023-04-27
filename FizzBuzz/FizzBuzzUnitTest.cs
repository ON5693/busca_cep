using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FizzBuzz
{
    public class FizzBuzzUnitTest
    {
        private Dictionary<int, string[]> entradaSaida = new Dictionary<int, string[]>
        {
            { 3, new[] { "1", "2", "Fizz" } },
            { 5, new[] { "1","2","Fizz","4","Buzz" } },
            { 15, new[] {"1","2","Fizz","4","Buzz","Fizz","7","8","Fizz","Buzz","11","Fizz","13","14","FizzBuzz" } }
        };

        [TestCase(3)]
        [TestCase(5)]
        [TestCase(15)]
        public void MetodoTeste(int numeroTeste)
        {
            //Arrange

            //Act
            var resultado = FizzBuzz(numeroTeste).ToArray();

            //Assert
            var saidaEsperada = entradaSaida[numeroTeste];

            Assert.That(saidaEsperada.Length, Is.EqualTo(resultado.Count()));

            for (int i = 0; i < saidaEsperada.Length; i++)
            {
                Assert.That(saidaEsperada[i], Is.EqualTo(resultado[i]));
            }
        }

        /*
         * Dado um número inteiro, retorne um array de string onde:

          resposta[i] == "FizzBuzz" se i for divisível por 3 e por 5
          resposta[i] == "Fizz" se i for divisível por 3
          resposta[i] == "Buzz" se i for divisível por 5
          resposta[i] == valor de i como string, caso nenhuma regra anterior tenha sido atendida

          Exemplo 1:
            Input: n = 3
            Output: ["1","2","Fizz"]
          
          Exemplo 2:
            Input: n = 5
            Output: ["1","2","Fizz","4","Buzz"]

          Exemplo 3:
            Input: n = 15
            Output: ["1","2","Fizz","4","Buzz","Fizz","7","8","Fizz","Buzz","11","Fizz","13","14","FizzBuzz"]
         */
        public IEnumerable<string> FizzBuzz(int valor)
        {
            List<string> arrayFizzBuzz = new List<string>();
            
            for (int i = 1; i <= valor; i++)
            {
                string str = "";
                if (i % 3 == 0)
                {
                    str += "Fizz";
                }
                if (i % 5 == 0)
                {
                    str += "Buzz";
                }
                if (str.Length == 0)
                {
                    str = i.ToString();
                }
                arrayFizzBuzz.Add(str);
            }

            return arrayFizzBuzz;
        }
    }
}
