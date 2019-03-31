using System.Data;
using System.Data.SqlClient;
using Entidades;
using System.Collections.Generic;

namespace Datos
{
    public class DT_Areas : I_CRUD<Area>
    {
        //GLOBALES

        private SqlConnection conexionSql = Conexion.Instanciar().ConexionBD();
        private SqlCommand comandoSql = new SqlCommand();
        private List<Area> areas = new List<Area>();

        private static DT_Areas dtAreas = null;

        private DT_Areas()
        {
            //Singleton
        }

        public static DT_Areas Instanciar()
        {
            if(dtAreas == null)
            {
                dtAreas = new DT_Areas();
            }
            return dtAreas;
        }

        // METODOS

        /// <summary>
        /// El método permite agregar un registro de la entidad [Area].
        /// Recibe como parámetro un objeto [Area] con la información a agregar a la base de datos (Nombre y Descripción).
        /// Devuelve un valor entero con el id generado.
        /// </summary>
        public int Agregar(Area obj)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.AreasAgregar;
            
            comandoSql.Parameters.Clear();
            comandoSql.Parameters.Add("@area_nombre", SqlDbType.VarChar).Value = obj.Nombre;
            comandoSql.Parameters.Add("@area_descripcion", SqlDbType.VarChar).Value = obj.Descripcion;

            if(conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            int idGenerado = int.Parse(comandoSql.ExecuteScalar().ToString());

            conexionSql.Close();

            return idGenerado;
        }

        /// <summary>
        /// El método permite borrar un registro de la entidad [Area].
        /// Recibe como parámetro el id [int] del registro a borrar en la base de datos.
        /// Devuelve un valor booleano para notificar si el registro fue borrado o no.
        /// </summary>
        public bool Borrar(int id)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.AreasBorrar;

            comandoSql.Parameters.Clear();
            comandoSql.Parameters.Add("@area_id", SqlDbType.Int).Value = id;

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            int borrado = comandoSql.ExecuteNonQuery();

            conexionSql.Close();

            return (borrado > 0);
        }

        /// <summary>
        /// El método permite consultar/buscar un registro de la entidad [Area].
        /// Recibe como parámetro el id [int] del registro a consultar/buscar en la base de datos.
        /// Devuelve un objeto [Area] nulo en caso de no encontrarse, o con la información del registro en caso que exista.
        /// </summary>
        public Area Consultar(int id)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.AreasConsultar;

            comandoSql.Parameters.Clear();
            comandoSql.Parameters.Add("@area_id", SqlDbType.Int).Value = id;

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            SqlDataReader reader = comandoSql.ExecuteReader();

            Area area = new Area();

            while (reader.Read())
            {
                area.Id = id;
                area.Nombre = reader["area_nombre"].ToString();
                area.Descripcion = reader["area_descripcion"].ToString();
                area.Estado = bool.Parse(reader["area_estado"].ToString());
            }

            reader.Close();
            
            conexionSql.Close();

            return area;
        }

        /// <summary>
        /// El método permite editar un registro de la entidad [Area].
        /// Recibe como parámetro un objeto [Area] con la información editada para actualizarse en la base de datos (Nombre y Descripción).
        /// Devuelve un valor booleano para notificar si el registro fue editado o no.
        /// </summary>
        public bool Editar(Area obj)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.AreasEditar;

            comandoSql.Parameters.Clear();

            comandoSql.Parameters.Add("@area_id", SqlDbType.Int).Value = obj.Id;
            comandoSql.Parameters.Add("@area_nombre", SqlDbType.VarChar).Value = obj.Nombre;
            comandoSql.Parameters.Add("@area_descripcion", SqlDbType.VarChar).Value = obj.Descripcion;

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            int editado = comandoSql.ExecuteNonQuery();

            conexionSql.Close();

            return (editado > 0);
        }

        /// <summary>
        /// El método permite obtener la lista de registros de la entidad [Area] desde la base de datos.
        /// Los campos que se devuelven son: Id, Nombre, Descripción y Estado.
        /// En caso de no existir ningún registro se devuelve una lista nula o vacía.
        /// </summary>
        public List<Area> Listar()
        {
            List<Area> listaAreas = new List<Area>();

            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.AreasListar;

            comandoSql.Parameters.Clear();

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            SqlDataReader reader = comandoSql.ExecuteReader();
         
            while (reader.Read())
            {
                Area a = new Area();

                a.Id = int.Parse(reader["area_id"].ToString());
                a.Nombre = reader["area_nombre"].ToString();
                a.Descripcion = reader["area_descripcion"].ToString();
                a.Estado = bool.Parse(reader["area_estado"].ToString());

                listaAreas.Add(a);
            }

            reader.Close();

            conexionSql.Close();

            this.areas.Clear();
            this.areas = listaAreas;

            return listaAreas;
        }

        public List<Area> ListarPorEstado(bool Estado)
        {
            // Actualizar
            Listar();

            List<Area> listAreas = new List<Area>();

            foreach (Area a in areas)
            {
                if (a.Estado == Estado)
                {
                    listAreas.Add(a);
                }
            }

            return listAreas;
        }
    }
}
