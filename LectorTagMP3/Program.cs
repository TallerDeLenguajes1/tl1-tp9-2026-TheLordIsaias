using Tag;
using System.IO;
using System.Text;

string directorio = "C:/Taller de Lenguajes/TP9/tl1-tp9-2026-TheLordIsaias/LectorTagMP3/audio/cancion2.mp3";


FileInfo file = new FileInfo(directorio);

Console.WriteLine(file.Name);

bool existe = File.Exists(directorio);

byte[] buffer = new byte[128];
if (File.Exists(directorio))
{
    FileStream archivo = new FileStream(directorio, FileMode.Open);

    Encoding latin1 = Encoding.GetEncoding("latin1");

    archivo.Seek(-128, SeekOrigin.End);
    archivo.Read(buffer, 0 , 128);

    string identificador = latin1.GetString(buffer, 0, 3);

    if(identificador == "TAG")
    {
        string tagCompleto = latin1.GetString(buffer, 0, 128);

        string titulo = tagCompleto.Substring(3, 30);
        string artista = tagCompleto.Substring(33, 30);
        string album = tagCompleto.Substring(63, 30);
        string anio = tagCompleto.Substring(93, 4);
        Console.WriteLine($"Titulo: {titulo}. Artista: {artista}. Album: {album}. Año: {anio}");
    } else
    {
        Console.WriteLine($"No se ha encontrado un TAG de ID3v1 en el archivo leido en {directorio}");
    }  
} else
{
    Console.WriteLine("No existe una cancion en el directorio proporcionado");
}






