namespace kontaktpersoner.Data
{
    using Microsoft.EntityFrameworkCore;

    // Repository class for handling CRUD operations on the KontaktPerson table in the database

    internal static class KontaktPersonerRepository
    {
        // Get all KontaktPersoner from the database and return all KontaktPersoner as a list of KontaktPerson objects

        internal static async Task<List<KontaktPerson>> GetKontaktPersonerAsync()
        {
            using var db = new AppDBContext();
            return await db.KontaktPersoner.ToListAsync();
        }

        // Get a single KontaktPerson by its KontaktId from the database 
        internal static async Task<KontaktPerson> GetKontaktByIdAsync(int KontaktId)
        {
            using var db = new AppDBContext();
            return await db.KontaktPersoner.FirstOrDefaultAsync(k => k.KontaktId == KontaktId);
        }

        // Create a new KontaktPerson in the database and return a boolean value indicating whether the operation was successful
        internal static async Task<bool> CreateKontaktAsync(KontaktPerson kontaktToCreate)
        {
            using var db = new AppDBContext();
            try
            {
                // Add the new KontaktPerson to the database
                await db.KontaktPersoner.AddAsync(kontaktToCreate);
                // Save the changes to the database  
                return await db.SaveChangesAsync() >= 1;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Update an existing KontaktPerson in the database and return a boolean value indicating whether the operation was successful
        internal static async Task<bool> UpdateKontaktAsync(KontaktPerson kontaktToUpdate)
        {
            using var db = new AppDBContext();
            try
            {
                db.KontaktPersoner.Update(kontaktToUpdate);

                return await db.SaveChangesAsync() >= 1;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Delete a KontaktPerson from the database and return a boolean value indicating whether the operation was successful
        internal static async Task<bool> DeleteKontaktAsync(int kontaktId)
        {
            using var db = new AppDBContext();
            try
            {
                KontaktPerson kontaktToDelete = await GetKontaktByIdAsync(kontaktId);

                db.Remove(kontaktToDelete);
                return await db.SaveChangesAsync() >= 1;
            }
            catch (Exception)
            {
                return false;
            }
        }

  
    }
}
