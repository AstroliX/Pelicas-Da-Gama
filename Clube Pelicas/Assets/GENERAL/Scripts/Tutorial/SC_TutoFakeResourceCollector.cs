using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pelicas
{
    public class SC_TutoFakeResourceCollector : MonoBehaviour
    {
        [SerializeField] GameObject resource_1;
        [SerializeField] GameObject resource_2;
        [SerializeField] GameObject resource_3;
        [SerializeField] GameObject resource_4;
        [SerializeField] GameObject resource_5;
        [SerializeField] GameObject resource_6;
        [SerializeField] GameObject resource_7;
        [SerializeField] GameObject resource_8;

        [Space]
        [SerializeField] GameObject slot_1;
        [SerializeField] GameObject slot_2;
        [SerializeField] GameObject slot_3;
        [SerializeField] GameObject slot_4;
        [SerializeField] GameObject slot_5;
        [SerializeField] GameObject slot_6;
        [SerializeField] GameObject slot_7;
        [SerializeField] GameObject slot_8;

        [Space]
        [SerializeField] int timeBtwResource;
        [SerializeField] GameObject collector;


        #region - UNITY_FUNCTIONS -

        private void Start()
        {
        
             collector.SetActive(true);
             StartCoroutine(StartCollectingResources());

        }

        IEnumerator StartCollectingResources()
        {
            yield return new WaitForSeconds(timeBtwResource+3);
            Instantiate(resource_1, slot_1.transform);
            yield return new WaitForSeconds(timeBtwResource);
            Instantiate(resource_2, slot_2.transform);
            yield return new WaitForSeconds(timeBtwResource);
            Instantiate(resource_3, slot_3.transform);
            yield return new WaitForSeconds(timeBtwResource);
            Instantiate(resource_4, slot_4.transform);
            yield return new WaitForSeconds(timeBtwResource);
            Instantiate(resource_5, slot_5.transform);
            yield return new WaitForSeconds(timeBtwResource);
            Instantiate(resource_6, slot_6.transform);
            yield return new WaitForSeconds(timeBtwResource);
            Instantiate(resource_7, slot_7.transform);
            yield return new WaitForSeconds(timeBtwResource);
            Instantiate(resource_8, slot_8.transform);
        }

        #endregion

        #region - PUBLIC_FUNCTIONS -
        #endregion

        #region - PRIVATE_FUNCTIONS -
        #endregion
    }

}
