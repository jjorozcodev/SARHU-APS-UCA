using System.Collections.Generic;

namespace Datos
{
    interface I_CRUD<Entidad>
    {
        List<Entidad> Listar();
       
        Entidad Consultar(int id);
       
        int Agregar(Entidad obj);
        
        bool Editar(Entidad obj);
        
        bool Borrar(int id);
    }
}
