public class Incidencia
{
    public int Id { get; set; }  // Clave primaria
    public string Pasaporte { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string WhatsApp { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public double Latitud { get; set; }
    public double Longitud { get; set; }
    public int CodigoAgente { get; set; }  // Relación con el agente
}
