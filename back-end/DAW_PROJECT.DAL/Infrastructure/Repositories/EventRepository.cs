using DAW_PROJECT.DAL.Entities;
using DAW_PROJECT.DAL.Infrastructure.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAW_PROJECT.DAL.Infrastructure.Repositories
{
    public class EventRepository:BaseRepository<Event>, IEventRepository
    {
        public EventRepository(AppDbContext context):base(context)
        { }
         
    }
}
