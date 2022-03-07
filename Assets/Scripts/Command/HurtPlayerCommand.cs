using FrameworkDesign;
using ShootingEditor2D.Model;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            var model = this.GetModel<IPlayerModel>();
            model.HP.Value -= Hurt;

            if (model.HP.Value <= 0)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
    }
}