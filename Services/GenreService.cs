﻿using Bookstoret2.Data;
using Bookstoret2.Models;
using Bookstoret2.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Bookstoret2.Services
{
	public class GenreService
	{
		private readonly BookstoreContext _context;

		public GenreService(BookstoreContext context)
		{
			_context = context;
		}

		public async Task<List<Genre>> FindAllAsync()
		{
			return await _context.Genres.ToListAsync();
		}
		
		public async Task InsertAsync(Genre genre)
		{
			_context.Add(genre);
			await _context.SaveChangesAsync();
		}

		public async Task<Genre> FindByIdAsync(int id)
		{
			return await _context.Genres.FindAsync(id);
		}

		public async Task RemoveAsync(int id)
		{
			try
			{
				var obj = await _context.Genres.FindAsync(id);
				_context.Genres.Remove(obj);
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateException ex)
			{
				throw new IntegrityException(ex.Message);
			}
		}
	}	
}
