using GunControl.Interface.Repository;
using PCLBase.DataContracts;

namespace GunControl.Root.Repository
{
    public class ProjectBaseRepository : BaseRepository
    {
        protected IMasterRepository _MasterRepo;

        public ProjectBaseRepository(IMasterRepository masterRepository)
        {
            _MasterRepo = masterRepository;
        }
    }
}

