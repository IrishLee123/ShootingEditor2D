using FrameworkDesign;
using FrameWorkDesign;

namespace ShootingEditor2D.Query
{
    public class MaxBulletCountQuery : AbstractQuery<int>
    {
        private GunInfo mGunInfo;

        public MaxBulletCountQuery(GunInfo gunInfo)
        {
            mGunInfo = gunInfo;
        }

        protected override int OnDo()
        {
            var gunConfigModel = this.GetModel<IGunConfigModel>();
            var configItem = gunConfigModel.GetItemByName(mGunInfo.Name.Value);
            return configItem.BulletMaxCount;
        }
    }
}