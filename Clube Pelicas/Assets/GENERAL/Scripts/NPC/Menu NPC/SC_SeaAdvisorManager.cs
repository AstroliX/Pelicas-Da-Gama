using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

namespace Pelicas
{
    public class SC_SeaAdvisorManager : MonoBehaviour
    {

        [Header("Main menu")]
        [SerializeField] GameObject main_main;
        [SerializeField] GameObject areYouSure;

        [Space]
        [Header("Stock menu")]
        [SerializeField] GameObject stock_menu;
        [SerializeField] GameObject main_stock;
        [SerializeField] GameObject rare_menu;
        [SerializeField] GameObject normal_menu;

        #region Resources

        [Space]
        [Header("Amount of rare resources TXT")]
        [SerializeField] TextMeshProUGUI pearl_TXT;
        [SerializeField] TextMeshProUGUI pineapple_TXT;
        [SerializeField] TextMeshProUGUI erable_TXT;
        [SerializeField] TextMeshProUGUI banana_TXT;
        [SerializeField] TextMeshProUGUI tobacco_TXT;
        [SerializeField] TextMeshProUGUI diamond_TXT;

        [Space]
        [Header("Amount of normal resources TXT")]
        [SerializeField] TextMeshProUGUI wood_TXT;
        [SerializeField] TextMeshProUGUI iron_TXT;
        [SerializeField] TextMeshProUGUI tomato_TXT;
        [SerializeField] TextMeshProUGUI pepper_TXT;
        [SerializeField] TextMeshProUGUI vanilla_TXT;
        [SerializeField] TextMeshProUGUI native_TXT;
        [SerializeField] TextMeshProUGUI coconut_TXT;
        [SerializeField] TextMeshProUGUI gold_TXT;

        bool isAtResources;

        int pearl;
        int pineapple;
        int erable;
        int banana;
        int tobacco;
        int diamond;
        int wood;
        int iron;
        int tomato;
        int pepper;
        int vanilla;
        int native;
        int cococnut;
        int gold;

        #endregion


        SC_ResourcesManager resources;

        #region - UNITY_FUNCTIONS -

        private void Awake()
        {
            resources = FindObjectOfType<SC_ResourcesManager>();
        }

        private void Update()
        {
            #region Updating amount of resources

            if (isAtResources)
            {
                pearl = resources.pearl;
                pearl_TXT.text = "" + pearl;

                banana = resources.exoFruit_2;
                banana_TXT.text = "" + banana;

                pineapple = resources.exoFruit_1;
                pineapple_TXT.text = "" + pineapple;

                erable = resources.exoLeaf_1;
                erable_TXT.text = "" + erable;

                tobacco = resources.exoLeaf_2;
                tobacco_TXT.text = "" + tobacco;

                diamond = resources.diamond;
                diamond_TXT.text = "" + diamond;




                wood = resources.wood;
                wood_TXT.text = "" + wood;

                iron = resources.iron;
                iron_TXT.text = "" + iron;

                tomato = resources.tomato;
                tomato_TXT.text = "" + tomato;

                pepper = resources.pepper;
                pepper_TXT.text = "" + pepper;

                vanilla = resources.vanillaPlant;
                vanilla_TXT.text = "" + vanilla;

                cococnut = resources.coconut;
                coconut_TXT.text = "" + cococnut;

                native = resources.nativeGift;
                native_TXT.text = "" + native;

                gold = resources.gold;
                gold_TXT.text = "" + gold;
            }
           
            #endregion
        }

        #endregion

        #region - PUBLIC_FUNCTIONS -

        public void AreYouSure()
        {
            areYouSure.SetActive(true);
        }

        public void YesGoToSea(string levelName)
        {

            resources.crew -= 20;
            PlayerPrefs.SetFloat("crew", resources.crew);

            SceneManager.LoadScene(levelName);
        }

        public void NoIAmNotSure()
        {
            areYouSure.SetActive(false);
        }

        public void GoToStock()
        {
            main_main.SetActive(false);
            isAtResources = true;
            stock_menu.SetActive(true);
        }

        public void LeaveStock()
        {
            isAtResources = false;
            stock_menu.SetActive(false);
            main_main.SetActive(true);
        }

        public void GoToRare()
        {
            main_stock.SetActive(false);
            rare_menu.SetActive(true);
        }

        public void LeaveRare()
        {
            rare_menu.SetActive(false);
            main_stock.SetActive(true);
        }

        public void GoToNormal()
        {
            main_stock.SetActive(false);
            normal_menu.SetActive(true);
        }

        public void LeaveNormal()
        {
            normal_menu.SetActive(false);
            main_stock.SetActive(true);
        }

        public void WasNormalNowRare()
        {
            normal_menu.SetActive(false);
            rare_menu.SetActive(true);
        }

        public void WasRareNowNormal()
        {
            rare_menu.SetActive(false);
            normal_menu.SetActive(true);
        }

        #endregion

        #region - PRIVATE_FUNCTIONS -
        #endregion

    }
}

