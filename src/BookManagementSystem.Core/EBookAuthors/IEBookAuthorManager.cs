using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.EBookAuthors
{
    public interface IEBookAuthorManager
    {
        Task<List<EBookAuthor>> GetEBookAuthorsAsync();
        Task<EBookAuthor> GetEBookAuthorsByIdAsync(int id);
        Task CreateEBookAuthorsAsync(EBookAuthor eBookAuthor);
        Task UpdateEBookAuthorsAsync(EBookAuthor eBookAuthor);
        Task DeleteEBookAuthorsAsync(int id);

    }
}
