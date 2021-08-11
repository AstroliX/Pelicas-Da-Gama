using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Pelicas
{
    public class SC_IntroAnimTransition : MonoBehaviour
    {
        [SerializeField] GameObject menu;

        Animator MyAnimator;

        private bool Next = false;

        #region - UNITY_FUNCTIONS -

        void Start()
        {

            MyAnimator = gameObject.GetComponent<Animator>();

        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Next = true;
                //Debug.Log("Click!!");

            }

            if (Time.time < 10)
            {
                Next = false;
            }

            if (Next == true)
            {

                MyAnimator.SetBool("Next", true);
                menu.SetActive(true);
            }
        }

        #endregion

        #region - PUBLIC_FUNCTIONS -
        #endregion

        #region - PRIVATE_FUNCTIONS -
        #endregion


    }
}

