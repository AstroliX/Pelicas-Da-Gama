using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pelicas
{
    public class SC_TutoNpcController : MonoBehaviour
    {
        [SerializeField] Transform[] waypoints_1;
        [SerializeField] float speed;
        public bool isMoving;

        float dis;
        int waypointIndex;

        #region - UNITY_FUNCTIONS -
        private void Start()
        {
            //transform.position = waypoints_1[waypointIndex].transform.position;
        }

        private void Update()
        {
            if (isMoving)
            {
                transform.position = Vector3.MoveTowards(transform.position, waypoints_1[waypointIndex].position, speed * Time.deltaTime);

                
                if(Vector3.Distance(transform.position,waypoints_1[waypointIndex].position) < 0.1f)
                {
                    waypointIndex++;
                }

            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag == "StopMoving")
            {
                isMoving = false;
            }
        }

        #endregion

        #region - PUBLIC_FUNCTIONS -
        #endregion

        #region - PRIVATE_FUNCTIONS -


        #endregion
    }

}
