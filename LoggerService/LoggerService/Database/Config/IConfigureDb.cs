using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggerService.Database.Config
{
    public interface IConfigureDb
    {
        public void ConfigureDB(ModelBuilder modelBuilder);
    }
}
