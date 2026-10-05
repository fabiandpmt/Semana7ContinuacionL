using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace semana_7
{
    internal class Program
    {
        static int max = 100;
        static string[] nombres = new string[max];
        static double[] notas = new double[max];
        static int contador = 0;
        static public void Titulo()
        {
            Console.WriteLine("**********************");
            Console.WriteLine("Sistema de Gestión de notas");
            Console.WriteLine("**********************");
        }
        static public void Registrar_estudiante()
        {
            Console.WriteLine("Registro de Estudiante Nuevo:");
            if (contador >= 100)
            {
                Console.WriteLine("Alcanzo la Capacidad Máxima:");
                return;
            }
            Console.Write("Ingresar nombre del Estudiante:");
            string nombre = Console.ReadLine();
            double nota;
            while (true)
            {
                Console.Write("Ingresar Nota[0-20]:");
                nota = double.Parse(Console.ReadLine());
                if (nota >= 0 && nota <= 20)
                {
                    break;
                }
                Console.WriteLine("Error, Volver a ingresar la nota [0-20]");
            }
            nombres[contador] = nombre;
            notas[contador] = nota;
            contador++;
            Console.WriteLine("Registro con Exitoso..!!");
        }
        static public void Buscar_estudiante()
        {
            Console.WriteLine("Busqueda de Estudiante: ");
            Console.Write("Ingresar nombre del Estudiante: ");
            if (contador == 0)
            {
                Console.WriteLine("Estudiante no encontrado");
                return;
            }
            Console.Write("ingresar nombre del Estudiante: ");
            string nom_buscar = Console.ReadLine().ToLower();
            bool encontrado = false;
            for (int i = 0; i < contador; i++)
            {
                if (nombres[i].ToLower() == nom_buscar)
                {
                    Console.WriteLine("Estudiante encontrado: ");
                    Console.WriteLine("Nombre: " + nombres[i]);
                    Console.WriteLine("Nota: " + notas[i]);
                    encontrado = true;
                    break;
                }
            }
            if (!encontrado)
            {
                Console.WriteLine("Estudiante no encontrado");
            }
        }
        static public void Modificar_nota()
        {
            Console.WriteLine("Modificar Nota de Estudiante: ");
            if (contador == 0)
            {
                Console.WriteLine("No hay estudiantes registrados");
                return;
            }
            Console.Write("Ingresar nombre del Estudiante: ");
            string nom_buscar = Console.ReadLine().ToLower();
            for (int i = 0; i < contador; i++)
            {
                if (nombres[i].ToLower() == nom_buscar)
                {
                    Console.WriteLine(nombres[i] + " tiene " + notas[i]);
                    double nueva_nota;
                    while (true)
                    {
                        Console.Write("Ingresar nueva nota [0-20]: ");
                        nueva_nota = double.Parse(Console.ReadLine());
                        if (nueva_nota >= 0 && nueva_nota <= 20)
                        {
                            notas[i] = nueva_nota;
                            Console.WriteLine("Nota modificada con éxito");
                            break;
                        }
                        Console.WriteLine("Error, Volver a ingresar la nota [0-20]");
                    }
                }
            }
            Console.WriteLine("Estudiante no encontrado");
        }
        static public void Mostrar()
        {
            Console.WriteLine("Lista de Estudiantes: ");
            if (contador == 0)
            {
                Console.WriteLine("No hay estudiantes registrados");
                return;
            }
            Console.WriteLine("\tNombre \t\tNOTAS");
            for (int i = 0; i < contador; i++)
            {
                Console.WriteLine("\t" + nombres[i] + "\t\t" + notas[i]);
            }
        }
        static public void Burbuja()
        {
            Console.WriteLine("Ordenamiento de Estudiantes por Nota (Burbuja): ");
            double temp_nota;
            string temp_nombre;
            for (int i = 0; i < contador - 1; i++)
            {
                for (int j = 0; j < contador - i - 1; j++)
                {
                    if (notas[j] > notas[j + 1])
                    {
                        temp_nota = notas[j];
                        notas[j] = notas[j + 1];
                        notas[j + 1] = temp_nota;
                        temp_nombre = nombres[j];
                        nombres[j] = nombres[j + 1];
                        nombres[j + 1] = temp_nombre;
                    }
                }
            }
            Mostrar();
        }
        static public void Seleccion()
        {
            Console.WriteLine("Ordenamiento de Estudiantes por Nota (Seleccion): ");
            double temp_nota;
            string temp_nombre;
            for (int i = 0; i < contador - 1; i++)
            {
                int posicion_minima = i;
                for (int j = i + 1; j < contador; j++)
                {
                    if (notas[j] > notas[posicion_minima])
                    {
                        posicion_minima = j;
                    }
                }
                temp_nota = notas[i];
                notas[i] = notas[posicion_minima];
                notas[posicion_minima] = temp_nota;
                temp_nombre = nombres[i];
                nombres[i] = nombres[posicion_minima];
                nombres[posicion_minima] = temp_nombre;
            }
            Mostrar();
        }
        static public void nota_max_prom()
        {
            if (contador == 0)
            {
                Console.WriteLine("No hay estudiante registrados");
                return;
            }
            double max = notas[0];
            double min = notas[0];
            double suma = 0;
            for (int i = 0; i < contador; i++)
            {
                if (notas[i] > max)
                    max = notas[i];
                if (notas[i] < min)
                    min = notas[i];
                suma += notas[i];
            }
            double promedio = suma / contador;
            Console.WriteLine("Nota maxima: " + max);
            Console.WriteLine("Nota minima: " + min);
            Console.WriteLine("Promedio: " + promedio);
        }
        static void Main(string[] args)
        {
            Titulo();
            int opc = 0;
            while (opc != 8)
            {
                Console.WriteLine("**************************");
                Console.WriteLine("MENU PRINCIPAL");
                Console.WriteLine("**************************");
                Console.WriteLine("[1]Registrar estudiante"); //
                Console.WriteLine("[2]Buscar estudiante"); //
                Console.WriteLine("[3]Modificar la nota"); //
                Console.WriteLine("[4]Mostrar lista sin ordenar");//
                Console.WriteLine("[5]Ordenar con burbuja");//
                Console.WriteLine("[6]Ordenar con seleccion descendente");//
                Console.WriteLine("[7]nota maxima promedio");
                Console.WriteLine("[8]Salir");
                Console.Write("Ingresar la opcion: ");
                opc = int.Parse(Console.ReadLine());
                switch (opc)
                {
                    case 1:
                        Registrar_estudiante();
                        break;
                    case 2:
                        Buscar_estudiante();
                        break;
                    case 3:
                        Modificar_nota();
                        break;
                    case 4:
                        Mostrar();
                        break;
                    case 5:
                        Burbuja();
                        break;
                    case 6:
                        Seleccion();
                        break;
                    case 7:
                        nota_max_prom();
                        break;
                    case 8:
                        Console.WriteLine("Gracias por usar el sistema");
                        break;
                    default:
                        Console.WriteLine("Opcion incorrecta");
                        break;
                }
            }
        }
    }
}
