using CatalogCars.Model.Database.Repositories.Default.Abstract;
using System;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework
{
    public class EFAnnouncementAdditionalInformationRepository : IAnnouncementAdditionalInformationRepository
    {
        private readonly CatalogCarsDbContext _context;

        public EFAnnouncementAdditionalInformationRepository(CatalogCarsDbContext context)
        {
            _context = context;
        }

        public DateTime GetMaxCreatedAt()
        {
            return _context.AnnouncementAdditionalInformation
                .Max(announcementAdditionalInformation => announcementAdditionalInformation.CreatedAt);
        }

        public DateTime GetMinCreatedAt()
        {
            return _context.AnnouncementAdditionalInformation
                .Min(announcementAdditionalInformation => announcementAdditionalInformation.CreatedAt);
        }
    }
}
