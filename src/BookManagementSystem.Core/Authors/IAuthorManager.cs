using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.Authors
{
    public interface IAuthorManager
    {
        //Returns a list of all Author entities
        Task<List<Author>> GetAuthorAsync();
        //Returns an Author entity with the given id
        Task<Author> GetAuthorByIdAsync(int id);
        //Creates a new Author entity
        Task CreateAuthorAsync(Author author);
        //Updates an existing Author entity
        Task UpdateAuthorAsync(Author author);
        //Deletes an Author entity with the given id
        Task DeleteAuthorAsync(int id);
    }
}
