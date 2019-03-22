﻿using System.Data;
using System.Data.SqlClient;
using Entidades;
using System.Collections.Generic;

namespace Datos
{
    public class DT_Roles : I_CRUD<Rol>
    {
        //GLOBALES

        private SqlConnection conexionSql = Conexion.Instanciar().ConexionBD();
        private SqlCommand comandoSql = new SqlCommand();
        private SqlDataAdapter adaptadorSql = null;

        private List<Rol> rol = new List<Rol>();

        private static DT_Roles dtRoles = null;

        private DT_Roles()
        {
            //Singleton
        }

        public static DT_Roles Instanciar()
        {
            if (dtRoles == null)
            {
                dtRoles = new DT_Roles();
            }
            return dtRoles;
        }

        // METODOS

        /// <summary>
        /// El método permite agregar un registro de la entidad [Rol].
        /// Recibe como parámetro un objeto [Rol] con la información a agregar a la base de datos (Nombre y Descripción).
        /// Devuelve un valor booleano para notificar si el registro fue agregado o no.
        /// </summary>
        public bool Agregar(Rol obj)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.RolesAgregar;

            comandoSql.Parameters.Add("@rol_nombre", SqlDbType.VarChar).Value = obj.Nombre;
            comandoSql.Parameters.Add("@rol_descripcion", SqlDbType.VarChar).Value = obj.Descripcion;

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            int agregado = comandoSql.ExecuteNonQuery();

            conexionSql.Close();

            return (agregado > 0);
        }

        /// <summary>
        /// El método permite borrar un registro de la entidad [Rol].
        /// Recibe como parámetro el id [int] del registro a borrar en la base de datos.
        /// Devuelve un valor booleano para notificar si el registro fue borrado o no.
        /// </summary>
        public bool Borrar(int id)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.RolesBorrar;

            comandoSql.Parameters.Clear();
            comandoSql.Parameters.Add("@rol_id", SqlDbType.Int).Value = id;

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            int borrado = comandoSql.ExecuteNonQuery();

            conexionSql.Close();

            return (borrado > 0);
        }

        /// <summary>
        /// El método permite consultar/buscar un registro de la entidad [Rol].
        /// Recibe como parámetro el id [int] del registro a consultar/buscar en la base de datos.
        /// Devuelve un objeto [Rol] nulo en caso de no encontrarse, o con la información del registro en caso que exista.
        /// </summary>
        public Rol Consultar(int id)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.RolesConsultar;

            comandoSql.Parameters.Clear();
            comandoSql.Parameters.Add("@rol_id", SqlDbType.Int).Value = id;

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            SqlDataReader reader = comandoSql.ExecuteReader();
            Rol rol = new Rol();

            while (reader.Read())
            {

                rol.Id = id;
                rol.Nombre = reader.GetString(0);
                rol.Descripcion = reader.GetString(1);
                rol.Estado = reader.GetBoolean(2);
            }
            reader.Close();

            conexionSql.Close();

            return rol;
        }

        /// <summary>
        /// El método permite editar un registro de la entidad [Rol].
        /// Recibe como parámetro un objeto [Rol] con la información editada para actualizarse en la base de datos (Nombre y Descripción).
        /// Devuelve un valor booleano para notificar si el registro fue editado o no.
        /// </summary>
        public bool Editar(Rol obj)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.RolesEditar;

            comandoSql.Parameters.Add("@rol_nombre", SqlDbType.VarChar).Value = obj.Nombre;
            comandoSql.Parameters.Add("@rol_descripcion", SqlDbType.VarChar).Value = obj.Descripcion;
            comandoSql.Parameters.Add("@rol_id", SqlDbType.Int).Value = obj.Id;

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            int editado = comandoSql.ExecuteNonQuery();

            conexionSql.Close();

            return (editado > 0);
        }

        /// <summary>
        /// El método permite obtener la lista de registros de la entidad [Rol] desde la base de datos.
        /// Los campos que se devuelven son: Id, Nombre y Descripción.
        /// En caso de no existir ningún registro se devuelve una lista nula o vacía.
        /// </summary>
        public List<Rol> Listar()
        {
            List<Rol> roles = new List<Rol>();

            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.RolesListar;

            comandoSql.Parameters.Clear();

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            SqlDataReader reader = comandoSql.ExecuteReader();
            

            while (reader.Read())
            {
                Rol r = new Rol();
                r.Id = reader.GetInt32(0);
                r.Nombre = reader.GetString(1);
                r.Descripcion = reader.GetString(2);
                r.Estado = reader.GetBoolean(3);

                roles.Add(r);
            }
            reader.Close();

            conexionSql.Close();

            this.rol.Clear();
            this.rol = roles;


            return roles;
        }


        public List<Rol> ListarPorEstado(bool Estado)
        {
            // Actualizar
            Listar();

            List<Rol> rols = new List<Rol>();

            foreach (Rol p in rol)
            {
                if (p.Estado == Estado)
                {
                    rols.Add(p);
                }
            }

            return rols;
        }






    }
}
