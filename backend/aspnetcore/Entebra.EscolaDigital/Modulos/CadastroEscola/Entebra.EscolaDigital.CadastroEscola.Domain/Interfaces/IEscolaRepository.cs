using Entebra.EscolaDigital.CadastroEscola.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entebra.EscolaDigital.CadastroEscola.Domain.Interfaces;

public interface IEscolaRepository
{
    Task<IEnumerable<Escola>> GetAllAsync();
    Task<Escola?> GetByIdAsync(int id);
    Task<Escola?> GetByUidAsync(Guid uid);
    Task<int> InsertAsync(Escola escola);
    Task<int> UpdateAsync(Escola escola);
    Task<int> DeleteAsync(Escola escola);
}
