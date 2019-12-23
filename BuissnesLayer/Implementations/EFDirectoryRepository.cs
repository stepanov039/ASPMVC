using BuissnesLayer.Interfaces;
using DataLayer;
using DataLayer.Entityes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnesLayer.Implementations
{
    public class EFDirectoryRepository : IDirectoryRepository
    {
        private EFDBContext context;
        public EFDirectoryRepository(EFDBContext context)
        {
            this.context = context;
        }

        public  IEnumerable<Directory> GetAllDirectorys(bool includeMaterials = false)
        {
            if (includeMaterials)
                return  context.Set<Directory>().Include(x => x.Materials).AsNoTracking().ToList();
            else
                return  context.Directories.ToList();
        }

        public Directory GetDirectoryById(int directoryId, bool includeMaterials = false)
        {
            if (includeMaterials)
                return  context.Set<Directory>().Include(x => x.Materials).AsNoTracking().FirstOrDefault(x => x.Id == directoryId);
            else
                return  context.Directories.FirstOrDefault(x => x.Id == directoryId);
        }

        public void SaveDirectory(Directory directory)
        {
            if (directory.Id == 0)
                context.Directories.Add(directory);
            else
                context.Entry(directory).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteDirectory(Directory directory)
        {
            context.Directories.Remove(directory);
            context.SaveChanges();
        }
    }
}
