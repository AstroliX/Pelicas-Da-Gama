using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Pelicas
{
    public class SC_FadeProperty : MonoBehaviour
    {
        private Image myImage;
        private RectTransform MyRect;

        public Material instanceOfMat;
        public Shader shader;
        public float Size;
        public Vector2 Position;

        public float AnimationLength = 0;

        private float Timer = 0;

        #region - UNITY_FUNCTIONS -

        void Awake()
        {
            myImage = GetComponent<Image>();
            instanceOfMat = new Material(shader);

            MyRect = GetComponent<RectTransform>();
            MyRect.anchorMin = Vector2.zero;
            MyRect.anchorMax = Vector2.one;
            MyRect.sizeDelta = Vector2.zero;
            MyRect.anchoredPosition = Vector2.zero;

            instanceOfMat.SetFloat("Flashing White", Size);
            instanceOfMat.SetVector("_Pos", Position);
        }

        void Update()
        {
            instanceOfMat.SetFloat("_MainSize", Size);
            myImage.material = instanceOfMat;

            Timer = Time.deltaTime + Timer;

            if(Timer >= AnimationLength)
            {
                Destroy(gameObject);
            }
        }
        #endregion
    }
}
