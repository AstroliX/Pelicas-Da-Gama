using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pelicas
{
    public class SC_SeaPlayerController : MonoBehaviour
    {
        [SerializeField] float speed;
        private float inputHorizontal;
        public bool canMove;
        Rigidbody rb;
        bool firstTimeOnSea;

        SC_KingSystem king;

        #region - UNITY_FUNCTIONS -

        private void Awake()
        {
            king = FindObjectOfType<SC_KingSystem>();
            rb = GetComponent<Rigidbody>();
           
        }

        private void Start()
        {
            canMove = true;
            king.PlayerInSea();
            
        }

        void Update()
        {


            if (canMove)
            {
                if (Input.GetKey(KeyCode.D))
                {

                    transform.rotation = Quaternion.Euler(0, 90, 0);
                }
                if (Input.GetKey(KeyCode.A))
                {

                    transform.rotation = Quaternion.Euler(0, -90, 0);
                }


                if (Input.GetKey(KeyCode.LeftArrow))
                {

                    transform.rotation = Quaternion.Euler(0, 90, 0);
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {

                    transform.rotation = Quaternion.Euler(0, -90, 0);
                }

                inputHorizontal = Input.GetAxisRaw("Horizontal");
                rb.velocity = new Vector2(inputHorizontal * speed, rb.velocity.y);
            }

            
        }
        #endregion

        #region - PUBLIC_FUNCTIONS -




        #endregion

        #region - PRIVATE_FUNCTIONS -


        #endregion
    }
}


