using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Realms;

namespace InterfazRes.models
{
    public class usuariosModel : RealmObject
    {
        public int intIdUsuario { get; set; }
        public string strNombres { get; set; }
        public string strApellidos { get; set; }
        public string strIdentificacion { get; set; }
        public string strNombreUsuario { get; set; }
        public string strContrasena { get; set; }
        public bool bitEstado { get; set; }
    }
}