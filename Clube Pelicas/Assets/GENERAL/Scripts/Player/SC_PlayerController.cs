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
        public bool wonMiniGame;
        public bool lostMiniGame;
        public bool canDisplay;

        [Space]
        [SerializeField] GameObject resourceDisplay;
        bool isDisplaying;
        

        private Vector3 currentImpact;

        SC_ResourcesDisplay resourceD;

        CharacterController characterController;
        Rigidbody rb;

        #region - UNITY_FUNCTIONS -

        private void Awake()
        {

            characterController = GetComponent<CharacterController>();
            rb = GetComponent<Rigidbody>();
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
                ShowResourceDisplay();
            }

            if (canMove)
            {
                Move();
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
        }

        #endregion


        #region - PRIVATE_FUNCTIONS -

        void ShowResourceDisplay()
        {
            if (canDisplay)
            {
                if (!isDisplaying)
                {
                    resourceDisplay.SetActive(true);
                    isDisplaying = true;
                }
                else if (isDisplaying)
                {
                    resourceDisplay.SetActive(false);
                    isDisplaying = false;
                }
            }
            
        }

        #endregion








    }

}


