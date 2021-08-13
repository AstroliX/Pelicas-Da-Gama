using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Pelicas
{
    public class SC_TutoNpcTrigger : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] GameObject npcPreview;
        [SerializeField] GameObject dialog_1;
        [SerializeField] GameObject dialog_2;
        [SerializeField] GameObject dialog_3;
        [SerializeField] GameObject dialog_4;
        [SerializeField] GameObject goBack;
        [SerializeField] GameObject dialog_5;
        [SerializeField] GameObject dialog_6;


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
        public bool playerWithKing;

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
        bool canGoBack;
        public bool canPreview;

       

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
            canPreview = true;
            

        }

        private void Update()
        {
            if (isGoodbye)
            {
                npcGo.GetComponent<SC_TutoNpcAnim>().canIdle = false;
                npcGo.GetComponent<SC_TutoNpcAnim>().PlayNPCAnimBye();
            }

            if (npcController.isMoving)
            {
                canInteract = false;
            }
          
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player" && canPreview)
            {
                npcPreview.SetActive(true);
                canInteract = true;

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
                if (canPreview)
                {
                    npcPreview.SetActive(true);
                }
                
                if (Input.GetKeyDown(KeyCode.T))
                {
                    if (!isOnSea)
                    {
                        if (!tutoPlayer.isDisplaying && tutoPlayer.canTalk && canInteract)
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

            if (tuto.step_2)
            {
                tuto.step_3 = true;
                tuto.step_2 = false;
                SceneManager.LoadScene("Scene_TutoSea");
            }

            if (canGoBack)
            {
                npcCam_1.SetActive(false);
                cursorScript.DeactivateCursor();
                goBack.SetActive(false);
                canPreview = true;
            }

            if (tuto.step_3)
            {
                npcCam_1.SetActive(false);
                canPreview = true;
                canGoBack = true;
                PlayerPrefs.SetInt("secondTime", 1);
            }

            if (tuto.step_4)
            {
                npcCam_2.SetActive(false);
                canPreview = false;
                canInteract = false;
                npcController.isMoving = true;
            }

            if (tuto.step_5)
            {
                npcCam_1.SetActive(false);
                canPreview = true;
            }

            if (tuto.step_6)
            {
                npcCam_1.SetActive(false);
                canPreview = true;
                tuto.step_7 = true;
                tuto.step_6 = false;
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
            canPreview = false;

            Debug.Log("Ola");

       
            
            //tutoPlayer.isTalking = true;
                
            tutoPlayer.canMove = false;
            tutoPlayer.canDisplay = false;
            
            

            
            playerCam.SetActive(false);
            



            npcPreview.SetActive(false);

             if (tuto.step_1)
            {
                dialog_1.SetActive(true);
                npcCam_1.SetActive(true);
            }

            if (tuto.step_2)
            {
                dialog_2.SetActive(true);
                npcCam_1.SetActive(true);
            }

            if (tuto.step_3 && !canGoBack)
            {
                dialog_3.SetActive(true);
                npcCam_1.SetActive(true);
            }
            else if (canGoBack)
            {

                goBack.SetActive(true);
                cursorScript.ActivateCursor();
                npcCam_1.SetActive(true);
            }

            if(tuto.step_4 == true)
            {
                dialog_4.SetActive(true);
                npcCam_2.SetActive(true);
            }

            if(tuto.step_5 == true)
            {
                dialog_5.SetActive(true);
                npcCam_1.SetActive(true);
            }

            if (tuto.step_6)
            {
                dialog_6.SetActive(true);
                npcCam_1.SetActive(true);
            }


        }

        #endregion






    }



}
