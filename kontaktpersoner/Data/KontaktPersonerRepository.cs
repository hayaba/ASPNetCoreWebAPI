using Microsoft.EntityFrameworkCore;

namespace kontaktpersoner.Data
{
    internal static class KontaktPersonerRepository
    {
        internal static async Task<List<KontaktPerson>> GetKontaktPersonerAsync()
        {
            using var db = new AppDBContext();
            return await db.KontaktPersoner.ToListAsync();
        }
        internal static async Task<KontaktPerson> GetKontaktByIdAsync(int KontaktId)
        {
            using (var db = new AppDBContext())
            {
                return await db.KontaktPersoner.FirstOrDefaultAsync(k => k.KontaktId == KontaktId);
            }
        }
        internal static async Task<bool> AddKontaktAsync(KontaktPerson kontaktToCreate)
        {
            using var db = new AppDBContext();
            try
            {
                await db.KontaktPersoner.AddAsync(kontaktToCreate);
                return await db.SaveChangesAsync() >= 1;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
