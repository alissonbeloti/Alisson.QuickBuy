﻿using System;
using System.Collections.Generic;
using System.Text;
using Alisson.QuickBuy.Dominio.Contratos;

namespace Alisson.QuickBuy.Repositorio.Repositorios
{
    public class BaseRepositorio<TEntity> : IBaseRepositorio<TEntity> where TEntity : class
    {
        public BaseRepositorio()
        {

        }
        public void Adicionar(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Atualiazar(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public TEntity ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public void Remover(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
