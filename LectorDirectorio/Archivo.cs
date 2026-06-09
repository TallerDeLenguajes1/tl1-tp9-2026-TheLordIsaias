namespace Archivos
{
    public class Archivo
    {
        public string NombreArchivo{get; set;}
        public double TamanioEnKilobytes{get; set;}
        public DateTime UltimaModificacion{get; set;}

        public Archivo(string NombreArchivo, double TamanioEnKilobytes, DateTime UltimaModificacion)
        {
            this.NombreArchivo = NombreArchivo;
            this.TamanioEnKilobytes = TamanioEnKilobytes;
            this.UltimaModificacion = UltimaModificacion;
        }

        public string CamposACSV()
        {
            return ($"{NombreArchivo}; {TamanioEnKilobytes}; {UltimaModificacion}");
        }
    }
}