using System;
using System.Collections.Generic;
using System.Linq;

namespace DiagnosticoEnfermedades
{
    public class Program
    {
        static void Main(string[] args)
        {
            Enfermedad cancer = new Enfermedad("Cancer", new List<string> { "dolor", "pérdida de peso", "fatiga" });
            Enfermedad dengue = new Enfermedad("Dengue", new List<string> { "fiebre", "dolor de cabeza", "erupción" });
            Enfermedad sifilis = new Enfermedad("Sifilis", new List<string> { "úlcera", "erupción", "fiebre" });

            List<Enfermedad> enfermedades = new List<Enfermedad> { cancer, dengue, sifilis };

            List<string> sintomasIngresados = new List<string> { "fiebre", "erupción" };

            Diagnostico diagnostico = new Diagnostico(enfermedades);
            Enfermedad enfermedadDiagnostico = diagnostico.Diagnosticar(sintomasIngresados);

            if (enfermedadDiagnostico != null)
            {
                Console.WriteLine($"La enfermedad que coincide con los síntomas ingresados es: {enfermedadDiagnostico.Nombre}");
            }
            else
            {
                Console.WriteLine("No se encontró una enfermedad que coincida con los síntomas ingresados.");
            }
        }
    }

    class Enfermedad
    {
        public string Nombre { get; }
        public List<string> Sintomas { get; }

        public Enfermedad(string nombre, List<string> sintomas)
        {
            Nombre = nombre;
            Sintomas = sintomas;
        }
    }

    class Diagnostico
    {
        private List<Enfermedad> enfermedades;

        public Diagnostico(List<Enfermedad> enfermedades)
        {
            this.enfermedades = enfermedades;
        }

        public Enfermedad Diagnosticar(List<string> sintomasIngresados)
        {
            // Buscar la enfermedad que tiene todos los síntomas ingresados
            foreach (var enfermedad in enfermedades)
            {
                if (sintomasIngresados.All(s => enfermedad.Sintomas.Contains(s)))
                {
                    return enfermedad;
                }
            }

            return null;
        }
    }
}
