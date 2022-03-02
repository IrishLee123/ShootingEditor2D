using FrameworkDesign;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ShootingEditor2D.View.GamePlay
{
    public class NextLevel : MonoBehaviour, IController
    {
        public string LevelName;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Player"))
            {
                SceneManager.LoadScene(LevelName);
            }
        }

        public IArchitecture GetArchitecture()
        {
            return ShootingEditorApp.Interface;
        }
    }
}