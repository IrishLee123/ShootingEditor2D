using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

namespace ShootingEditor2D
{
    public class LevelPlayer : MonoBehaviour
    {
        public TextAsset LevelFile;

        private void Start()
        {
            var xml = LevelFile.text;

            var document = new XmlDocument();

            document.LoadXml(xml);

            var levelNode = document.SelectSingleNode("Level");

            foreach (XmlElement levelItemNode in levelNode.ChildNodes)
            {
                var levelItemName = levelItemNode.Attributes["name"].Value;
                var levelItemX = float.Parse(levelItemNode.Attributes["x"].Value);
                var levelItemY = float.Parse(levelItemNode.Attributes["y"].Value);

                var prefab = Resources.Load<GameObject>(levelItemName);
                var gameObject = Instantiate(prefab, transform);
                gameObject.transform.position = new Vector3(levelItemX, levelItemY, 0);

                Debug.Log(levelItemName + ":" + "(" + levelItemX + "," + levelItemY + ")");
            }
        }
    }
}