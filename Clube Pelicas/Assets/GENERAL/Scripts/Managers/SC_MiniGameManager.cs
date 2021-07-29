using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pelicas
{
    public class SC_MiniGameManager : MonoBehaviour
    {
        public bool wonMiniGame;
        public bool lostMiniGame;
        public bool canGetResource = true;

        SC_ResourcesManager resourcesScript;


        #region - UNITY_FUNCTIONS -

        private void Awake()
        {
            wonMiniGame = (PlayerPrefs.GetInt("wonMiniGame") != 0);
            lostMiniGame = (PlayerPrefs.GetInt("lostMiniGame") != 0);

            resourcesScript = FindObjectOfType<SC_ResourcesManager>();
        }


        private void Start()
        {
            canGetResource = true;
        }

        #endregion


        #region - PUBLIC_FUNCTIONS -

        public void HeWon()
        {


            PlayerPrefs.SetInt("wonMiniGame", (wonMiniGame ? 1 : 0));
            wonMiniGame = true;

            if (canGetResource)
            {
                resourcesScript.gold++;
                canGetResource = false;
            }

            PlayerPrefs.SetInt("gold", resourcesScript.gold);

        }

        #endregion


        #region - PRIVATE_FUNCTIONS -
        #endregion




    }
}

