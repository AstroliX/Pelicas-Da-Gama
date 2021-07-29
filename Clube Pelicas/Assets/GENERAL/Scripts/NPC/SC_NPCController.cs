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

        [Space]
        [Header("King's taxi random shit")]
        [SerializeField] GameObject kingPalace;
        [SerializeField] GameObject taxiTown;
        /*[SerializeField] Transform goToKingTarget;
        [SerializeField] float speed;*/
        [SerializeField] GameObject town;
        [SerializeField] GameObject palace;
        bool isTraveling;

        [Space]
        [SerializeField] bool isOnSea;
        

        Transform T_player;

        SC_PlayerController playerScript;
        SC_SeaPlayerController seaPlayerScript;
        SC_CursorController cursorScript;


        #region - UNITY_FUNCTIONS -

        private void Awake()
        {
            playerScript = FindObjectOfType<SC_PlayerController>();
            seaPlayerScript = FindObjectOfType<SC_SeaPlayerController>();
            cursorScript = FindObjectOfType<SC_CursorController>();

            T_player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        private void Start()
        {
            canInteract = true;
        }

        private void Update()
        {
            /*if (isTraveling)
            {
                canInteract = false;
                transform.position = Vector2.MoveTowards(transform.position, goToKingTarget.position, speed * Time.deltaTime);
                T_player.position = Vector2.MoveTowards(T_player.position, goToKingTarget.position, speed * Time.deltaTime);
            }*/
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
                    NPCisTalking();
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

        #endregion


        #region - PUBLIC_FUNCTIONS -

        public void LeaveSetup()
        {
            if (!isOnSea)
            {
                cursorScript.DeactivateCursor();
                playerCam.SetActive(true);
                playerScript.canMove = true;
            }
            else
            {
                seaPlayerScript.canMove = true;
            }
            
            npcIsTalking.SetActive(false);


            playerCam.SetActive(true);
            npcCam.SetActive(false);
            playerScript.canDisplay = true;

        }

        public void GoToPalace()
        {
            //T_player.position = kingPalace.transform.position;
            playerScript.enabled = false;
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
            playerScript.enabled = false;
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
            if (!isOnSea)
            {
                
                cursorScript.ActivateCursor();
                playerScript.canMove = false;
            }
            else
            {
                seaPlayerScript.canMove = false;
            }


            playerCam.SetActive(false);
            npcCam.SetActive(true);

            playerScript.canDisplay = false;

            npcPreview.SetActive(false);
            npcIsTalking.SetActive(true);
        }

        #endregion






    }

}
