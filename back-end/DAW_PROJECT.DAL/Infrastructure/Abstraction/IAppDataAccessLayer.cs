using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAW_PROJECT.DAL.Infrastructure.Abstraction
{
    public interface IAppDataAccessLayer : IDisposable   
    {
        public IEventRepository EventRepository { get; }
        public ILocationRepository LocationRepository { get; }
        public IOrganizerRepository OrganizerRepository { get; }
        public IPaymentRepository PaymentRepository { get; }
    }
}
