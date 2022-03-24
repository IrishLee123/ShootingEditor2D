using Command;
using FrameworkDesign;

namespace ShootingEditor2D
{
    public class ShootCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            var gunSystem = this.GetSystem<IGunSystem>();

            gunSystem.CurrentGun.BulletCountInGun.Value--;
            gunSystem.CurrentGun.State.Value = GunState.Shooting;

            var gunConfigItem = this.GetModel<IGunConfigModel>().GetItemByName(gunSystem.CurrentGun.Name.Value);

            var self = this;
            this.GetSystem<ITimeSystem>().AddDelayTask(1 / gunConfigItem.Frequency, () =>
            {
                gunSystem.CurrentGun.State.Value = GunState.Idle;

                if (gunSystem.CurrentGun.BulletCountInGun.Value <= 0)
                {
                    self.SendCommand<ReloadCommand>();
                }
            });
        }
    }
}