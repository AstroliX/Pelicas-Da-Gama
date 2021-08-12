using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pelicas
{
    public class SC_TutoNpcTrigger : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] GameObject npcPreview;
        [SerializeField] GameObject dialog_1;
        [SerializeField] GameObject dialog_2;

        [Space]
        [Header("Cameras")]
        [SerializeField] GameObject playerCam;
        [SerializeField] GameObject npcCam;
        [SerializeField] GameObject npcCam_1;
        [SerializeField] GameObject npcCam_2;

        [Space]
        [Header("Bools")]
        public bool canInteract;
        public bool isTalking;

        [Space]
        [Header("King's taxi random shit")]
        [SerializeField] GameObject kingPalace;
        [SerializeField] GameObject taxiTown;
        /*[SerializeField] Transform goToKingTarget;
        [SerializeField] float speed;*/
        [SerializeField] GameObject town;
        [SerializeField] GameObject palace;
        bool isTraveling;

        bool isGoodbye;
        bool isHappy;

       

        [Space]
        [SerializeField] bool isOnSea;


        Transform T_player;

        [SerializeField] GameObject npcGo;

        SC_TutoPlayerController tutoPlayer;
        SC_SeaPlayerController seaPlayerScript;
        SC_CursorController cursorScript;
        SC_TutoNpcAnim npcAnim;
        SC_TutoManager tuto;
        SC_TutoNpcController npcController;


        #region - UNITY_FUNCTIONS -

        private void Awake()
        {
            tutoPlayer = FindObjectOfType<SC_TutoPlayerController>();
            seaPlayerScript = FindObjectOfType<SC_SeaPlayerController>();
            cursorScript = FindObjectOfType<SC_CursorController>();
            npcAnim = FindObjectOfType<SC_TutoNpcAnim>();
            tuto = FindObjectOfType<SC_TutoManager>();
            npcController = FindObjectOfType<SC_TutoNpcController>();

            T_player = GameObject.FindGameObjectWithTag("Player").transform;

        }

        private void Start()
        {
            canInteract = true;
            
        }

        private void Update()
        {
            if (isGoodbye)
            {
                npcGo.GetComponent<SC_TutoNpcAnim>().canIdle = false;
                npcGo.GetComponent<SC_TutoNpcAnim>().PlayNPCAnimBye();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                npcPreview.SetActive(true);

            }

            /* if(other.gameObject.tag == "TownLimit")
             {

                 isTraveling = false;
                 //T_player.position = kingPalace.transform.position;
                 canInteract = true;
                 playerScript.enabled = true;
             }*/
        }


        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                if (Input.GetKeyDown(KeyCode.T))
                {
                    if (!isOnSea)
                    {
                        if (!tutoPlayer.isDisplaying && tutoPlayer.canTalk)
                        {
                            NPCisTalking();
                        }
                    }
                    else
                    {
                        NPCisTalking();
                    }

                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                npcPreview.SetActive(false);
            }
        }

        IEnumerator Wait()
        {

            yield return new WaitForSeconds(2);
            tutoPlayer.enabled = true;
        }

        IEnumerator Goodbye()
        {
            isGoodbye = true;
            yield return new WaitForSeconds(1.2f);
            isGoodbye = false;

            npcGo.GetComponent<SC_NPCAnim>().canIdle = true;
        }



        #endregion


        #region - PUBLIC_FUNCTIONS -

        public void LeaveSetup()
        {
            //isTalking = false;
            StartCoroutine(Goodbye());
            npcAnim.PlayNPCAnimBye();



            if (!isOnSea)
            {
                tutoPlayer.isTalking = false;
                
                playerCam.SetActive(true);
                tutoPlayer.canMove = true;
                tutoPlayer.canDisplay = true;
            }
            else
            {
                seaPlayerScript.isSeaTalking = false;
                seaPlayerScript.canMove = true;
                
            }

            //firstMenu.SetActive(false);


            playerCam.SetActive(true);
            npcCam.SetActive(false);


        }

        public void LeaveTalk()
        {
            playerCam.SetActive(true);
            tutoPlayer.canMove = true;
            tutoPlayer.canDisplay = true;
            tutoPlayer.isTalking = false;

            if (tuto.step_1)
            {
                npcCam_1.SetActive(false);
                npcController.isMoving = true;
            }
            

        }

        public void GoToPalace()
        {
            //T_player.position = kingPalace.transform.position;
            tutoPlayer.enabled = false;
            T_player.position = new Vector3(0, 0, 380);

            LeaveSetup();
            //animation / transition


            palace.SetActive(true);

            town.SetActive(false);
            StartCoroutine(Wait());
        }

        public void ReturnToTown()
        {
            //T_player.position = kingPalace.transform.position;
            LeaveSetup();
            tutoPlayer.enabled = false;
            T_player.position = new Vector3(-5, 0.70f, -34);


            //animation / transition


            palace.SetActive(false);

            town.SetActive(true);
            StartCoroutine(Wait());
        }


        /*public void Traveling()
        {
            LeaveSetup();
            isTraveling = true;
            playerScript.enabled = false;


            StartCoroutine(Wait());
        }*/

        #endregion


        #region - PRIVATE_FUNCTIONS -

        void NPCisTalking()
        {
            //isTalking = true;

            Debug.Log("Ola");

            if (!isOnSea)
            {
                //tutoPlayer.isTalking = true;
                
                tutoPlayer.canMove = false;
                tutoPlayer.canDisplay = false;
            }
            else
            {
                seaPlayerScript.isSeaTalking = true;
                seaPlayerScript.canMove = false;
                seaPlayerScript.isSeaTalking = true;
            }

            
            playerCam.SetActive(false);
            



            npcPreview.SetActive(false);

             if (tuto.step_1)
            {
                dialog_1.SetActive(true);
                npcCam_1.SetActive(true);
            }

            /*if (tuto.step_2)
            {
                dialog_2.SetActive(true);
                npcCam_2.SetActive(true);
            }*/


        }

        #endregion






    }



}
