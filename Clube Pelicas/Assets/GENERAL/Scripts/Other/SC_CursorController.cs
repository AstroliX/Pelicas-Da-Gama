using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pelicas
{
    public class SC_CursorController : MonoBehaviour
    {
        [SerializeField] Texture2D cursorVEVO;
        [SerializeField] bool isSea;

        SC_CameraController cameraScript;

        #region - UNITY_FUNCTIONS -

        private void Awake()
        {
            if (!isSea)
            {
                cameraScript = FindObjectOfType<SC_CameraController>();
            }
            
        }

        #endregion


        #region - PUBLIC_FUNCTIONS -

        public void ActivateCursor()
        {
            Cursor.SetCursor(cursorVEVO, Vector2.zero, CursorMode.Auto);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            if (!isSea)
            {
                cameraScript.isInMenu = true;
            }
            

        }


        public void DeactivateCursor()
        {
            if (!isSea)
            {
                cameraScript.isInMenu = false;
            }
            
            Cursor.visible = false;
            Cursor.SetCursor(cursorVEVO, Vector2.zero, CursorMode.Auto);
            Cursor.lockState = CursorLockMode.Locked;
        }

        #endregion


        #region - PRIVATE_FUNCTIONS -
        #endregion




    }
}


