﻿using DevInHouse.EFCoreApi.Core.Entities;
using DevInHouse.EFCoreApi.Data.Context;
using DevInHouse.EFCoreApi.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DevInHouse.EFCoreApi.Data.Repositories
{
    public class AutorRepository : IAutorRepository
    {
        private readonly DataContext _context;

        public AutorRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Autor>> ObterAutoresAsync() => await
            _context.Autores.ToListAsync();

        public async Task<IEnumerable<Autor>> ObterAutoresV2Async(string nome) => await
            _context.Autores.Where(autor => autor.Nome.Contains(nome)).ToListAsync();

        public async Task<Autor?> ObterPorIdAsync(int id) => await
            _context.Autores
                .FirstOrDefaultAsync(p => p.Id == id);

        public async Task<Autor?> ObterPorNomeAsync(string nome) => await
            _context.Autores
                .FirstOrDefaultAsync(p => p.Nome == nome);


        public async Task<int> InserirAutorAsync(Autor autor)
        {
            _context.Autores.Add(autor);
            await SaveChangesAsync();
            return autor.Id;
        }

        private async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
