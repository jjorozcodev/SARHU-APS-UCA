using System.Data;
using System.Data.SqlClient;
using Entidades;
using System.Collections.Generic;

namespace Datos
{
    public class DT_Usuarios : I_CRUD<Usuario>
    {
        //GLOBALES

        private SqlConnection conexionSql = Conexion.Instanciar().ConexionBD();
        private SqlCommand comandoSql = new SqlCommand();
        private List<Usuario> usuarios = new List<Usuario>();

        private static DT_Usuarios dtUsuarios = null;

        private DT_Usuarios()
        {
            //Singleton
        }

        public static DT_Usuarios Instanciar()
        {
            if(dtUsuarios == null)
            {
                dtUsuarios = new DT_Usuarios();
            }
            return dtUsuarios;
        }

        // METODOS
        /// <summary>
        /// El método permite agregar un registro de la entidad [Usuario].
        /// Recibe como parámetro un objeto [Usuario] con la información a agregar a la base de datos (Id de empleado, Id del Rol, Nombre de Usuario, Correo y Clave).
        /// Devuelve un valor entero con el id generado.
        /// </summary>
        public int Agregar(Usuario obj)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.UsuariosAgregar;
            
            comandoSql.Parameters.Clear();
            comandoSql.Parameters.Add("@rol_id", SqlDbType.Int).Value = obj.RolId;
            comandoSql.Parameters.Add("@empleado_id", SqlDbType.Int).Value = obj.EmpleadoId;
            comandoSql.Parameters.Add("@usuario_nombre", SqlDbType.VarChar).Value = obj.Nombre;
            comandoSql.Parameters.Add("@usuario_clave", SqlDbType.VarChar).Value = obj.Clave;
            comandoSql.Parameters.Add("@usuario_correo", SqlDbType.VarChar).Value = obj.Correo;

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            int idGenerado = int.Parse(comandoSql.ExecuteScalar().ToString());

            conexionSql.Close();

            return idGenerado;
        }

        /// <summary>
        /// El método permite borrar un registro de la entidad [Usuario].
        /// Recibe como parámetro el id [int] del registro a borrar en la base de datos.
        /// Devuelve un valor booleano para notificar si el registro fue borrado o no.
        /// </summary>
        public bool Borrar(int id)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.UsuariosBorrar;

            comandoSql.Parameters.Clear();

            comandoSql.Parameters.Add("@usuario_id", SqlDbType.Int).Value = id;

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            int borrado = comandoSql.ExecuteNonQuery();

            conexionSql.Close();

            return (borrado > 0);
        }

        /// <summary>
        /// El método permite consultar/buscar un registro de la entidad [Usuario].
        /// Recibe como parámetro el id [int] del registro a consultar/buscar en la base de datos.
        /// Devuelve un objeto [Usuario] nulo en caso de no encontrarse, o con la información del registro en caso que exista.
        /// </summary>
        public Usuario Consultar(int id)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.UsuariosConsultar;

            comandoSql.Parameters.Clear();

            comandoSql.Parameters.Add("@usuario_id", SqlDbType.Int).Value = id;

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            SqlDataReader reader = comandoSql.ExecuteReader();

            Usuario usuario = new Usuario();

            while (reader.Read())
            {
                usuario.Id = id;
                usuario.RolId = int.Parse(reader["rol_id"].ToString());
                usuario.EmpleadoId = int.Parse(reader["empleado_id"].ToString());
                usuario.Nombre = reader["usuario_nombre"].ToString();
                usuario.Clave = reader["usuario_clave"].ToString();
                usuario.Correo = reader["usuario_correo"].ToString();
                usuario.Estado = bool.Parse(reader["usuario_estado"].ToString());
            }

            reader.Close();

            conexionSql.Close();

            return usuario;
        }

        /// <summary>
        /// El método permite editar un registro de la entidad [Usuario].
        /// Recibe como parámetro un objeto [Usuario] con la información editada para actualizarse en la base de datos (Id de empleado, Id del Rol, Nombre de Usuario, Correo y Clave).
        /// Devuelve un valor booleano para notificar si el registro fue editado o no.
        /// </summary>
        public bool Editar(Usuario obj)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.UsuariosEditar;
            
            comandoSql.Parameters.Clear();

            comandoSql.Parameters.Add("@usuario_id", SqlDbType.Int).Value = obj.Id;
            comandoSql.Parameters.Add("@rol_id", SqlDbType.Int).Value = obj.RolId;
            comandoSql.Parameters.Add("@empleado_id", SqlDbType.Int).Value = obj.EmpleadoId;
            comandoSql.Parameters.Add("@usuario_nombre", SqlDbType.VarChar).Value = obj.Nombre;
            comandoSql.Parameters.Add("@usuario_clave", SqlDbType.VarChar).Value = obj.Clave;
            comandoSql.Parameters.Add("@usuario_correo", SqlDbType.VarChar).Value = obj.Correo;

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            int editado = comandoSql.ExecuteNonQuery();

            conexionSql.Close();

            return (editado > 0);
        }

        /// <summary>
        /// El método permite obtener la lista de registros de la entidad [Usuario] desde la base de datos.
        /// Los campos que se devuelven son: Id de Usuario, Id de empleado, Id del Rol, Nombre de Usuario y Correo.
        /// En caso de no existir ningún registro se devuelve una lista nula o vacía.
        /// </summary>
        public List<Usuario> Listar()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();

            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.UsuariosListar;

            comandoSql.Parameters.Clear();

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            SqlDataReader reader = comandoSql.ExecuteReader();

            while (reader.Read())
            {
                Usuario u = new Usuario();
                
                u.Id = int.Parse(reader["usuario_id"].ToString());
                u.RolId = int.Parse(reader["rol_id"].ToString());
                u.EmpleadoId = int.Parse(reader["empleado_id"].ToString());
                u.Nombre = reader["usuario_nombre"].ToString();
                u.Clave = reader["usuario_clave"].ToString();
                u.Correo = reader["usuario_correo"].ToString();
                u.Estado = bool.Parse(reader["usuario_estado"].ToString());

                listaUsuarios.Add(u);
            }

            reader.Close();

            conexionSql.Close();

            this.usuarios.Clear();
            this.usuarios = listaUsuarios;

            return listaUsuarios;
        }

        public List<Usuario> ListarPorEstado(bool Estado)
        {
            // Actualizar
            Listar();

            List<Usuario> listUsuarios = new List<Usuario>();

            foreach (Usuario u in usuarios)
            {
                if (u.Estado == Estado)
                {
                    listUsuarios.Add(u);
                }
            }

            return listUsuarios;
        }
    }
}
