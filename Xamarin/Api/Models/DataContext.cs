using System.Data.Entity;

namespace Api.Models
{
    public class DataContext:DbContext
    {
        public DataContext(): base ("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<Api.Models.List> Lists { get; set; }
    }
}