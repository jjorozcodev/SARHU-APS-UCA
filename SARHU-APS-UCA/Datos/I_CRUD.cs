using System.Data;

namespace Datos
{
    interface I_CRUD<Entidad>
    {
        DataTable Listar();
        Entidad Consultar(int id);
        bool Agregar(Entidad obj);
        bool Editar(Entidad obj);
        bool Borrar(int id);
    }
}
