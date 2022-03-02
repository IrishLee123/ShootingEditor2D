using System;
using FrameworkDesign;
using UnityEngine;
using UnityEngine.SceneManagement;
using NotImplementedException = System.NotImplementedException;

namespace ShootingEditor2D.View.UI
{
    public class GameUIPass : MonoBehaviour, IController
    {
        private readonly Lazy<GUIStyle> mLabelStyle = new Lazy<GUIStyle>(() => new GUIStyle(GUI.skin.label)
        {
            fontSize = 80,
            alignment = TextAnchor.MiddleCenter
        });

        private readonly Lazy<GUIStyle> mButtonStyle = new Lazy<GUIStyle>(() => new GUIStyle(GUI.skin.button)
        {
            fontSize = 40,
            alignment = TextAnchor.MiddleCenter
        });

        private void OnGUI()
        {
            var labelWidth = 400;
            var labelHeight = 100;
            var labelPosition = new Vector2(Screen.width - labelWidth, Screen.height - labelHeight) * 0.5f;
            var labelSize = new Vector2(labelWidth, labelHeight);
            var labelRect = new Rect(labelPosition, labelSize);
            GUI.Label(labelRect, "游戏通关", mLabelStyle.Value);

            var buttonize = new Vector2(400, 100);
            var buttonRect = new Rect(
                new Vector2((Screen.width - 400) * 0.5f, (Screen.height - 100) * 0.75f),
                buttonize
            );
            if (GUI.Button(buttonRect, "返回首页", mButtonStyle.Value))
            {
                Debug.Log("返回首页");
                SceneManager.LoadScene("Game");
            }
        }

        public IArchitecture GetArchitecture()
        {
            return ShootingEditorApp.Interface;
        }
    }
}