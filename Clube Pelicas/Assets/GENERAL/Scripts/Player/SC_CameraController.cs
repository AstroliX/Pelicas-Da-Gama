using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pelicas
{
    public class SC_CameraController : MonoBehaviour
    {
        private float RotationSpeed = 1;
        public Transform Target, Player;
        float mouseX, mouseY;
        public bool isInMenu;

        #region - UNITY_FUNCTIONS -


        private void Start()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            isInMenu = false;
        }

        private void LateUpdate()
        {
            if (!isInMenu)
            {
                CamControl();
            }

        }

        #endregion

        #region - PUBLIC_FUNCTIONS -
        #endregion

        #region - PRIVATE_FUNCTIONS -

        void CamControl()
        {
            mouseX += Input.GetAxis("Mouse X") * RotationSpeed;
            //mouseY -= Input.GetAxis("Mouse Y") * RotationSpeed;
            mouseY = Mathf.Clamp(mouseY, -75, 40);

            transform.LookAt(Target);

            Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
            Player.rotation = Quaternion.Euler(0, mouseX, 0);
        }


        #endregion



    }
}
