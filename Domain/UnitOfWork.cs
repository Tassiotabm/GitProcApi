﻿using GitProc.Data.Repository;
using GitProc.Data.Repository.Abstractions;
using GitProc.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GitProc.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DomainDbContext _context;

        public UnitOfWork(DomainDbContext context)
        {
            _context = context;
            Advogado = new AdvogadoRepository(_context);
            Usuario = new UsuarioRepository(_context);
            Escritorio = new EscritorioRepository(_context);
            ProcessoMaster = new ProcessoMasterRepository(_context);
            Processo = new ProcessoRepository(_context);
        }

        public IAdvogadoRepository Advogado { get; private set; }
        public IUsuarioRepository Usuario { get; private set; }
        public IEscritorioRepository Escritorio { get; private set; }
        public IProcessoMasterRepository ProcessoMaster { get; private set; }
        public IProcessoRepository Processo { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public Task<int> CompleteAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
