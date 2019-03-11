using System.Collections.Generic;

namespace Negocio
{
    interface INegocio<Clase>
    {
        bool Crear(Clase obj);
        List<Clase> Listar();
        bool Actualizar(Clase obj);
        bool Borrar(int id);
    }
}
