using FrameworkDesign;
using ShootingEditor2D.Model;
using UnityEngine;
using UnityEngine.SceneManagement;
using NotImplementedException = System.NotImplementedException;

namespace ShootingEditor2D
{
    public class GameStartCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            Debug.Log("开始游戏");

            SceneManager.LoadScene("Game");

            this.GetModel<IPlayerModel>().HP.Value = 3;
            this.GetSystem<IGunSystem>().CurrentGun.BulletCount.Value = 3;
        }
    }
}