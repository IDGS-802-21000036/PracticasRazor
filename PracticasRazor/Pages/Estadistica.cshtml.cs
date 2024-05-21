using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PracticasRazor.Pages
{
    public class EstadisticaModel : PageModel
    {
        private readonly ILogger<EstadisticaModel> _logger;
        public EstadisticaModel(ILogger<EstadisticaModel> logger)
        {
            _logger = logger;
        }
        public int[] arregloAleatorio = Array.Empty<int>();
        public int[] arregloOrdenado = Array.Empty<int>();
        public int suma = 0;
        public double promedio = 0;
        public int[] moda = Array.Empty<int>();
        public double mediana = 0;

        public void OnPost()
        {
            Random random = new Random();
            arregloAleatorio = new int[20];
            for (int i = 0; i < arregloAleatorio.Length; i++)
            {
                arregloAleatorio[i] = random.Next(0, 100);
            }
            arregloOrdenado = arregloAleatorio.OrderBy(x => x).ToArray();
            suma = arregloAleatorio.Sum();
            promedio = arregloAleatorio.Average();
            // Para la moda solo se toman los que se repiten mas, si todos se repiten la misma cantidad, se toman todos
            var conteo = arregloAleatorio.GroupBy(x => x).Select(x => new { x.Key, Count = x.Count() }).OrderByDescending(x => x.Count).ToList();
            var max = conteo.Max(x => x.Count);
            moda = conteo.Where(x => x.Count == max).Select(x => x.Key).ToArray();

            if (arregloOrdenado.Length % 2 == 0)
            {
                mediana = (arregloOrdenado[(arregloOrdenado.Length / 2)-1] + arregloOrdenado[(arregloOrdenado.Length / 2)]) / 2;
            }
            else
            {
                mediana = arregloOrdenado[arregloOrdenado.Length / 2];
            }



        }
    }
}
