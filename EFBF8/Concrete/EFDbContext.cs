using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Collections.Generic;

namespace EFBF8.Concrete
{
    public class EFDbContext : DbContext
    {
        public EFDbContext()
            : base("name=BF8")
        {

        }


    }
}
