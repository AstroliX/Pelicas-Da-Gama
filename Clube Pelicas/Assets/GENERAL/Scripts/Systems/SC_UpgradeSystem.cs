using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pelicas
{
    public class SC_UpgradeSystem : MonoBehaviour
    {
        public int stock;
        public int quarters;
        public int hull;

        #region - UNITY_FUNCTIONS -

        private void Awake()
        {
            stock = PlayerPrefs.GetInt("stock");
            quarters = PlayerPrefs.GetInt("quarters");
            hull = PlayerPrefs.GetInt("hull");
        }



        #endregion


        #region - PUBLIC_FUNCTIONS -
        #endregion

        #region - PRIVATE_FUNCTIONS -
        #endregion
    }

}
