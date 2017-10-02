using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Collections.Generic;

namespace EFBF7.Concrete
{
    public class EFDbContext : DbContext
    {
        public EFDbContext()
            : base("name=BF7")
        {

        }


    }
}
