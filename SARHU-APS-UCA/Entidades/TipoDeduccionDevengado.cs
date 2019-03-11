namespace Entidades
{
    public class TipoDeduccionDevengado
    {
        private int idTipoDD;
        private string concepto;
        private bool devengado;

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

        public string Concepto
        {
            get
            {
                return concepto;
            }

            set
            {
                concepto = value;
            }
        }

        public bool Devengado
        {
            get
            {
                return devengado;
            }

            set
            {
                devengado = value;
            }
        }
    }
}
