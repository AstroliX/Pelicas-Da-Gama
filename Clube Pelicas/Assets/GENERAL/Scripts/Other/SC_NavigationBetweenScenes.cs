using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Pelicas
{
    public class SC_NavigationBetweenScenes : MonoBehaviour
    {

        
        [Space]
        [Header("Where will the player arrived ?")]
        [SerializeField] GameObject arrivedIn;



        Transform T_player;

        #region - UNITY_FUNCTIONS -

        private void Start()
        {
            T_player = GameObject.FindGameObjectWithTag("Player").transform;

        }


        public void OnTriggerEnter(Collider other)
        {

            if(other.gameObject.tag == "Player")
            {
                Traveling();
            }
        }
        #endregion


        #region - PUBLIC_FUNCTIONS -

        public void GoToSea(string levelName)
        {

            SceneManager.LoadScene(levelName);
        }


        public void ReturnToCity(string levelName)
        {

            SceneManager.LoadScene(levelName);
        }
        #endregion


        #region - PRIVATE_FUNCTIONS -

        void Traveling()
        {
            T_player.position = arrivedIn.transform.position;
        }

        #endregion

    }


}

