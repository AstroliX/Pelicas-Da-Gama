using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pelicas
{
    public class SC_FirstInstanceManager : MonoBehaviour
    {

        [Space]
        [Header("Other")]
        [SerializeField] GameObject animIntro;
        public bool canTuto;


        int notFirstInstance;
        bool firstPlay;


        #region - UNITY_FUNCTIONS -
        private void Awake()
        {
            
            notFirstInstance = PlayerPrefs.GetInt("FirstInstance_7");

            if (Application.isEditor == false)
            {
                if (PlayerPrefs.GetInt("FirstPlay", 1) == 1)
                {
                    if(PlayerPrefs.GetInt("FirstInstance_7") == 0)
                    {
                        Debug.Log("Broooo");
                        PlayerPrefs.DeleteAll();
                        PlayerPrefs.SetFloat("crew", 100f);
                        PlayerPrefs.SetInt("FirstInstance_7", 1);
                        canTuto = true;

                    }
                    firstPlay = true;
                    

                    
                    Debug.Log("First Instance");

                    
                    animIntro.SetActive(true);
                }
                else
                {
                    firstPlay = false;
                    canTuto = false;
                    Debug.Log("Hello again I guess");
                }              
            }

            if (notFirstInstance == 0)
            {
                Debug.Log("First Instance");
                
                PlayerPrefs.SetInt("FirstInstance_7", 1);
                notFirstInstance += 1;

            }
            else
            {
                Debug.Log("Not first Instance");
            }

            #endregion

            #region - PUBLIC_FUNCTIONS -
            #endregion

            #region - PRIVATE_FUNCTIONS -
            #endregion
        }
    }
}

