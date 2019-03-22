using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DT_Organizacion
    {
        //GLOBALES
        private Organizacion organizacion = null;
        private int codPais = 505;

        private SqlConnection conexionSql = Conexion.Instanciar().ConexionBD();
        private SqlCommand comandoSql = new SqlCommand();

        private static DT_Organizacion dtOrganizacion = null;
        private DT_Organizacion()
        {
            // Singleton
        }

        public static DT_Organizacion Instanciar()
        {
            if(dtOrganizacion == null)
            {
                dtOrganizacion = new DT_Organizacion();
            }

            return dtOrganizacion;
        }


        // Métodos

        /// <summary>
        /// El método permite consultar la información de la Organización.
        /// Toma el código del país declarado en esta clase.
        /// Devuelve un objeto [Organización] nulo en caso de no encontrarse, o con la información del registro en caso que exista.
        /// </summary>
        public Organizacion Obtener()
        {
            if(organizacion != null)
            {
                return organizacion;
            }

            return Consultar();
        }

        private Organizacion Consultar()
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.OrganizacionObtener;

            comandoSql.Parameters.Clear();
            comandoSql.Parameters.Add("@organizacion_pais", SqlDbType.Int).Value = codPais;

            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            SqlDataReader reader = comandoSql.ExecuteReader();
            Organizacion org = new Organizacion();

            while (reader.Read())
            {
                org.Pais = codPais;
                org.Nombre = reader["organizacion_nombre"].ToString();
                org.Mision = reader["organizacion_mision"].ToString();
                org.Vision = reader["organizacion_vision"].ToString();
                org.Descripcion = reader["organizacion_descripcion"].ToString();
                org.LocalidadId = int.Parse(reader["localidad_id"].ToString());
            }

            reader.Close();

            conexionSql.Close();

            organizacion = org;

            return org;
        }

        /// <summary>
        /// El método permite editar un registro de la entidad [Organizacion].
        /// Recibe como parámetro un objeto [Organizacion] con la información editada para actualizarse en la base de datos (Nombre, Descripción, Misión y Visión).
        /// Devuelve un valor booleano para notificar si el registro fue editado o no.
        /// </summary>
        public bool Editar(Organizacion obj)
        {
            comandoSql.Connection = conexionSql;
            comandoSql.CommandType = CommandType.StoredProcedure;
            comandoSql.CommandText = Procedimientos.OrganizacionEditar;
            
            comandoSql.Parameters.Clear();
            comandoSql.Parameters.Add("@organizacion_nombre", SqlDbType.VarChar).Value = obj.Nombre;
            comandoSql.Parameters.Add("@organizacion_descripcion", SqlDbType.VarChar).Value = obj.Descripcion;
            comandoSql.Parameters.Add("@organizacion_mision", SqlDbType.VarChar).Value = obj.Mision;
            comandoSql.Parameters.Add("@organizacion_vision", SqlDbType.VarChar).Value = obj.Vision;
            comandoSql.Parameters.Add("@organizacion_pais", SqlDbType.Int).Value = this.codPais;
            comandoSql.Parameters.Add("@localidad_id", SqlDbType.Int).Value = 0; // Aun no se puede asignar. 0 Puede ser por defecto.


            if (conexionSql.State == ConnectionState.Closed)
            {
                conexionSql.Open();
            }

            int editado = comandoSql.ExecuteNonQuery();

            conexionSql.Close();

            // Actualizar
            Consultar();

            return (editado > 0);
        }
    }
}
