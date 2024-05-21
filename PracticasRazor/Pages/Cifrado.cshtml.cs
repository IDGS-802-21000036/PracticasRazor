using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PracticasRazor.Pages
{
    public class CifradoModel : PageModel
    {
        private readonly ILogger<ExpresionModel> _logger;
        public CifradoModel(ILogger<ExpresionModel> logger)
        {
            _logger = logger;
        }
        [BindProperty]
        public string mensaje { get; set; } = "";
        [BindProperty]
        public string clave { get; set; } = "";

        public string cifrado { get; set; } = "";

        public void OnPost()
        {
            /*
             * Según el historiador Cayo Suetonio el dictador perpetuus Julio César utilizaba un código cuando quería mantener en secreto un mensaje. 
             * Tomaba cada una de las 25letras del alfabeto latino (A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, X, Y, Z) y las sustituía 
             * por otra letra situada n posiciones más a la derecha en el orden alfabético anterior. Así, si n=3, a la A le correspondería la D. 
             * Este simple código  además  de  ser  un  código  de  sustitución  es  un  código  de  rotación  ya  que para las últimas letras 
             * se vuelve a retomar el conteo por el principio. Esto es, de nuevo para n=3, a la Xle correspondería la A. Ahondando en el ejemplo, 
             * para n=3 si el emperador afirmaba que "la suerte está echada" (ALEA IACTA EST) el mensaje cifradosería DOHD LDFBD HAB.
             *
             */

            
            string mensaje = this.mensaje.ToUpper();

            _logger.LogInformation("Mensaje: " + mensaje);
            _logger.LogInformation("Clave: " + this.clave);


            for (int i = 0; i < mensaje.Length; i++)
            {
                int n = int.Parse(this.clave);
                if (mensaje[i] == ' ')
                {
                    cifrado += " ";
                }
                else
                {
                    
                    int ascii = (int)mensaje[i];
                    int cifradoAscii = ascii;
                    while (n > 0)
                    {
                        if ((char)cifradoAscii == 'W')
                        {
                            cifradoAscii = +2;
                            n--;
                        }
                        else { 
                            cifradoAscii++;
                            n--;
                        }
                    }
                    if (cifradoAscii > 90)
                    {
                        cifradoAscii = cifradoAscii - 25;
                    }
                    if((char) cifradoAscii == 'W')
                    {
                        cifradoAscii = cifradoAscii + 1;
                    }
                    cifrado += (char)cifradoAscii;
                }
            }
            _logger.LogInformation("Cifrado: " + cifrado);

        }
    }
}
