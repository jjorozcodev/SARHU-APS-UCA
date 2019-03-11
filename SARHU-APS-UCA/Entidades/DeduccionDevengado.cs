using System;

namespace Entidades
{
    public class DeduccionDevengado
    {
        private int idDDEmpleado;
        private int idTipoDD;
        private int idEmpleado;
        private string descripcion;
        private DateTime fechaRegistro;
        private float valorPorcentual;
        private float valorAbsoluto;

        public int IdDDEmpleado
        {
            get
            {
                return idDDEmpleado;
            }

            set
            {
                idDDEmpleado = value;
            }
        }

        public int IdTipoDD
        {
            get
            {
                return idTipoDD;
            }

            set
            {
                idTipoDD = value;
            }
        }

        public int IdEmpleado
        {
            get
            {
                return idEmpleado;
            }

            set
            {
                idEmpleado = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return descripcion;
            }

            set
            {
                descripcion = value;
            }
        }

        public DateTime FechaRegistro
        {
            get
            {
                return fechaRegistro;
            }

            set
            {
                fechaRegistro = value;
            }
        }

        public float ValorPorcentual
        {
            get
            {
                return valorPorcentual;
            }

            set
            {
                valorPorcentual = value;
            }
        }

        public float ValorAbsoluto
        {
            get
            {
                return valorAbsoluto;
            }

            set
            {
                valorAbsoluto = value;
            }
        }
    }
}
