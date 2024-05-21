using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PracticasRazor.Pages
{
    public class PesoModel : PageModel
    {
        [BindProperty]
        public string peso { get; set; } = "";
        [BindProperty]
        public string altura { get; set; } = "";

        public double imc = 0;

        public String clasificacion = "";
        public void OnPost()
        {
            double p = Double.Parse(peso);
            double a = Double.Parse(altura);
            imc = p / (a * a);

            switch (imc)
            {
                case var n when n < 18:
                    clasificacion = "Peso Bajo";
                    break;
                case var n when n >= 18 && n < 25:
                    clasificacion = "Peso Normal";
                    break;
                case var n when n >= 25 && n < 27:
                    clasificacion = "Sobre peso";
                    break;
                case var n when n >= 27 && n < 30:
                    clasificacion = "Obesidad grado I";
                    break;
                case var n when n >= 30 && n < 40:
                    clasificacion = "Obesidad grado II";
                    break;
                case var n when n >= 40:
                    clasificacion = "Obesidad grado III";
                    break;
            }
        }
    }
}
