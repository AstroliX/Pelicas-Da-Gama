using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pelicas
{
    public class SC_KingSystem : MonoBehaviour
    {
        [SerializeField] int kingAsking;
        [SerializeField] int timesOnSea;

        [SerializeField] int nbrOfTimeBeforeNewAsk;

        #region - UNITY_FUNCTIONS -

        private void Awake()
        {
            kingAsking = PlayerPrefs.GetInt("King_Asking");
            timesOnSea = PlayerPrefs.GetInt("Times_On_Sea");
        }



        #endregion

        #region - PUBLIC_FUNCTIONS -

        public void PlayerInSea()
        {
            timesOnSea += 1;
            if(timesOnSea == nbrOfTimeBeforeNewAsk)
            {
                kingAsking += 1;
                timesOnSea = 0;

                if (kingAsking == 4)
                {
                    kingAsking = 0;
                    
                }

                PlayerPrefs.SetInt("King_Asking", kingAsking);
                PlayerPrefs.SetInt("Times_On_Sea", timesOnSea);
            }
        }

        #endregion

        #region - PRIVATE_FUNCTIONS -
        #endregion
    }
}


