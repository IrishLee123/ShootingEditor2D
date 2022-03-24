using System;
using FrameworkDesign;
using ShootingEditor2D.System;
using Random = UnityEngine.Random;

namespace ShootingEditor2D.Command
{
    public class KillEnemyCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            this.GetSystem<IStatSystem>().KillCount.Value++;

            var randomIndex = Random.Range(0, 100);

            if (randomIndex < 80)
            {
                this.GetSystem<IGunSystem>().CurrentGun.BulletCountInGun.Value += Random.Range(1, 4);
            }
        }
    }
}