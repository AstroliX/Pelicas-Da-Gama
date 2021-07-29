using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Pelicas
{
    public class SC_MarchandManager : MonoBehaviour
    {
        #region GameObjects Menu

        [SerializeField] GameObject mainMenu;

        [SerializeField] GameObject buyMenu;
        [SerializeField] GameObject sellMenu;

        [SerializeField] GameObject sellItemMenu;
        [SerializeField] GameObject sellRareItemMenu;

        [SerializeField] GameObject goldAmount;


        [SerializeField] GameObject fb_YouDontHaveThisItem;


        [SerializeField] GameObject fb_YouDontHaveEnoughGold;


        RectTransform rectTransform;

        #endregion

        #region Rare Items Value
        [Space]
        [Header("Rare Items Value")]
        [SerializeField] int diamondValue;
        [SerializeField] int pearlValue;
        [SerializeField] int exoFruit_1Value;
        [SerializeField] int exoFruit_2Value;
        [SerializeField] int exoLeaf_1Value;
        [SerializeField] int exoLeaf_2Value;
        [SerializeField] int reputPointValue;

        #endregion

        #region Rare Items Value for buying
        [Space]
        [Header("Rare Items Value to BUy")]
        [SerializeField] int rareValue_Buy;
        [SerializeField] int pearlValue_Buy;
        
        #endregion

        #region Items Value
        [Space]
        [Header("Items Value")]
        [SerializeField] int tomatoValue;
        [SerializeField] int pepperValue;
        [SerializeField] int nativeGiftValue;
        [SerializeField] int vanillaPlantValue;
        [SerializeField] int coconutValue;
        [SerializeField] int woodValue;
        [SerializeField] int ironValue;

        #endregion


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


        SC_ResourcesManager resource;

        #region - UNITY_FUNCTIONS -

        private void Awake()
        {
            resource = FindObjectOfType<SC_ResourcesManager>();
        }

        private void Update()
        {
            if (isAtResources)
            {
                pearl = resource.pearl;
                pearl_TXT.text = "" + pearl;

                banana = resource.exoFruit_2;
                banana_TXT.text = "" + banana;

                pineapple = resource.exoFruit_1;
                pineapple_TXT.text = "" + pineapple;

                erable = resource.exoLeaf_1;
                erable_TXT.text = "" + erable;

                tobacco = resource.exoLeaf_2;
                tobacco_TXT.text = "" + tobacco;

                diamond = resource.diamond;
                diamond_TXT.text = "" + diamond;




                wood = resource.wood;
                wood_TXT.text = "" + wood;

                iron = resource.iron;
                iron_TXT.text = "" + iron;

                tomato = resource.tomato;
                tomato_TXT.text = "" + tomato;

                pepper = resource.pepper;
                pepper_TXT.text = "" + pepper;

                vanilla = resource.vanillaPlant;
                vanilla_TXT.text = "" + vanilla;

                cococnut = resource.coconut;
                coconut_TXT.text = "" + cococnut;

                native = resource.nativeGift;
                native_TXT.text = "" + native;

                gold = resource.gold;
                gold_TXT.text = "" + gold;
            }
        }

        IEnumerator YouDontHaveThisItem()
        {
            fb_YouDontHaveThisItem.SetActive(true);
            yield return new WaitForSecondsRealtime(2);
            fb_YouDontHaveThisItem.SetActive(false);
        }

        IEnumerator YouDontHaveEnoughGold()
        {
            fb_YouDontHaveEnoughGold.SetActive(true);
            yield return new WaitForSecondsRealtime(2);
            fb_YouDontHaveEnoughGold.SetActive(false);
        }

        #endregion

        #region - PUBLIC_FUNCTIONS -

        public void GoToBuyMenu()
        {
            isAtResources = true;
            mainMenu.SetActive(false);
            buyMenu.SetActive(true);
            goldAmount.SetActive(true);
        }

        public void LeaveBuyMenu()
        {
            isAtResources = false;
            buyMenu.SetActive(false);
            goldAmount.SetActive(false);
            mainMenu.SetActive(true);
        }

        public void GoToSellMenu()
        {
            isAtResources = true;
            mainMenu.SetActive(false);
            sellMenu.SetActive(true);
            goldAmount.SetActive(true);

        }

        public void LeaveSell()
        {
            isAtResources = false;
            sellMenu.SetActive(false);
            sellItemMenu.SetActive(true);
            sellRareItemMenu.SetActive(false);
            goldAmount.SetActive(false);
            mainMenu.SetActive(true);
        }

        public void WasItemNowGoRare()
        {
            sellItemMenu.SetActive(false);
            sellRareItemMenu.SetActive(true);
        }

        public void WasRareNowGoItem()
        {
            sellRareItemMenu.SetActive(false);
            sellItemMenu.SetActive(true);
        }

         


        #region Selling Rare Items Functions

        public void SellDiamond()
        {
            if(resource.diamond != 0)
            {
                resource.diamond -= 1;

                resource.gold += diamondValue;

                PlayerPrefs.SetInt("diamond", resource.diamond);
                PlayerPrefs.SetInt("gold", resource.gold);
            }
            else
            {
                StartCoroutine(YouDontHaveThisItem());
            }
            

        }

        public void SellPearl()
        {
            if (resource.pearl != 0)
            {
                resource.pearl -= 1;

                resource.gold += pearlValue;

                PlayerPrefs.SetInt("pearl", resource.pearl);
                PlayerPrefs.SetInt("gold", resource.gold);
            }
            else
            {
                StartCoroutine(YouDontHaveThisItem());
            }


        }

        public void SellExoFruit1()
        {
            if (resource.exoFruit_1 != 0)
            {
                resource.exoFruit_1 -= 1;

                resource.gold += exoFruit_1Value;

                PlayerPrefs.SetInt("exoFruit_1", resource.exoFruit_1);
                PlayerPrefs.SetInt("gold", resource.gold);
            }
            else
            {
                StartCoroutine(YouDontHaveThisItem());
            }


        }

        public void SellExoFruit2()
        {
            if (resource.exoFruit_2 != 0)
            {
                resource.exoFruit_2 -= 1;

                resource.gold += exoFruit_1Value;

                PlayerPrefs.SetInt("exoFruit_2", resource.exoFruit_2);
                PlayerPrefs.SetInt("gold", resource.gold);
            }
            else
            {
                StartCoroutine(YouDontHaveThisItem());
            }


        }

        public void SellExoLeaf1()
        {
            if (resource.exoLeaf_1 != 0)
            {
                resource.exoLeaf_1 -= 1;

                resource.gold += exoLeaf_1Value;

                PlayerPrefs.SetInt("exoLeaf_1", resource.exoLeaf_1);
                PlayerPrefs.SetInt("gold", resource.gold);
            }
            else
            {
                StartCoroutine(YouDontHaveThisItem());
            }


        }


        public void SellExoLeaf2()
        {
            if (resource.exoLeaf_2 != 0)
            {
                resource.exoLeaf_2 -= 1;

                resource.gold += exoLeaf_2Value;

                PlayerPrefs.SetInt("exoLeaf_2", resource.exoLeaf_2);
                PlayerPrefs.SetInt("gold", resource.gold);
            }
            else
            {
                StartCoroutine(YouDontHaveThisItem());
            }


        }



        #endregion

        #region Selling Items Functions

        public void SellTomato()
        {
            if (resource.tomato != 0)
            {
                resource.tomato -= 1;

                resource.gold += tomatoValue;

                PlayerPrefs.SetInt("tomato", resource.tomato);
                PlayerPrefs.SetInt("gold", resource.gold);
            }
            else
            {
                StartCoroutine(YouDontHaveThisItem());
            }


        }

        public void SellPepper()
        {
            if (resource.pepper != 0)
            {
                resource.pepper -= 1;

                resource.gold += pepperValue;

                PlayerPrefs.SetInt("pepper", resource.pepper);
                PlayerPrefs.SetInt("gold", resource.gold);
            }
            else
            {
                StartCoroutine(YouDontHaveThisItem());
            }


        }

        public void SellNativeGift()
        {
            if (resource.nativeGift != 0)
            {
                resource.nativeGift -= 1;

                resource.gold += nativeGiftValue;

                PlayerPrefs.SetInt("nativeGift", resource.nativeGift);
                PlayerPrefs.SetInt("gold", resource.gold);
            }
            else
            {
                StartCoroutine(YouDontHaveThisItem());
            }


        }

        public void SellVanillaPlant()
        {
            if (resource.vanillaPlant != 0)
            {
                resource.vanillaPlant -= 1;

                resource.gold += vanillaPlantValue;

                PlayerPrefs.SetInt("vanillaPlant", resource.vanillaPlant);
                PlayerPrefs.SetInt("gold", resource.gold);
            }
            else
            {
                StartCoroutine(YouDontHaveThisItem());
            }


        }

        public void SellCoconut()
        {
            if (resource.coconut != 0)
            {
                resource.coconut -= 1;

                resource.gold += coconutValue;

                PlayerPrefs.SetInt("coconut", resource.coconut);
                PlayerPrefs.SetInt("gold", resource.gold);
            }
            else
            {
                StartCoroutine(YouDontHaveThisItem());
            }


        }


        public void SellWood()
        {
            if (resource.wood != 0)
            {
                resource.wood -= 1;

                resource.gold += woodValue;

                PlayerPrefs.SetInt("wood", resource.wood);
                PlayerPrefs.SetInt("gold", resource.gold);
            }
            else
            {
                StartCoroutine(YouDontHaveThisItem());
            }


        }


        public void SellIron()
        {
            if (resource.iron != 0)
            {
                resource.iron -= 1;

                resource.gold += woodValue;

                PlayerPrefs.SetInt("iron", resource.iron);
                PlayerPrefs.SetInt("gold", resource.gold);
            }
            else
            {
                StartCoroutine(YouDontHaveThisItem());
            }


        }




        #endregion

        #region Buying Rare Items

        public void BuyDiamond()
        {
            if (resource.gold >= rareValue_Buy)
            {
                resource.diamond += 1;

                resource.gold -= rareValue_Buy;

                PlayerPrefs.SetInt("diamond", resource.diamond);
                PlayerPrefs.SetInt("gold", resource.gold);
            }
            else
            {
                StartCoroutine(YouDontHaveEnoughGold());
            }


        }

        public void BuyPearl()
        {
            if (resource.gold >= pearlValue_Buy)
            {
                resource.pearl += 1;

                resource.gold -= pearlValue_Buy;

                PlayerPrefs.SetInt("pearl", resource.pearl);
                PlayerPrefs.SetInt("gold", resource.gold);
            }
            else
            {
                StartCoroutine(YouDontHaveEnoughGold());
            }


        }

        public void BuyExoFruit1()
        {
            if (resource.gold >= rareValue_Buy)
            {
                resource.exoFruit_1 += 1;

                resource.gold -= rareValue_Buy;

                PlayerPrefs.SetInt("exoFruit_1", resource.exoFruit_1);
                PlayerPrefs.SetInt("gold", resource.gold);
            }
            else
            {
                StartCoroutine(YouDontHaveEnoughGold());
            }


        }

        public void BuyExoFruit2()
        {
            if (resource.gold >= rareValue_Buy)
            {
                resource.exoFruit_2 += 1;

                resource.gold -= rareValue_Buy;

                PlayerPrefs.SetInt("exoFruit_2", resource.exoFruit_2);
                PlayerPrefs.SetInt("gold", resource.gold);
            }
            else
            {
                StartCoroutine(YouDontHaveEnoughGold());
            }


        }

        public void BuyExoLeaf_1()
        {
            if (resource.gold >= rareValue_Buy)
            {
                resource.exoLeaf_1 += 1;

                resource.gold -= rareValue_Buy;

                PlayerPrefs.SetInt("exoLeaf_1", resource.exoLeaf_1);
                PlayerPrefs.SetInt("gold", resource.gold);
            }
            else
            {
                StartCoroutine(YouDontHaveEnoughGold());
            }


        }

        public void BuyExoLeaf_2()
        {
            if (resource.gold >= rareValue_Buy)
            {
                resource.exoLeaf_2 += 1;

                resource.gold -= rareValue_Buy;

                PlayerPrefs.SetInt("exoLeaf_2", resource.exoLeaf_2);
                PlayerPrefs.SetInt("gold", resource.gold);
            }
            else
            {
                StartCoroutine(YouDontHaveEnoughGold());
            }


        }


        public void BuyReputPoint()
        {
            if (resource.gold >= reputPointValue)
            {
                resource.reputPoint += 1;

                resource.gold -= reputPointValue;

                PlayerPrefs.SetInt("reputPoint", resource.reputPoint);
                PlayerPrefs.SetInt("gold", resource.gold);
            }
            else
            {
                StartCoroutine(YouDontHaveEnoughGold());
            }


        }


        #endregion

        #region Buying Items


        public void BuyTomato()
        {
            if (resource.gold >= tomatoValue)
            {
                resource.tomato += 1;

                resource.gold -= tomatoValue;

                PlayerPrefs.SetInt("tomato", resource.tomato);
                PlayerPrefs.SetInt("gold", resource.gold);
            }
            else
            {
                StartCoroutine(YouDontHaveEnoughGold());
            }


        }

        public void BuyPepper()
        {
            if (resource.gold >= pepperValue)
            {
                resource.pepper += 1;

                resource.gold -= pepperValue;

                PlayerPrefs.SetInt("pepper", resource.pepper);
                PlayerPrefs.SetInt("gold", resource.gold);
            }
            else
            {
                StartCoroutine(YouDontHaveEnoughGold());
            }


        }


        public void BuyVanillaPlant()
        {
            if (resource.gold >= vanillaPlantValue)
            {
                resource.vanillaPlant += 1;

                resource.gold -= vanillaPlantValue;

                PlayerPrefs.SetInt("vanillaPlant", resource.vanillaPlant);
                PlayerPrefs.SetInt("gold", resource.gold);
            }
            else
            {
                StartCoroutine(YouDontHaveEnoughGold());
            }


        }

        public void BuyCoconut()
        {
            if (resource.gold >= coconutValue)
            {
                resource.coconut += 1;

                resource.gold -= coconutValue;

                PlayerPrefs.SetInt("coconut", resource.coconut);
                PlayerPrefs.SetInt("gold", resource.gold);
            }
            else
            {
                StartCoroutine(YouDontHaveEnoughGold());
            }


        }


        public void BuyWood()
        {
            if (resource.gold >= woodValue)
            {
                resource.wood += 1;

                resource.gold -= woodValue;

                PlayerPrefs.SetInt("wood", resource.wood);
                PlayerPrefs.SetInt("gold", resource.gold);
            }
            else
            {
                StartCoroutine(YouDontHaveEnoughGold());
            }


        }


        public void BuyIron()
        {
            if (resource.gold >= ironValue)
            {
                resource.iron += 1;

                resource.gold -= ironValue;

                PlayerPrefs.SetInt("iron", resource.iron);
                PlayerPrefs.SetInt("gold", resource.gold);
            }
            else
            {
                StartCoroutine(YouDontHaveEnoughGold());
            }


        }

        #endregion

        #endregion

        #region - PRIVATE_FUNCTIONS -


        #endregion
    }

}
