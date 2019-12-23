using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public static class SampleData
    {

        public static void InitData(EFDBContext context)
        {
            if (!context.Directories.Any())
            {
                context.Directories.Add(new Entityes.Directory() { Title = "First Directory", Html = "<b>Content</b>" });
                context.Directories.Add(new Entityes.Directory() { Title = "Second Directory", Html = "<b>Content</b>" });
                context.SaveChanges();

                context.Materials.Add(new Entityes.Material() { Title = "First Material", Html = "<i>Material</i>", DirectoryId = 1 });
                context.Materials.Add(new Entityes.Material() { Title = "Second Material", Html = "<i>Material</i>", DirectoryId = 2 });
                context.Materials.Add(new Entityes.Material() { Title = "Third Material", Html = "<i>Material</i>", DirectoryId = 2 });
                context.SaveChanges();
            }
        }
    }
}
