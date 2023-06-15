using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesVentas.Usuario
{
    public class DT_Usuario
    {
        public int idUsuario        { get; set; }
        public int idRol            { get; set; }
        public string cNombre       { get; set; }
        public string cApePaterno   { get; set; }
        public string cApeMaterno   { get; set; }
        public int idTipoDocumento  { get; set; }
        public string cDireccion    { get; set; }
        public string cDocumento    { get; set; }
        public string cTelefono     { get; set; }
        public string cEmail        { get; set; }
        public string cWinUser      { get; set; }
        public string cPassword     { get; set; }
        public int? idUsuReg        { get; set; }
        public DateTime? dFechaReg  { get; set; }
        public int? idUsuMod        { get; set; }
        public DateTime? dFechaMod  { get; set; }
        public bool? lVigente       { get; set; }
    }
}
