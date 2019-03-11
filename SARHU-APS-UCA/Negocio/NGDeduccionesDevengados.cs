using Entidades;
using Datos;

using System;
using System.Collections.Generic;
using System.Data;

namespace Negocio
{
    public class NGDeduccionesDevengados : INegocio<DeduccionDevengado>
    {
        #region "Patrón Singleton"
        private static NGDeduccionesDevengados nDeduccionesDevengados = null;
        private NGDeduccionesDevengados()
        {

        }

        public static NGDeduccionesDevengados Instanciar()
        {
            if (nDeduccionesDevengados == null)
            {
                nDeduccionesDevengados = new NGDeduccionesDevengados();
            }
            return nDeduccionesDevengados;
        }
        #endregion

        public bool Crear(DeduccionDevengado deduccionDevengado)
        {
            //Variable tipo booleano que informará si el método se ejecutó con éxito.
            bool creado = false;

            //Usando un TRY se hace el intento de ejecutar el método CREAR.
            try
            {
                //Se envía el objeto a la instancia de Datos correspondiente, solicitando verificar su creación.
                creado = DTDeduccionesDevengados.Instanciar().Crear(deduccionDevengado);
            }
            //En caso de error, se maneja con ayuda de CATCH.
            catch (Exception e)
            {
                throw e;
            }

            //La confirmación es recibida en una variable que posteriormente se devuelve.
            return creado;
        }
        public List<DeduccionDevengado> Listar()
        {
            //Se declara una lista vacía
            List<DeduccionDevengado> listaDeduccionDevengado = null;

            //Usando un TRY se hace el intento de ejecutar el método LISTAR.
            try
            {
                //Se solicita la lista de objetos a la instancia de Datos correspondiente.
                listaDeduccionDevengado = DTDeduccionesDevengados.Instanciar().Listar();
            }
            //En caso de error, se maneja con ayuda de CATCH.
            catch (Exception e)
            {
                throw e;
            }

            //Se reenvia la lista obtenida, si no pudo obtenerse, la lista irá vacía.
            return listaDeduccionDevengado;
        }
        public bool Actualizar(DeduccionDevengado deduccionDevengado)
        {
            //Variable tipo booleano que informará si el método se ejecutó con éxito.
            bool actualizado = false;

            //Usando un TRY se hace el intento de ejecutar el método ACTUALIZAR.
            try
            {
                //Se envía el objeto a la instancia de Datos correspondiente, solicitando verificar su actualización.
                actualizado = DTDeduccionesDevengados.Instanciar().Actualizar(deduccionDevengado);
            }
            //En caso de error, se maneja con ayuda de CATCH.
            catch (Exception e)
            {
                throw e;
            }

            //La confirmación es recibida en una variable que posteriormente se devuelve.
            return actualizado;
        }
        public bool Borrar(int idDeduccionDevengado)
        {
            //Variable tipo booleano que informará si el método se ejecutó con éxito.
            bool borrado = false;

            //Usando un TRY se hace el intento de ejecutar el método BORRAR.
            try
            {
                //Se envía el objeto a la instancia de Datos correspondiente, solicitando verificar su borrado.
                borrado = DTDeduccionesDevengados.Instanciar().Borrar(idDeduccionDevengado);
            }
            //En caso de error, se maneja con ayuda de CATCH.
            catch (Exception e)
            {
                throw e;
            }

            //La confirmación es recibida en una variable que posteriormente se devuelve.
            return borrado;
        }

        //Método personalizado: Muestra los devengados por empleados
        public DataTable MostrarDevengados()
        {
            //Se declara una lista vacía
            DataTable tablaDatos = null;

            //Usando un TRY se hace el intento de ejecutar el método LISTAR.
            try
            {
                //Se solicita la lista de objetos a la instancia de Datos correspondiente.
                tablaDatos = DTDeduccionesDevengados.Instanciar().MostrarDevengados();
            }
            //En caso de error, se maneja con ayuda de CATCH.
            catch (Exception e)
            {
                throw e;
            }

            //Se reenvia la lista obtenida, si no pudo obtenerse, la lista irá vacía.
            return tablaDatos;
        }

        //Método personalizado: Muestra los deducciones por empleados
        public DataTable MostrarDeducciones()
        {
            //Se declara una lista vacía
            DataTable tablaDatos = null;

            //Usando un TRY se hace el intento de ejecutar el método LISTAR.
            try
            {
                //Se solicita la lista de objetos a la instancia de Datos correspondiente.
                tablaDatos = DTDeduccionesDevengados.Instanciar().MostrarDeducciones();
            }
            //En caso de error, se maneja con ayuda de CATCH.
            catch (Exception e)
            {
                throw e;
            }

            //Se reenvia la lista obtenida, si no pudo obtenerse, la lista irá vacía.
            return tablaDatos;
        }

    }
}
