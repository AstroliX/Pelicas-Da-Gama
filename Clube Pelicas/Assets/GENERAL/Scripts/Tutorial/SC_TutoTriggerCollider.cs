using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pelicas
{
    public class SC_TutoTriggerCollider : MonoBehaviour
    {
        [SerializeField] GameObject collider_5;

        SC_TutoManager tuto;
        SC_TutoNpcTrigger tutoTrigger;

        #region - UNITY_FUNCTIONS -

        private void Awake()
        {
            tuto = FindObjectOfType<SC_TutoManager>();
            tutoTrigger = FindObjectOfType<SC_TutoNpcTrigger>();
        }

        private void Update()
        {
            if (tuto.step_6)
            {
                collider_5.SetActive(false);
            }
        }

        public void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag == "Player" && tuto.step_5)
            {
                collider_5.SetActive(true);
                tutoTrigger.canInteract = false;

            }
        }

        #endregion

        #region - PUBLIC_FUNCTIONS -



        #endregion

        #region - PRIVATE_FUNCTIONS -



        #endregion
    }

}
