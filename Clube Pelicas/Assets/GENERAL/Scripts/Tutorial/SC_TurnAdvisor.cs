using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pelicas
{
    public class SC_TurnAdvisor : MonoBehaviour
    {
        bool canRight;
        bool canLeft;


        #region - UNITY_FUNCTIONS -

        private void Start()
        {
            canLeft = true;
            canRight = true;
        }

        public void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag == "TurnRight")
            {
                TurnToRight();
            }

            if (other.gameObject.tag == "TurnLeft")
            {
                TurnToLeft();
            }
        }

        IEnumerator TurnRightOnlyOnce()
        {
            canRight = false;
            yield return new WaitForSeconds(2);
            canRight = true;
        }

        IEnumerator TurnLeftOnlyOnce()
        {
            canLeft = false;
            yield return new WaitForSeconds(3);
            canLeft = true;
        }

        #endregion

        #region - PUBLIC_FUNCTIONS -
        #endregion

        #region - PRIVATE_FUNCTIONS -

        void TurnToRight()
        {
            if (canRight)
            {
                gameObject.transform.Rotate(0, 90, 0);
                StartCoroutine(TurnRightOnlyOnce());
                Debug.Log("Right");
            }
            
        }

        void TurnToLeft()
        {
            if (canLeft)
            {
                gameObject.transform.Rotate(0, -90, 0);
                StartCoroutine(TurnLeftOnlyOnce());
                Debug.Log("Left");
            }
            
        }

        #endregion
    }

}
