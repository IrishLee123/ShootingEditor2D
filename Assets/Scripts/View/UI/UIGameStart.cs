using FrameworkDesign;
using UnityEngine;
using UnityEngine.UI;

namespace ShootingEditor2D
{
    public class UIGameStart : MonoBehaviour, IController
    {
        public IArchitecture GetArchitecture()
        {
            return ShootingEditorApp.Interface;
        }
        
        private void Start()
        {
            var startBtn = transform.Find("BtnStart").GetComponent<Button>();
            if (startBtn != null)
            {
                startBtn.onClick.AddListener(OnBtnStartGameClick);
            }
        }

        public void OnBtnStartGameClick()
        {
            this.SendCommand<GameStartCommand>();
        }
    }
}