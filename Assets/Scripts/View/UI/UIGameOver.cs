using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ShootingEditor2D
{
    public class UIGameOver : MonoBehaviour
    {
        private void Start()
        {
            var startBtn = transform.Find("BtnReturn").GetComponent<Button>();
            if (startBtn != null)
            {
                startBtn.onClick.AddListener(OnBtnReturnClick);
            }
        }

        public void OnBtnReturnClick()
        {
            Debug.Log("返回主页");
            SceneManager.LoadScene("GameStart");
        }
    }
}