using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Pelicas
{
    public class SC_NPCController : MonoBehaviour
    {
     
        [Header("UI")]
        [SerializeField] GameObject npcPreview;
        [SerializeField] GameObject npcIsTalking;

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

        [Space]
        [SerializeField] bool isOnSea;
        

        Transform T_player;

        [SerializeField] GameObject npcGo;

        SC_PlayerController playerScript;
        SC_SeaPlayerController seaPlayerScript;
        SC_CursorController cursorScript;
        SC_NPCAnim npcAnim;


        #region - UNITY_FUNCTIONS -

        private void Awake()
        {
            playerScript = FindObjectOfType<SC_PlayerController>();
            seaPlayerScript = FindObjectOfType<SC_SeaPlayerController>();
            cursorScript = FindObjectOfType<SC_CursorController>();
            npcAnim = FindObjectOfType<SC_NPCAnim>();

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
                npcGo.GetComponent<SC_NPCAnim>().canIdle = false;
                npcGo.GetComponent<SC_NPCAnim>().PlayNPCAnimBye();
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
                        if (!playerScript.isDisplaying)
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
            playerScript.enabled = true;
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
            isTalking = false;
            StartCoroutine(Goodbye());
            npcAnim.PlayNPCAnimBye();

            

            if (!isOnSea)
            {
                playerScript.isTalking = false;
                cursorScript.DeactivateCursor();
                playerCam.SetActive(true);
                playerScript.canMove = true;
                playerScript.canDisplay = true;
            }
            else
            {
                seaPlayerScript.isSeaTalking = false;
                seaPlayerScript.canMove = true;
                seaPlayerScript.isSeaTalking = false;
            }
            
            npcIsTalking.SetActive(false);


            playerCam.SetActive(true);
            npcCam.SetActive(false);
            

        }

        public void GoToPalace()
        {
            //T_player.position = kingPalace.transform.position;

            StartCoroutine(StartDelay());
            IEnumerator StartDelay()
            {
                yield return new WaitForSeconds(2);
                playerScript.enabled = false;
                T_player.position = new Vector3(0, 0, 380);
                town.SetActive(false);
            }

            
            LeaveSetup();
            //animation / transition


            palace.SetActive(true);
            
           
            StartCoroutine(Wait());
        }

        public void ReturnToTown()
        {
            //T_player.position = kingPalace.transform.position;
            LeaveSetup();
            StartCoroutine(StartDelay());
            IEnumerator StartDelay()
            {
                yield return new WaitForSeconds(2);
                playerScript.enabled = false;
                T_player.position = new Vector3(-5, 0.70f, -34);
                palace.SetActive(false);
            }
            playerScript.enabled = false;

            
            //animation / transition


    

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
            isTalking = true;
            

            if (!isOnSea)
            {
                playerScript.isTalking = true;
                cursorScript.ActivateCursor();
                playerScript.canMove = false;
                playerScript.canDisplay = false;
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
            npcIsTalking.SetActive(true);

            
            
        }

        #endregion






    }

}
