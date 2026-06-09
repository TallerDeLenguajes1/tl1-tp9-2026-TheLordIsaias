using Tag;
using System.IO;
using System.Text;

string directorio = "C:/Taller/tl1-tp9-2026-TheLordIsaias/LectorTagMP3/audio/fran-ruiz-pulse-333112.mp3";

FileInfo file = new FileInfo(directorio);

Console.WriteLine(file.Name);

bool existe = File.Exists(directorio);

byte[] buffer = new byte[128];

FileStream archivo = new FileStream(directorio, FileMode.Open);

Encoding latin1 = Encoding.GetEncoding("latin1");



archivo.Seek(-128, SeekOrigin.End);
archivo.Read(buffer, 0 , 128);

Console.WriteLine(latin1.GetString(buffer, 0, 128));