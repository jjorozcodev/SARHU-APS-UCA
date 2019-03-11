using System.Collections.Generic;

namespace Datos
{
    interface IDatos<Clase>
    {
        bool Crear(Clase obj);
        List<Clase> Listar();
        bool Actualizar(Clase obj);
        bool Borrar(int id);
    }
}
