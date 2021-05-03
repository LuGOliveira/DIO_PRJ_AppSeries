using System.Collections.Generic;

namespace DIO_PRJ_AppSeries.Interfaces
{
    public interface IRepositorio<T>
    {
        List<T> Lista ();
        T RetornaPorId(int id);
        void Insere(T entidade);
        void Exclui(int id);
        void Atualiza(int id, T entidade);
        int ProximoID();
    }
}