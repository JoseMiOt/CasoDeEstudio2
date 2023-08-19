using CasoEstudio2.Entities;

namespace CasoEstudio2.Interfaces
{
    public interface ICasasModel
    {
        public CasasEntRespuesta? ConsultarCasas();
        public CasasEntRespuesta? AlquilarCasa(CasasEntRespuesta entidad);
        public CasasEntRespuesta? ConsultarCasasDisponibles();
    }
}
