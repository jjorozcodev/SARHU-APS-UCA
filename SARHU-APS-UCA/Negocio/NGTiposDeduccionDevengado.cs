using Entidades;
using Datos;

using System;
using System.Collections.Generic;

namespace Negocio
{
    public class NGTiposDeduccionDevengado : INegocio<TipoDeduccionDevengado>
    {
        #region "Patrón Singleton"
        private static NGTiposDeduccionDevengado nTipoDeduccionDevengado = null;
        private NGTiposDeduccionDevengado()
        {

        }

        public static NGTiposDeduccionDevengado Instanciar()
        {
            if (nTipoDeduccionDevengado == null)
            {
                nTipoDeduccionDevengado = new NGTiposDeduccionDevengado();
            }
            return nTipoDeduccionDevengado;
        }
        #endregion

        public bool Crear(TipoDeduccionDevengado tipoDeduccionDevengado)
        {
            //Variable tipo booleano que informará si el método se ejecutó con éxito.
            bool creado = false;

            //Usando un TRY se hace el intento de ejecutar el método CREAR.
            try
            {
                //Se envía el objeto a la instancia de Datos correspondiente, solicitando verificar su creación.
                creado = DTTiposDeduccionDevengado.Instanciar().Crear(tipoDeduccionDevengado);
            }
            //En caso de error, se maneja con ayuda de CATCH.
            catch (Exception e)
            {
                throw e;
            }

            //La confirmación es recibida en una variable que posteriormente se devuelve.
            return creado;
        }
        public List<TipoDeduccionDevengado> Listar()
        {
            //Se declara una lista vacía
            List<TipoDeduccionDevengado> listaTiposDeduccionDevengado = null;

            //Usando un TRY se hace el intento de ejecutar el método LISTAR.
            try
            {
                //Se solicita la lista de objetos a la instancia de Datos correspondiente.
                listaTiposDeduccionDevengado = DTTiposDeduccionDevengado.Instanciar().Listar();
            }
            //En caso de error, se maneja con ayuda de CATCH.
            catch (Exception e)
            {
                throw e;
            }

            //Se reenvia la lista obtenida, si no pudo obtenerse, la lista irá vacía.
            return listaTiposDeduccionDevengado;
        }
        public bool Actualizar(TipoDeduccionDevengado tipoDeduccionDevengado)
        {
            //Variable tipo booleano que informará si el método se ejecutó con éxito.
            bool actualizado = false;

            //Usando un TRY se hace el intento de ejecutar el método ACTUALIZAR.
            try
            {
                //Se envía el objeto a la instancia de Datos correspondiente, solicitando verificar su actualización.
                actualizado = DTTiposDeduccionDevengado.Instanciar().Actualizar(tipoDeduccionDevengado);
            }
            //En caso de error, se maneja con ayuda de CATCH.
            catch (Exception e)
            {
                throw e;
            }

            //La confirmación es recibida en una variable que posteriormente se devuelve.
            return actualizado;
        }
        public bool Borrar(int idTipoDeduccionDevengado)
        {
            //Variable tipo booleano que informará si el método se ejecutó con éxito.
            bool borrado = false;

            //Usando un TRY se hace el intento de ejecutar el método BORRAR.
            try
            {
                //Se envía el objeto a la instancia de Datos correspondiente, solicitando verificar su borrado.
                borrado = DTTiposDeduccionDevengado.Instanciar().Borrar(idTipoDeduccionDevengado);
            }
            //En caso de error, se maneja con ayuda de CATCH.
            catch (Exception e)
            {
                throw e;
            }

            //La confirmación es recibida en una variable que posteriormente se devuelve.
            return borrado;
        }
        public List<TipoDeduccionDevengado> ListarTiposDevengado()
        {
            //Se declara una lista vacía
            List<TipoDeduccionDevengado> listaTiposDevengado = null;

            //Usando un TRY se hace el intento de ejecutar el método LISTAR.
            try
            {
                //Se solicita la lista de objetos a la instancia de Datos correspondiente.
                listaTiposDevengado = DTTiposDeduccionDevengado.Instanciar().ListarTiposDevengado();
            }
            //En caso de error, se maneja con ayuda de CATCH.
            catch (Exception e)
            {
                throw e;
            }

            //Se reenvia la lista obtenida, si no pudo obtenerse, la lista irá vacía.
            return listaTiposDevengado;
        }
    }
}
