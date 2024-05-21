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
             * Seg�n el historiador Cayo Suetonio el dictador perpetuus Julio C�sar utilizaba un c�digo cuando quer�a mantener en secreto un mensaje. 
             * Tomaba cada una de las 25letras del alfabeto latino (A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, X, Y, Z) y las sustitu�a 
             * por otra letra situada n posiciones m�s a la derecha en el orden alfab�tico anterior. As�, si n=3, a la A le corresponder�a la D. 
             * Este simple c�digo  adem�s  de  ser  un  c�digo  de  sustituci�n  es  un  c�digo  de  rotaci�n  ya  que para las �ltimas letras 
             * se vuelve a retomar el conteo por el principio. Esto es, de nuevo para n=3, a la Xle corresponder�a la A. Ahondando en el ejemplo, 
             * para n=3 si el emperador afirmaba que "la suerte est� echada" (ALEA IACTA EST) el mensaje cifradoser�a DOHD LDFBD HAB.
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
