using DAW_PROJECT.DAL.Entities;
using DAW_PROJECT.DAL.Infrastructure.Abstraction;
using DAW_PROJECT.DAL.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAW_PROJECT.DAL.Infrastructure
{
    public class AppDataAccessLayer : IAppDataAccessLayer
    {
        private readonly AppDbContext context;

        public AppDataAccessLayer(AppDbContext context)
        {
            this.context = context;
        }

        public IEventRepository EventRepository
        {
            get
            {
                if (_EventRepository == null)
                {
                    _EventRepository = new EventRepository(context);
                }
                return _EventRepository;
            }
        }

        public ILocationRepository LocationRepository
        {
            get
            {
                if (_LocationRepository == null)
                {
                    _LocationRepository = new LocationRepository(context);
                }
                return _LocationRepository;
            }
        }

        public IOrganizerRepository OrganizerRepository
        {
            get
            {
                if (_OrganizerRepository == null)
                {
                    _OrganizerRepository = new OrganizerRepository(context);
                }
                return _OrganizerRepository;
            }
        }
        public IPaymentRepository PaymentRepository
        {
            get
            {
                if (_PaymentRepository == null)
                {
                    _PaymentRepository = new PaymentRepository(context);
                }
                return _PaymentRepository;
            }
        }


        #region private

        private IEventRepository _EventRepository;

        private ILocationRepository _LocationRepository;

        private IOrganizerRepository _OrganizerRepository;

        private IPaymentRepository _PaymentRepository;

        #endregion

        #region dispose

        private bool disposed = false;



        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
