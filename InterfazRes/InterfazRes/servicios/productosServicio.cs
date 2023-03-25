using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using InterfazRes.models;
using Realms;

namespace InterfazRes.servicios
{
    public class productosServicio
    {
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

            var listProductos = realm.All<productosModel>().ToList();

            return (listProductos.Count + 1);
        }

        public bool guardarProducto(string strNombre, string strDescripcion, int intCondicion, float fltPrecio, bool bitReportado, int intIdUsuario)
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
                realm.Add(new productosModel
                {
                    intIdProducto = obtenerNuevoID(),
                    strNombre = strNombre,
                    strDescripcion = strDescripcion,
                    intCondicion = intCondicion, //1.Nuevo 2.Usado 3.Robado
                    fltPrecio = fltPrecio,
                    bitEstado = true,
                    bitReportado = bitReportado,
                    intIdUsuario = intIdUsuario
                });
            });

            return true;
        }

        public List<productosModel> obtenerProductosActivos(int intCondicion)
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

            var rsProductos = realm.All<productosModel>().Where(d => d.bitEstado == true && d.intCondicion == intCondicion);

            if (rsProductos.Count() == 0)
            {
                return null;
            }
            else
            {
                return rsProductos.ToList();
            }
        }

        public productosModel obtenerProductoPorId(int idProducto)
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

            var rsProductos = realm.All<productosModel>().Where(d => d.intIdProducto == idProducto);

            if (rsProductos.Count() == 0)
            {
                return null;
            }
            else
            {
                return rsProductos.ToList()[0];
            }
        }

        public bool actualizarEstadoCompra(int idProducto)
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

            var producto = realm.All<productosModel>().Where(d => d.intIdProducto == idProducto).First();
            realm.Write(() => producto.bitEstado = false);

            return true;
        }

        public bool consultarRangoBrayan(int idUsuario)
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

            var rsProductos = realm.All<productosModel>().Where(d => d.intIdUsuario == idUsuario || d.intCondicion == 3);

            return (rsProductos.Count() >= 2 ? true : false);
        }
    }
}
