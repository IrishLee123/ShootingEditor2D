using FrameworkDesign;
using ShootingEditor2D;

namespace Command
{
    public class ReloadCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            var currentGun = this.GetSystem<IGunSystem>().CurrentGun;

            if (currentGun.State.Value == GunState.Reload || currentGun.BulletCountOutGun.Value <= 0)
            {
                return;
            }

            var gunConfigItem = this.GetModel<IGunConfigModel>().GetItemByName(currentGun.Name.Value);

            var needBulletCount = gunConfigItem.BulletMaxCount - currentGun.BulletCountInGun.Value;

            if (needBulletCount <= 0)
            {
                return;
            }

            var delatCount = 0;
            if (currentGun.BulletCountOutGun.Value >= needBulletCount)
            {
                delatCount = needBulletCount;
            }
            else
            {
                delatCount = currentGun.BulletCountOutGun.Value;
            }

            currentGun.BulletCountOutGun.Value -= delatCount;
            currentGun.State.Value = GunState.Reload;

            this.GetSystem<ITimeSystem>().AddDelayTask(gunConfigItem.ReloadSeconds,
                () =>
                {
                    currentGun.BulletCountInGun.Value += delatCount;
                    currentGun.State.Value = GunState.Idle;
                });
        }
    }
}