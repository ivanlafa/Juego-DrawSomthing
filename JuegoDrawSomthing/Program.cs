using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoDrawSomthing
{
    class Program
    {
        static void Main()
        {
            //BIENVENIDA
            Console.Write("---------Juego DrawSomething-----------\n");
            Console.Write("Pulsa Enter para Jugar!\n");
            Console.ReadLine();
            Console.Clear();


            Console.WriteLine("Ingresa 12 Palabras para comnzara a jugar:");
            string letrasDisponibles = Console.ReadLine().ToUpper();

            Console.WriteLine("Ingresa la longitud de la palabra a buscar:");
            int longitudPalabra = int.Parse(Console.ReadLine());

            List<string> palabrasPosibles = GenerarPalabras(letrasDisponibles, longitudPalabra);

            Console.WriteLine("Resultado:");
            foreach (var palabra in palabrasPosibles)
            {
                // Verificar si la palabra es "tijeras"
                Console.WriteLine($"-> {palabra}");

                if (palabra.ToLower() == "tijeras")
                {
                    Console.WriteLine($"¡GANADOR! Encontraste la palabra: {palabra}");
                    Console.ReadLine();
                    return;
                }            
            }
            Console.WriteLine($"No se encontro la palabra (TIJERAS), ¡Intenta nuevamente!");
            Console.ReadLine();
            Console.Clear();


        }

        //generar palabras posibles
        static List<string> GenerarPalabras(string letrasDisponibles, int longitudPalabra)
        {
            List<string> palabrasPosibles = new List<string>();
            HashSet<string> letraUsada = new HashSet<string>();

            //LLAMAMOS AL METODOS QUE NO GENERO LA CADDENA
            GenerarPalabrasRecursivo(letrasDisponibles, longitudPalabra, "", palabrasPosibles, letraUsada);

            return palabrasPosibles;
        }

        //generar la cadena de palabras
        static void GenerarPalabrasRecursivo(string letrasDisponibles, int longitudPalabra, string palabraActual, List<string> palabrasPosibles, HashSet<string> letraUsada)
        {
            // Caso base: si la longitud de la palabra es 0, agregar la palabra actual a la lista de palabras posibles
            if (longitudPalabra == 0)
            {
                palabrasPosibles.Add(palabraActual);
                return;
            }
            //recorreme cada letra en las letras que esten disponible
            foreach (char letra in letrasDisponibles)
            {
                if (letraUsada.Contains(letra.ToString()))
                {
                    continue;
                  
                  
                }
                //marcame la letra utilizada
                letraUsada.Add(letra.ToString());

                string nuevasLetrasDisponibles = letrasDisponibles.Replace(letra.ToString(), "");
                GenerarPalabrasRecursivo(nuevasLetrasDisponibles, longitudPalabra - 1, palabraActual + letra, palabrasPosibles, letraUsada);

                letraUsada.Remove(letra.ToString());
            }
        }
    }
}
