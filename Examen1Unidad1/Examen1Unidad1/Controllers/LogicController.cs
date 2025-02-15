
using Examen1Unidad1.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ExamenApiRest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogicController : ControllerBase
    {
        [HttpGet("is-prime/{number}")]
        public ActionResult<PrimeEntity> IsPrime(int number)
        {
            var response = new PrimeEntity { Number = number };

            if (number <= 1)
            {
                response.IsPrime = false;
                return Ok(response);
            }

            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    response.IsPrime = false;
                    return Ok(response);
                }
            }
            response.IsPrime = true;
            return Ok(response);
        }

        [HttpGet("factorial/{number}")]
        public ActionResult<FactorialEntity> Factorial(int number)
        {
            if (number < 0)
            {
                return BadRequest("El número debe ser positivo.");
            }

            long result = 1;
            for (int i = 1; i <= number; i++)
            {
                result *= i;
            }

            var response = new FactorialEntity { Number = number, Factorial = result };
            return Ok(response);
        }

        [HttpGet("fibonacci/{limit}")]
        public ActionResult<FibonacciEntity> Fibonacci(int limit)
        {
            if (limit <= 0)
            {
                return BadRequest("El límite debe ser un número entero positivo.");
            }

            var sequence = new List<int>();
            int a = 0, b = 1;

            while (a <= limit)
            {
                sequence.Add(a);
                int temp = a;
                a = b;
                b = temp + b;
            }

            var response = new FibonacciEntity { Limit = limit, Sequence = sequence };
            return Ok(response);

        }

        [HttpGet("count-vowels")]
        public ActionResult<VowelEntity> CountVowels([FromQuery] string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return BadRequest("El texto no puede estar vacío.");
            }

            string vowels = "AEIOUaeiou";

            int vowelCount = text.Count(c => vowels.Contains(c));

            var response = new VowelEntity { Text = text, VowelCount = vowelCount };
            return Ok(response);
        }


        [HttpGet("is-palindrome/{word}")]
        public ActionResult<PalindromeEntity> IsPalindrome(string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                return BadRequest("La palabra no puede estar vacía.");
            }

            string lowerWord = word.ToLower();

            string reversedWord = new string(lowerWord.Reverse().ToArray());

            bool isPalindrome = lowerWord.Equals(reversedWord, StringComparison.OrdinalIgnoreCase);

            var response = new PalindromeEntity { Word = word, IsPalindrome = isPalindrome };
            return Ok(response);
        }
    }
}

