using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.AcessoDados
{
    public class RepositorioBase<T> where T:class
    {
        protected readonly ApplicationContext banco;
        protected readonly DbSet<T> dbset;

        public RepositorioBase(ApplicationContext banco)
        {
            this.banco = banco;
            dbset = banco.Set<T>();
        }
    }
}
