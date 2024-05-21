using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PracticasRazor.Pages
{
    public class ExpresionModel : PageModel
    {
        private readonly ILogger<ExpresionModel> _logger;
        [BindProperty]
        public string a { get; set; } = "";
        [BindProperty]
        public string b { get; set; } = "";
        [BindProperty]
        public string n { get; set; } = "";
        [BindProperty]
        public string x { get; set; } = "";
        [BindProperty]
        public string y { get; set; } = "";

        public double resultado = 0;

        public double[][] combinaciones = [];

        public double igualdad = 0;

        public ExpresionModel(ILogger<ExpresionModel> logger)
        {
            _logger = logger;
        }


        public void OnPost()
        {
            _logger.LogInformation("OnPost");
            _logger.LogInformation("a: " + a);
            _logger.LogInformation("b: " + b);
            _logger.LogInformation("n: " + n);
            _logger.LogInformation("x: " + x);
            _logger.LogInformation("y: " + y);

            if (a != "" && b != "" && n != "" && x != "" && y != "")
            {
                //Formula de la expresion (ax+by) elevado a la n.
                resultado = Math.Pow((int.Parse(a) * int.Parse(x) + int.Parse(b) * int.Parse(y)), int.Parse(n));

                //Para resolver lo siguiente se realiza la combinacion de los valores de n y k donde k inicia en 0 y termina en 2 por el momento
                combinaciones = new double[int.Parse(n)+1][];
                _logger.LogInformation("Combinaciones: " + combinaciones.Length);
                for (int i = 0; i < combinaciones.Length; i++)
                {
                    combinaciones[i] = new double[2]; // or however many you need
                }

                // Se comprueba la igualdad de la expresion con la combinaciones anteriores, donde la igualdad de (ax+by) elevado a la n es (ax) elevado a la (n-k) menos (by) elevado a la k
                for (int k = 0; k <= int.Parse(n); k++)
                {
                    combinaciones[k][0] = Factorial(int.Parse(n)) / (Factorial(int.Parse(n) - k) * Factorial(k));
                    _logger.LogInformation("Factorial: " + n + "!" + " / " + n + "!" + " - " + k + "!" + " * " + k + "!");
                    _logger.LogInformation("Combinacion: " + combinaciones[k][0]);
                    _logger.LogInformation("Combinacion: (" + n + " " + k + ") * (" + a + " * " + x + ")^(" + n + " - " + k + ") * (" + b + " * " + y + ")^" + k);
                    combinaciones[k][1] = combinaciones[k][0] * Math.Pow(int.Parse(a) * int.Parse(x), int.Parse(n) - k) * Math.Pow(int.Parse(b) * int.Parse(y), k);
                    _logger.LogInformation("Combinacion: " + combinaciones[k][1]);
                }

                foreach(var item in combinaciones)
                {
                    igualdad += item[1];
                    _logger.LogInformation("Igualdad en combinaciones: " + igualdad);
                }
                _logger.LogInformation("Igualdad: " + igualdad);
                _logger.LogInformation("Resultado: " + resultado);

                
                
                
            }
            else
            {
                resultado = 0;
            }
        }

        public int Factorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            else
            {
                return n * Factorial(n - 1);
            }
        }
    }
}
