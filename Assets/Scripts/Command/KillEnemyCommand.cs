using FrameworkDesign;
using ShootingEditor2D.System;
using NotImplementedException = System.NotImplementedException;

namespace ShootingEditor2D.Command
{
    public class KillEnemyCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            this.GetSystem<IStatSystem>().KillCount.Value++;
        }
    }
}