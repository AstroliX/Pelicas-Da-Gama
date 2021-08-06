using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pelicas
{
    public class SC_PlayerController : MonoBehaviour
    {
        [Header("Floats")]
        [SerializeField] private float movementSpeed;
        //[SerializeField] private float mass = 1f;
        [SerializeField] private float damping = 5f;
        private float velocityY;
        private readonly float gravity = Physics.gravity.y;


        [Space]
        [Header("Bools")]
        public bool canMove;
        public bool canDisplay;
        public bool isTalking;

        [Space]
        [Header("Escape Menu")]
        [SerializeField] GameObject resourceDisplay;
        [SerializeField] GameObject escapeMenuLogo;
        bool isDisplaying;
        

        private Vector3 currentImpact;

        
        SC_NPCController npc;

        CharacterController characterController;
        Rigidbody rb;
        Animation anim;

        #region - UNITY_FUNCTIONS -

        private void Awake()
        {
            npc = FindObjectOfType<SC_NPCController>();
            characterController = GetComponent<CharacterController>();
            rb = GetComponent<Rigidbody>();
            anim = GetComponent<Animation>();
        }

        private void Start()
        {
            canMove = true;
            canDisplay = true;
            
        }

        private void Update()
        {

            


            if (Input.GetKeyDown(KeyCode.R))
            {
                if (canDisplay)
                {
                    ShowResourceDisplay();
                }
                
            }

            if (canMove && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Z)))
            {
                Move();
                
            }
            else if(!isTalking)
            {
                anim.Play("ANIM_Idle");
            }


            if (isTalking)
            {
                anim.Stop("ANIM_Idle");
                anim.Play("ANIM_Talk");
            }

        }

        #endregion


        #region - PUBLIC_FUNCTIONS -

        public void Move()
        {

            Vector3 movementInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized;

            movementInput = transform.TransformDirection(movementInput);

            if (characterController.isGrounded && velocityY < 0f)
            {
                velocityY = 0f;
            }

            velocityY += gravity * Time.deltaTime;

            Vector3 velocity = movementInput * movementSpeed + Vector3.up * velocityY;
            if (currentImpact.magnitude > 0.2f)
            {
                velocity += currentImpact;
            }

            characterController.Move(velocity * Time.deltaTime);

            currentImpact = Vector3.Lerp(currentImpact, Vector3.zero, damping * Time.deltaTime);

            anim.Play("ANIM_Run");
        }

        public void PlayAnimHappy()
        {
            anim.Play("ANIM_Happy");
        }

        public void PlayAnimSad()
        {
            anim.Play("ANIM_Sad");
        }
        
        public void PlayAnimBye()
        {
            anim.Play("ANIM_Bye");
        }

        #endregion


        #region - PRIVATE_FUNCTIONS -

        void ShowResourceDisplay()
        {
            if (canDisplay)
            {
                if (!isDisplaying)
                {
                    escapeMenuLogo.SetActive(false);
                    resourceDisplay.SetActive(true);
                    isDisplaying = true;
                }
                else if (isDisplaying)
                {
                    escapeMenuLogo.SetActive(true);
                    resourceDisplay.SetActive(false);
                    isDisplaying = false;
                }
            }
            
        }

        #endregion








    }

}


