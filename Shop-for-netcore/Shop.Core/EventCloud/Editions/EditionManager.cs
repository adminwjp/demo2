using Abp.Application.Editions;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using EventCloud.Features;

namespace EventCloud.Editions
{
    public class EditionManager : AbpEditionManager
    {
        public EditionManager(
            IRepository<Edition> editionRepository,
            FeatureValueStore featureValueStore
           , IUnitOfWorkManager unitOfWorkManager
            )
            : base(
                editionRepository,
                featureValueStore
                 , unitOfWorkManager
                  )
        {
        }
    }
}
