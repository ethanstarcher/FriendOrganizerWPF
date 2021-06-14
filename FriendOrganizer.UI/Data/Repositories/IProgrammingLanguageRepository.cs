using FriendOrganizer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.Data.Repositories
{
   public interface IProgrammingLanguageRepository
        : IGenericRepository<ProgrammingLanguage>
    {
        Task<bool> IsReferencedByFriendAsync(int programmingLanguageId);
    }
}
