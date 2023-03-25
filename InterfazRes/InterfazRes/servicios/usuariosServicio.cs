using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using InterfazRes.models;
using Realms;

namespace InterfazRes.servicios
{
    public class usuariosServicio
    {
        public bool validarUsuarioIdentificacion(string identificacion, string nombreUsuario)
        {
            const ulong currentSchemaVersion = 1;
            var config = new RealmConfiguration()
            {
                SchemaVersion = currentSchemaVersion,
                MigrationCallback = (Migration migration, ulong oldSchemaVersion) =>
                {
                    
                }
            };

            var realm = Realm.GetInstance(config);

            var rsUsuarios = realm.All<usuariosModel>().Where(d => d.strNombreUsuario == nombreUsuario || d.strIdentificacion == identificacion);

            return (rsUsuarios.Count() == 0 ? false : true);
        }

        public int obtenerNuevoID()
        {
            const ulong currentSchemaVersion = 1;
            var config = new RealmConfiguration()
            {
                SchemaVersion = currentSchemaVersion,
                MigrationCallback = (Migration migration, ulong oldSchemaVersion) =>
                {
                   
                }
            };

            var realm = Realm.GetInstance(config);

            var listUsuarios = realm.All<usuariosModel>().ToList();

            return (listUsuarios.Count + 1);
        }

        public bool guardarUsuario(string strNombre, string strApellidos, string strIdentificacion, string strUsuario, string strContrasena)
        {
            const ulong currentSchemaVersion = 1;
            var config = new RealmConfiguration()
            {
                SchemaVersion = currentSchemaVersion,
                MigrationCallback = (Migration migration, ulong oldSchemaVersion) =>
                {
                    
                }
            };

            var realm = Realm.GetInstance(config);

            realm.Write(() =>
            {
                realm.Add(new usuariosModel
                {
                    intIdUsuario = obtenerNuevoID(),
                    strNombres = strNombre,
                    strApellidos = strApellidos,
                    strIdentificacion = strIdentificacion,
                    strNombreUsuario = strUsuario,
                    strContrasena = strContrasena,
                    bitEstado = true
                });
            });

            return true;
        }

        public usuariosModel validarUsuarioContrasena(string nombreUsuario, string contrasena)
        {
            const ulong currentSchemaVersion = 1;
            var config = new RealmConfiguration()
            {
                SchemaVersion = currentSchemaVersion,
                MigrationCallback = (Migration migration, ulong oldSchemaVersion) =>
                {
                    
                }
            };

            var realm = Realm.GetInstance(config);

            var rsUsuarios = realm.All<usuariosModel>().Where(d => d.strNombreUsuario == nombreUsuario && d.strContrasena == contrasena && d.bitEstado == true);

            if (rsUsuarios.Count() == 0)
            {
                return null;
            }
            else
            {
                return rsUsuarios.ToList()[0];
            }
        }

       
    }
}
