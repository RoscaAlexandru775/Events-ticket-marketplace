using DAW_PROJECT.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAW_PROJECT.DAL.Infrastructure.Abstraction
{
    public interface IEventRepository:IBaseRepository<Event>
    {
    }
}
