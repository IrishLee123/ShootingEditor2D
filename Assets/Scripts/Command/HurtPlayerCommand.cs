using FrameworkDesign;
using ShootingEditor2D.Model;

namespace ShootingEditor2D.Command
{
    public class HurtPlayerCommand : AbstractCommand
    {
        private int Hurt;

        public HurtPlayerCommand(int hurt = 1)
        {
            Hurt = hurt;
        }

        protected override void OnExecute()
        {
            this.GetModel<IPlayerModel>().HP.Value -= Hurt;
        }
    }
}