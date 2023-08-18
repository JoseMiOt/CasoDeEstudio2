namespace CasoEstudio2_API.Entities
{
    public class CasasEnt
    {
        public long IdCasa { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public string Usuario { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }
    }

    public class CasasEntRespuesta
    {
        public int Codigo { get; set; }
        public string Mensaje { get; set; } = string.Empty;
        public CasasEnt Objeto { get; set; } = null;
        public List<CasasEnt> Objetos { get; set; } = new List<CasasEnt>();
        public bool ResultadoTransaccion { get; set; }

    }
}
