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
        [SerializeField] Transform[] waypoints_4;
        [SerializeField] float speed;
        public bool isMoving;

        [SerializeField] GameObject wGroup_1;
        [SerializeField] GameObject wGroup_2;
        [SerializeField] GameObject wGroup_3;
        [SerializeField] GameObject wGroup_4;

        public int waypointIndex;
      

        SC_TutoManager tuto;
        SC_TutoNpcTrigger tutoTrigger;

        #region - UNITY_FUNCTIONS -

        private void Awake()
        {
            tuto = FindObjectOfType<SC_TutoManager>();
            tutoTrigger = FindObjectOfType<SC_TutoNpcTrigger>();
        }

        private void Start()
        {
            //transform.position = waypoints_1[waypointIndex].transform.position;
            if (tuto.step_4)
            {
                waypoints_1[3].gameObject.SetActive(false);
            }
        }

        private void Update()
        {
            if (isMoving)
            {
                if (tuto.step_1)
                {
                    wGroup_1.SetActive(true);
                    Move_1();
                    
                }
                else if (tuto.step_2)
                {

                }
                else if (tuto.step_4)
                {
                    wGroup_2.SetActive(true);
                    Move_2();
                }
                else if (tuto.step_7)
                {
                    wGroup_3.SetActive(true);
                    Move_3();
                }
                else if (tuto.step_8)
                {
                    wGroup_4.SetActive(true);
                    Move_4();
                }
                

            }


        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag == "StopMoving")
            {
                Debug.Log("Arrived");
                isMoving = false;
                if (tuto.step_1)
                {
                    wGroup_1.SetActive(false);
                    tuto.step_2 = true;
               
                    Debug.Log("Step is 2");
                    tutoTrigger.canInteract = false;
                    tutoTrigger.canPreview = true;
                    tuto.step_1 = false;
                }

                if (tuto.step_4)
                {
                    wGroup_2.SetActive(false);
                    tutoTrigger.canInteract = false;
                    tutoTrigger.canPreview = true;
                    Debug.Log("Step is 5");
                    tuto.step_5 = true;
                    tuto.step_4 = false;
                }

                if (tuto.step_7)
                {
                    Debug.Log("wALK 3 DONE");
                    wGroup_3.SetActive(false);
                    tutoTrigger.canInteract = false;
                    tutoTrigger.canPreview = true;

                }

                if (tuto.step_8)
                {
                    Debug.Log("wALK 4 DONE");
                    wGroup_4.SetActive(false);
                    tutoTrigger.canInteract = false;
                    tutoTrigger.canPreview = true;

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

        public void Move_2()
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints_2[waypointIndex].position, speed * Time.deltaTime);


            if (Vector3.Distance(transform.position, waypoints_2[waypointIndex].position) < 0.1f)
            {
                waypointIndex++;
            }
        }

        public void Move_3()
        {
            
            transform.position = Vector3.MoveTowards(transform.position, waypoints_3[waypointIndex].position, speed * Time.deltaTime);


            if (Vector3.Distance(transform.position, waypoints_3[waypointIndex].position) < 0.1f)
            {
                waypointIndex++;
            }
        }

        public void Move_4()
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints_4[waypointIndex].position, speed * Time.deltaTime);


            if (Vector3.Distance(transform.position, waypoints_4[waypointIndex].position) < 0.1f)
            {
                waypointIndex++;
            }
        }

        #endregion

        #region - PRIVATE_FUNCTIONS -



        #endregion
    }

}
