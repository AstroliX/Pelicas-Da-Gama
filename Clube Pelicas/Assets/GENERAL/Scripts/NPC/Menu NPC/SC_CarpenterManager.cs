using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Pelicas
{
    public class SC_CarpenterManager : MonoBehaviour
    {

        [SerializeField] GameObject mainMenu;

        [SerializeField] GameObject whichUpgradeMenu;

        [Space]
        [Header("Upgrades Menu")]
        [SerializeField] GameObject hullUpgrade;
        [SerializeField] GameObject stockUpgrade;
        [SerializeField] GameObject quartersUpgrade;

        [Space]
        [Header("Actual Resources")]
        [SerializeField] GameObject actualResources;
        [SerializeField] TextMeshProUGUI goldAmount;
        [SerializeField] TextMeshProUGUI woodAmount;
        [SerializeField] TextMeshProUGUI ironAmount;
        int gold;
        int wood;
        int iron;

        [Space]
        [Header("3 Upgrades for each part of the ship")]
        [SerializeField] GameObject hullUpgrade_1;
        [SerializeField] GameObject hullUpgrade_2;
        [SerializeField] GameObject hullUpgrade_3;
        [SerializeField] GameObject stockUpgrade_1;
        [SerializeField] GameObject stockUpgrade_2;
        [SerializeField] GameObject stockUpgrade_3;
        [SerializeField] GameObject quartersUpgrade_1;
        [SerializeField] GameObject quartersUpgrade_2;
        [SerializeField] GameObject quartersUpgrade_3;

        [Space]
        [SerializeField] GameObject uDontHaveEnough;
        [SerializeField] GameObject uMaxeOutThisUpgrade;

        [Space]
        [Header("How much resources does the player need to upgrade")]
        [SerializeField] int goldNeeded_1;
        [SerializeField] int goldNeeded_2;
        [SerializeField] int goldNeeded_3;
        [SerializeField] int woodNeeded_1;
        [SerializeField] int woodNeeded_2;
        [SerializeField] int woodNeeded_3;
        [SerializeField] int ironNeeded_1;
        [SerializeField] int ironNeeded_2;
        [SerializeField] int ironNeeded_3;


        SC_UpgradeSystem upgrade;
        SC_ResourcesManager resource;

        #region - UNITY_FUNCTIONS -

        private void Awake()
        {
            upgrade = FindObjectOfType<SC_UpgradeSystem>();
            resource = FindObjectOfType<SC_ResourcesManager>();
        }

        private void Update()
        {
            wood = resource.wood;
            woodAmount.text = wood + "";

            gold = resource.gold;
            goldAmount.text = gold + "";

            iron = resource.iron;
            ironAmount.text = iron + "";
        }

        IEnumerator YouDontHaveEnough()
        {
            uDontHaveEnough.SetActive(true);
            yield return new WaitForSeconds(3);
            uDontHaveEnough.SetActive(false);
        }

        IEnumerator YouAlreadyMaxedOut()
        {
            uMaxeOutThisUpgrade.SetActive(true);
            yield return new WaitForSeconds(3);
            uMaxeOutThisUpgrade.SetActive(false);
        }

        #endregion


        #region - PUBLIC_FUNCTIONS -

        public void GoingToChooseUrUpgrade()
        {
            mainMenu.SetActive(false);
            whichUpgradeMenu.SetActive(true);
        }

        public void GoingBackToMainMenu()
        {
            whichUpgradeMenu.SetActive(false);
            mainMenu.SetActive(true);
        }

        public void GoingToHullUpgrade()
        {
            whichUpgradeMenu.SetActive(false);
            hullUpgrade.SetActive(true);
            actualResources.SetActive(true);

            if(PlayerPrefs.GetInt("hull") == 0)
            {
                hullUpgrade_1.SetActive(true);
            }

            if (PlayerPrefs.GetInt("hull") == 1)
            {
                hullUpgrade_2.SetActive(true);
            }

            if (PlayerPrefs.GetInt("hull") == 2)
            {
                hullUpgrade_3.SetActive(true);
            }
        }

        public void GoingToStockUpgrade()
        {
            whichUpgradeMenu.SetActive(false);
            stockUpgrade.SetActive(true);
            actualResources.SetActive(true);


            if (PlayerPrefs.GetInt("stock") == 0)
            {
                stockUpgrade_1.SetActive(true);
            }

            if (PlayerPrefs.GetInt("stock") == 1)
            {
                stockUpgrade_2.SetActive(true);
            }

            if (PlayerPrefs.GetInt("stock") == 2)
            {
                stockUpgrade_3.SetActive(true);
            }
        }


        public void GoingToQuartersUpgrade()
        {
            whichUpgradeMenu.SetActive(false);
            quartersUpgrade.SetActive(true);
            actualResources.SetActive(true);

            if (PlayerPrefs.GetInt("quarters") == 0)
            {
                quartersUpgrade_1.SetActive(true);
            }

            if (PlayerPrefs.GetInt("quarters") == 1)
            {
                quartersUpgrade_2.SetActive(true);
            }

            if (PlayerPrefs.GetInt("quarters") == 2)
            {
                quartersUpgrade_3.SetActive(true);
            }
        }

        public void LeavingHullMenu()
        {
            hullUpgrade.SetActive(false);
            actualResources.SetActive(false);
            whichUpgradeMenu.SetActive(true);

            if (PlayerPrefs.GetInt("hull") == 0)
            {
                hullUpgrade_1.SetActive(false);
            }

            if (PlayerPrefs.GetInt("hull") == 1)
            {
                hullUpgrade_2.SetActive(false);
            }

            if (PlayerPrefs.GetInt("hull") == 2)
            {
                hullUpgrade_3.SetActive(false);
            }
        }

        public void LeavingStockMenu()
        {
            stockUpgrade.SetActive(false);
            actualResources.SetActive(false);
            whichUpgradeMenu.SetActive(true);


            if (PlayerPrefs.GetInt("stock") == 0)
            {
                stockUpgrade_1.SetActive(false);
            }

            if (PlayerPrefs.GetInt("stock") == 1)
            {
                stockUpgrade_2.SetActive(false);
            }

            if (PlayerPrefs.GetInt("stock") == 2)
            {
                stockUpgrade_3.SetActive(false);
            }
        }

        public void LeavingQuartersMenu()
        {
            quartersUpgrade.SetActive(false);
            actualResources.SetActive(false);
            whichUpgradeMenu.SetActive(true);

            if (PlayerPrefs.GetInt("quarters") == 0)
            {
                quartersUpgrade_1.SetActive(false);
            }

            if (PlayerPrefs.GetInt("quarters") == 1)
            {
                quartersUpgrade_2.SetActive(false);
            }

            if (PlayerPrefs.GetInt("quarters") == 2)
            {
                quartersUpgrade_3.SetActive(false);
            }
        }


        public void UpgradeHull()
        {
            if(PlayerPrefs.GetInt("hull") == 0)
            {
                if(PlayerPrefs.GetInt("wood") >= woodNeeded_1 && PlayerPrefs.GetInt("iron") >= ironNeeded_1 && resource.gold >= goldNeeded_1)
                {
                    upgrade.hull += 1;
                    PlayerPrefs.SetInt("hull", 1);
                    hullUpgrade_1.SetActive(false);
                    hullUpgrade_2.SetActive(true);

                    resource.wood -= woodNeeded_1;
                    resource.iron -= ironNeeded_1;

                    PlayerPrefs.SetInt("wood", resource.wood);
                    PlayerPrefs.SetInt("iron", resource.iron);
                }
                else if (PlayerPrefs.GetInt("wood") < woodNeeded_1 || PlayerPrefs.GetInt("iron") < ironNeeded_1)
                {
                    StartCoroutine(YouDontHaveEnough());
                }
            }

            if (PlayerPrefs.GetInt("hull") == 1)
            {
                if (resource.wood >= woodNeeded_2 && resource.iron >= ironNeeded_2 && resource.gold >= goldNeeded_2)
                {
                    upgrade.hull += 1;
                    PlayerPrefs.SetInt("hull", 2);
                    hullUpgrade_2.SetActive(false);
                    hullUpgrade_3.SetActive(true);

                    resource.wood -= woodNeeded_2;
                    resource.iron -= ironNeeded_2;

                    PlayerPrefs.SetInt("wood", resource.wood);
                    PlayerPrefs.SetInt("iron", resource.iron);
                }
                else if (PlayerPrefs.GetInt("wood") < woodNeeded_2 || PlayerPrefs.GetInt("iron") < ironNeeded_2)
                {
                    StartCoroutine(YouDontHaveEnough());
                }
            }


            if (PlayerPrefs.GetInt("hull") == 2)
            {
                if (resource.wood >= woodNeeded_3 && resource.iron >= ironNeeded_3 && resource.gold >= goldNeeded_3)
                {
                    upgrade.hull += 1;
                    PlayerPrefs.SetInt("hull", 2);

                    resource.wood -= woodNeeded_3;
                    resource.iron -= ironNeeded_3;

                    PlayerPrefs.SetInt("wood", resource.wood);
                    PlayerPrefs.SetInt("iron", resource.iron);
                }
                else if (PlayerPrefs.GetInt("wood") < woodNeeded_3 || PlayerPrefs.GetInt("iron") < ironNeeded_3)
                {
                    StartCoroutine(YouDontHaveEnough());
                }
            }

            if(PlayerPrefs.GetInt("hull") > 2)
            {
                StartCoroutine(YouAlreadyMaxedOut());
            }
        }

        
        public void UpgradeStock()
        {
            if (PlayerPrefs.GetInt("stock") == 0)
            {
                if ((PlayerPrefs.GetInt("wood") < woodNeeded_1 || PlayerPrefs.GetInt("iron") < ironNeeded_1))
                {
                    StartCoroutine(YouDontHaveEnough());
                }
                else if (resource.wood >= woodNeeded_1 && resource.iron >= ironNeeded_1 && resource.gold >= goldNeeded_1)
                {
                    upgrade.stock += 1;
                    PlayerPrefs.SetInt("stock", 1);
                    stockUpgrade_1.SetActive(false);
                    stockUpgrade_2.SetActive(true);

                    resource.wood -= woodNeeded_1;
                    resource.iron -= ironNeeded_1;

                    PlayerPrefs.SetInt("wood", resource.wood);
                    PlayerPrefs.SetInt("iron", resource.iron);
                }
            }

            if (PlayerPrefs.GetInt("stock") == 1)
            {
                if (resource.wood >= woodNeeded_2 && resource.iron >= ironNeeded_2 && resource.gold >= goldNeeded_2)
                {
                    upgrade.stock += 1;
                    PlayerPrefs.SetInt("stock", 2);
                    stockUpgrade_2.SetActive(false);
                    stockUpgrade_3.SetActive(true);

                    resource.wood -= woodNeeded_2;
                    resource.iron -= ironNeeded_2;

                    PlayerPrefs.SetInt("wood", resource.wood);
                    PlayerPrefs.SetInt("iron", resource.iron);
                }
                else if (PlayerPrefs.GetInt("wood") < woodNeeded_2 || PlayerPrefs.GetInt("iron") < ironNeeded_2)
                {
                    StartCoroutine(YouDontHaveEnough());
                }
            }


            if (PlayerPrefs.GetInt("stock") == 2)
            {
                if (resource.wood >= woodNeeded_3 && resource.iron >= ironNeeded_3 && resource.gold >= goldNeeded_3)
                {
                    upgrade.stock += 1;
                    PlayerPrefs.SetInt("stock", 2);

                }
                else if (PlayerPrefs.GetInt("wood") < woodNeeded_3 || PlayerPrefs.GetInt("iron") < ironNeeded_3)
                {
                    StartCoroutine(YouDontHaveEnough());
                }
            }

            if (PlayerPrefs.GetInt("stock") > 2)
            {
                StartCoroutine(YouAlreadyMaxedOut());
            }
        }

        public void UpgradeQuarters()
        {
            if (PlayerPrefs.GetInt("quarters") == 0)
            {
                if (resource.wood >= woodNeeded_1 && resource.iron >= ironNeeded_1 && resource.gold >= goldNeeded_1)
                {
                    upgrade.quarters += 1;
                    PlayerPrefs.SetInt("quarters", 1);
                    quartersUpgrade_1.SetActive(false);
                    quartersUpgrade_2.SetActive(true);

                    resource.wood -= woodNeeded_1;
                    resource.iron -= ironNeeded_1;

                    PlayerPrefs.SetInt("wood", resource.wood);
                    PlayerPrefs.SetInt("iron", resource.iron);
                }
                else if (PlayerPrefs.GetInt("wood") < woodNeeded_1 || PlayerPrefs.GetInt("iron") < ironNeeded_1)
                {
                    StartCoroutine(YouDontHaveEnough());
                }
            }

            if (PlayerPrefs.GetInt("quarters") == 1)
            {
                if (resource.wood >= woodNeeded_2 && resource.iron >= ironNeeded_2 && resource.gold >= goldNeeded_2)
                {
                    upgrade.quarters += 1;
                    PlayerPrefs.SetInt("quarters", 2);
                    quartersUpgrade_2.SetActive(false);
                    quartersUpgrade_3.SetActive(true);

                    resource.wood -= woodNeeded_2;
                    resource.iron -= ironNeeded_2;

                    PlayerPrefs.SetInt("wood", resource.wood);
                    PlayerPrefs.SetInt("iron", resource.iron);
                }
                else if (PlayerPrefs.GetInt("wood") < woodNeeded_2 || PlayerPrefs.GetInt("iron") < ironNeeded_2)
                {
                    StartCoroutine(YouDontHaveEnough());
                }
            }


            if (PlayerPrefs.GetInt("quarters") == 2)
            {
                if (resource.wood >= woodNeeded_3 && resource.iron >= ironNeeded_3 && resource.gold >= goldNeeded_3)
                {
                    upgrade.quarters += 1;
                    PlayerPrefs.SetInt("quarters", 2);

                    resource.wood -= woodNeeded_3;
                    resource.iron -= ironNeeded_3;

                    PlayerPrefs.SetInt("wood", resource.wood);
                    PlayerPrefs.SetInt("iron", resource.iron);
                }
                else if (PlayerPrefs.GetInt("wood") < woodNeeded_3 || PlayerPrefs.GetInt("iron") < ironNeeded_3)
                {
                    StartCoroutine(YouDontHaveEnough());
                }
            }

            if (PlayerPrefs.GetInt("quarters") > 2)
            {
                StartCoroutine(YouAlreadyMaxedOut());
            }
        }

        #endregion


        #region - PRIVATE_FUNCTIONS -
        #endregion
    }
}

