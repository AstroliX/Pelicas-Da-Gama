using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pelicas
{
    public class SC_TutoNpcTrigger : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] GameObject npcPreview;
        [SerializeField] GameObject firstMenu;

        [Space]
        [Header("Cameras")]
        [SerializeField] GameObject playerCam;
        [SerializeField] GameObject npcCam;

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

        public bool menu_1;
        public bool menu_2;
        public bool menu_3;

        [Space]
        [SerializeField] bool isOnSea;


        Transform T_player;

        [SerializeField] GameObject npcGo;

        SC_TutoPlayerController tutoPlayer;
        SC_SeaPlayerController seaPlayerScript;
        SC_CursorController cursorScript;
        SC_TutoNpcAnim npcAnim;


        #region - UNITY_FUNCTIONS -

        private void Awake()
        {
            tutoPlayer = FindObjectOfType<SC_TutoPlayerController>();
            seaPlayerScript = FindObjectOfType<SC_SeaPlayerController>();
            cursorScript = FindObjectOfType<SC_CursorController>();
            npcAnim = FindObjectOfType<SC_TutoNpcAnim>();

            T_player = GameObject.FindGameObjectWithTag("Player").transform;

        }

        private void Start()
        {
            canInteract = true;
            menu_1 = true;
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
                        if (!tutoPlayer.isDisplaying)
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
            npcCam.SetActive(false);
            tutoPlayer.canMove = true;
            tutoPlayer.canDisplay = true;
            tutoPlayer.isTalking = false;



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


            if (!isOnSea)
            {
                tutoPlayer.isTalking = true;
                
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
            npcCam.SetActive(true);



            npcPreview.SetActive(false);
            firstMenu.SetActive(true);



        }

        #endregion






    }



}