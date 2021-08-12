using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pelicas
{
    public class SC_TutoNpcController : MonoBehaviour
    {
        [SerializeField] Transform[] waypoints_1;
        [SerializeField] Transform[] waypoints_2;
        [SerializeField] Transform[] waypoints_3;
        [SerializeField] float speed;
        public bool isMoving;


        int waypointIndex;

        SC_TutoManager tuto;

        #region - UNITY_FUNCTIONS -

        private void Awake()
        {
            tuto = FindObjectOfType<SC_TutoManager>();
        }

        private void Start()
        {
            //transform.position = waypoints_1[waypointIndex].transform.position;
        }

        private void Update()
        {
            if (isMoving)
            {
                if (tuto.step_1)
                {
                    Move_1();
                }
                else if (tuto.step_2)
                {

                }
                else if (tuto.step_3)
                {

                }
                

            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag == "StopMoving")
            {
                isMoving = false;
                if (tuto.step_1)
                {
                    tuto.step_2 = true;
                    tuto.step_1 = false;
                }
                
            }
        }



        #endregion

        #region - PUBLIC_FUNCTIONS -

        public void Move_1()
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints_1[waypointIndex].position, speed * Time.deltaTime);


            if (Vector3.Distance(transform.position, waypoints_1[waypointIndex].position) < 0.1f)
            {
                waypointIndex++;
            }
        }

        #endregion

        #region - PRIVATE_FUNCTIONS -

        

        #endregion
    }

}
