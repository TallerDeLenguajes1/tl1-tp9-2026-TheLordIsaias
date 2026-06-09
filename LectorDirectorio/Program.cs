using System.IO;
using System.Reflection.Metadata.Ecma335;
using Archivos;
using System.Collections.Generic;
using System.ComponentModel;


string directorio = "";
do
{
    if(directorio == "")
    {
       Console.WriteLine("Ingrese un directorio valido a explorar"); 
    } else
    {
        Console.WriteLine("Directorio INVALIDO o NO EXISTE.\nIngrese un directorio valido a explorar"); 
    }
    directorio = Console.ReadLine();
    if(directorio == null)
    {
        directorio = "";
    }
    int largo = directorio.Length;
    if (directorio[^1] != '/' || directorio[^1] != '\\')
    {
        directorio += '/';
    }
} while (!Directory.Exists(directorio));

mostrarSubDirectorios(directorio);
List<Archivo> listaArchivos = mostrarArchivos(directorio);
crearReporte(directorio, listaArchivos);

// Funciones
void mostrarSubDirectorios(string directorio)
{
    Console.WriteLine($"Todas las carpetas que se encuentran en {directorio}:");
    string[] subDirectorios = Directory.GetDirectories(directorio);
    foreach (var subDirectorio in subDirectorios)
    {
        Console.WriteLine($"- {subDirectorio}");
    }
}

List<Archivo> mostrarArchivos(string directorio)
{
    Console.WriteLine($"Todos los archivos que se encuentran {directorio}: ");
    string[] archivos = Directory.GetFiles(directorio);
    List<Archivo> listaArchivos = new List<Archivo>();
    foreach (var archivo in archivos)
    {
        FileInfo file = new FileInfo(archivo);
        listaArchivos.Add(new Archivo(file.Name, (file.Length / 1024.0), file.LastWriteTime));
        Console.WriteLine($"- {archivo} ({(file.Length / 1024.0):F2}KB)");
        
    }
    return listaArchivos;
}

void crearReporte(string directorio, List<Archivo> listaArchivos)
{
    string directorioArchivo = $"{directorio}/reporte_archivos.csv";
    List<string> csv = new List<string>();
    foreach (var archivo in listaArchivos)
    {
        csv.Add(archivo.CamposACSV());
    }
    File.WriteAllLines(directorioArchivo, csv);
}


