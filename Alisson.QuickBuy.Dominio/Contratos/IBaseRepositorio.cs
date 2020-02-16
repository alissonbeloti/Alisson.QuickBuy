using System;
using System.Collections.Generic;
using System.Text;

namespace Alisson.QuickBuy.Dominio.Contratos
{
    public interface IBaseRepositorio<TEntity>: IDisposable 
        where TEntity: class
    {
        void Adicionar(TEntity entity);
        TEntity ObterPorId(int id);
        IEnumerable<TEntity> ObterTodos();
        void Atualiazar(TEntity entity);
        void Remover(TEntity entity);
    }
}
