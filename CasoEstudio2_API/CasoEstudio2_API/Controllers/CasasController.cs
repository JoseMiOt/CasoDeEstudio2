using CasoEstudio2_API.Entities;
using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace CasoEstudio2_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CasasController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public CasasController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("ConsultarCasas")]
        public IActionResult ConsultarCasas()
        {
            var resultado = new List<CasasEnt>();
            var respuesta = new CasasEntRespuesta();
            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    resultado = connection.Query<CasasEnt>("ConsultaCasas",
                        new { },
                        commandType: System.Data.CommandType.StoredProcedure).ToList();

                    if (resultado.Count == 0)
                    {
                        respuesta.Codigo = 2;
                        respuesta.Mensaje = "No se encontraron datos sobre las casas";
                        return Ok(respuesta);
                    }
                    respuesta.Codigo = 1;
                    respuesta.Mensaje = "Información consultada correctamente";
                    
                    respuesta.Objetos = resultado;
                    respuesta.ResultadoTransaccion = true;
                    return Ok(respuesta);
                }
            }
            catch (Exception)
            {
                respuesta.Codigo = 3;
                respuesta.Mensaje = "Se presentó un inconveniente";
                return Ok(respuesta);
            }
        }

        [HttpPost]
        [Route("AlquilarCasa")]
        public IActionResult AlquilarCasa(CasasEnt entidad)
        {
            var respuesta = new CasasEntRespuesta();

            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    int confirmacion = connection.Execute("AlquilaCasas",
                        new { entidad.IdCasa, entidad.Usuario },
                        commandType: System.Data.CommandType.StoredProcedure);

                    if (confirmacion <= 0)
                    {
                        respuesta.Codigo = 2;
                        respuesta.Mensaje = "No se registró el alquiler";
                        return Ok(respuesta);
                    }

                    respuesta.Codigo = 1;
                    respuesta.Mensaje = "Su alquiler fue registrado correctamente";
                    respuesta.ResultadoTransaccion = true;
                    return Ok(respuesta);
                }
            }
            catch (Exception)
            {
                respuesta.Codigo = 3;
                respuesta.Mensaje = "Se presentó un inconveniente.";
                return Ok(respuesta);
            }
        }
    }
}
