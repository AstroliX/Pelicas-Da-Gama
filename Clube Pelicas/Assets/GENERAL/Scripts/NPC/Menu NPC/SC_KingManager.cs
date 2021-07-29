using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Pelicas
{
    public class SC_KingManager : MonoBehaviour
    {
        [Header("King Main Menu")]
        [SerializeField] GameObject mainMenu;

       

        [Space]
        [SerializeField] GameObject tradingMenu;

        [Space]
        [SerializeField] GameObject askingMenu;

        [Space]
        [SerializeField] GameObject youDontHaveEnough;

        [Space]
        [Header("How many reput points is an item worth")]
        [SerializeField] int rareValue;
        [SerializeField] int normalValue;

        [Space]
        [Header("Setup Resources Asked")]
        [SerializeField] GameObject setup_1;
        [SerializeField] GameObject setup_2;
        [SerializeField] GameObject setup_3;
        [SerializeField] GameObject setup_4;


        [Space]
        [Header("Setup Resources Asked")]
        [SerializeField] GameObject setup_1_trade;
        [SerializeField] GameObject setup_2_trade;
        [SerializeField] GameObject setup_3_trade;
        [SerializeField] GameObject setup_4_trade;


        int reputP;
        int diamond;
        int pearl;
        int erable;
        int tobacco;
        int banana;
        int pineapple;


        [Space]
        [Header("TXT for amount of resource")]
        [SerializeField] TextMeshProUGUI reputAmount;
        [SerializeField] TextMeshProUGUI diamondAmount;
        [SerializeField] TextMeshProUGUI pearlAmount;
        [SerializeField] TextMeshProUGUI erableAmount;
        [SerializeField] TextMeshProUGUI bananaAmount;
        [SerializeField] TextMeshProUGUI pineappleAmount;
        [SerializeField] TextMeshProUGUI tobaccoAmount;

        
        [SerializeField] TextMeshProUGUI diamondAmount_2;
        [SerializeField] TextMeshProUGUI erableAmount_2;
        [SerializeField] TextMeshProUGUI bananaAmount_2;
        [SerializeField] TextMeshProUGUI pineappleAmount_2;
        [SerializeField] TextMeshProUGUI tobaccoAmount_2;
        [SerializeField] TextMeshProUGUI tobaccoAmount_3;

        bool isTrading;


        SC_ResourcesManager resource;

        #region - UNITY_FUNCTIONS -

        private void Awake()
        {
            resource = FindObjectOfType<SC_ResourcesManager>();
        }

        private void Update()
        {
            

            if (isTrading)
            {
                diamond = resource.diamond;
                diamondAmount.text = diamond + "";
                diamondAmount_2.text = diamond + "";

                pearl = resource.pearl;
                pearlAmount.text = pearl + "";


                erable = resource.exoLeaf_1;
                erableAmount.text = erable + "";
                erableAmount_2.text = erable + "";

                banana = resource.exoFruit_1;
                bananaAmount.text = banana + "";
                bananaAmount_2.text = banana + "";

                pineapple = resource.exoFruit_2;
                pineappleAmount.text = pineapple + "";
                pineappleAmount_2.text = pineapple + "";

                tobacco = resource.exoLeaf_2;
                tobaccoAmount.text = tobacco + "";
                tobaccoAmount_2.text = tobacco + "";
                tobaccoAmount_3.text = tobacco + "";
            }


            reputP = resource.reputPoint;
            reputAmount.text = reputP + "";

        }

        IEnumerator YouDontHaveEnough()
        {
            youDontHaveEnough.SetActive(true);
            yield return new WaitForSeconds(3);
            youDontHaveEnough.SetActive(false);
        }

        #endregion


        #region - PUBLIC_FUNCTIONS -

        public void GoAskingMenu()
        {
            mainMenu.SetActive(false);
            askingMenu.SetActive(true);

            if (PlayerPrefs.GetInt("King_Asking") == 0)
            {
                setup_1.SetActive(true);
            }

            if (PlayerPrefs.GetInt("King_Asking") == 1)
            {
                setup_2.SetActive(true);
            }

            if (PlayerPrefs.GetInt("King_Asking") == 2)
            {
                setup_3.SetActive(true);
            }

            if (PlayerPrefs.GetInt("King_Asking") == 3)
            {
                setup_4.SetActive(true);
            }
        }

        public void LeaveAskingMenu()
        {
            mainMenu.SetActive(true);
            askingMenu.SetActive(false);

            if (PlayerPrefs.GetInt("King_Asking") == 0)
            {
                setup_1.SetActive(false);
            }

            if (PlayerPrefs.GetInt("King_Asking") == 1)
            {
                setup_2.SetActive(false);
            }

            if (PlayerPrefs.GetInt("King_Asking") == 2)
            {
                setup_3.SetActive(false);
            }

            if (PlayerPrefs.GetInt("King_Asking") == 3)
            {
                setup_4.SetActive(false);
            }
        }

        public void GoToTradingMenu()
        {
            isTrading = true;
            askingMenu.SetActive(false);
            
            if (PlayerPrefs.GetInt("King_Asking") == 0)
            {
                setup_1.SetActive(false);
            }

            if (PlayerPrefs.GetInt("King_Asking") == 1)
            {
                setup_2.SetActive(false);
            }

            if (PlayerPrefs.GetInt("King_Asking") == 2)
            {
                setup_3.SetActive(false);
            }

            if (PlayerPrefs.GetInt("King_Asking") == 3)
            {
                setup_4.SetActive(false);
            }
            tradingMenu.SetActive(true);


            if (PlayerPrefs.GetInt("King_Asking") == 0)
            {
                setup_1_trade.SetActive(true);
            }

            if (PlayerPrefs.GetInt("King_Asking") == 1)
            {
                setup_2_trade.SetActive(true);
            }

            if (PlayerPrefs.GetInt("King_Asking") == 2)
            {
                setup_3_trade.SetActive(true);
            }

            if (PlayerPrefs.GetInt("King_Asking") == 3)
            {
                setup_4_trade.SetActive(true);
            }
        }

        public void LeaveTradingMenu()
        {
            isTrading = false;
            if (PlayerPrefs.GetInt("King_Asking") == 0)
            {
                setup_1_trade.SetActive(false);
            }

            if (PlayerPrefs.GetInt("King_Asking") == 1)
            {
                setup_2_trade.SetActive(false);
            }

            if (PlayerPrefs.GetInt("King_Asking") == 2)
            {
                setup_3_trade.SetActive(false);
            }

            if (PlayerPrefs.GetInt("King_Asking") == 3)
            {
                setup_4_trade.SetActive(false);
            }


            tradingMenu.SetActive(false);
            askingMenu.SetActive(true);
            if (PlayerPrefs.GetInt("King_Asking") == 0)
            {
                setup_1.SetActive(true);
            }

            if (PlayerPrefs.GetInt("King_Asking") == 1)
            {
                setup_2.SetActive(true);
            }

            if (PlayerPrefs.GetInt("King_Asking") == 2)
            {
                setup_3.SetActive(true);
            }

            if (PlayerPrefs.GetInt("King_Asking") == 3)
            {
                setup_4.SetActive(true);
            }

        }

        public void SellDiamond_1()
        {

            if(resource.diamond >= 1)
            {
                resource.diamond -= 1;
                resource.reputPoint += rareValue;

                PlayerPrefs.SetInt("diamond", resource.diamond);
                PlayerPrefs.SetInt("reputPoint", resource.reputPoint);
            }
            else
            {
                StartCoroutine(YouDontHaveEnough());
            }

        }

        public void SellPearl_1()
        {
            if(resource.pearl >= 1)
            {
                resource.pearl -= 1;
                resource.reputPoint += rareValue;

                PlayerPrefs.SetInt("pearl", resource.pearl);
                PlayerPrefs.SetInt("reputPoint", resource.reputPoint);
            }
            else
            {
                StartCoroutine(YouDontHaveEnough());
            }
            

        }

        public void SellDExoFruit1_1()
        {
            if(resource.exoFruit_1 >= 1)
            {
                resource.exoFruit_1 -= 1;
                resource.reputPoint += rareValue;

                PlayerPrefs.SetInt("exoFruit_1", resource.exoFruit_1);
                PlayerPrefs.SetInt("reputPoint", resource.reputPoint);
            }
            else
            {
                StartCoroutine(YouDontHaveEnough());
            }


        }

        public void SellDExoFruit2_1()
        {

            if(resource.exoFruit_2 >= 1)
            {
                resource.exoFruit_2 -= 1;
                resource.reputPoint += rareValue;

                PlayerPrefs.SetInt("exoFruit_2", resource.exoFruit_2);
                PlayerPrefs.SetInt("reputPoint", resource.reputPoint);
            }
            else
            {
                StartCoroutine(YouDontHaveEnough());
            }
            

        }


        public void SellDExoLeaf1_1()
        {
            if(resource.exoLeaf_1 >= 1)
            {
                resource.exoLeaf_1 -= 1;
                resource.reputPoint += rareValue;

                PlayerPrefs.SetInt("exoLeaf_1", resource.exoLeaf_1);
                PlayerPrefs.SetInt("reputPoint", resource.reputPoint);
            }
            else
            {
                StartCoroutine(YouDontHaveEnough());
            }
            

        }

        public void SellDExoLeaf2_1()
        {
            if(resource.exoLeaf_2 >= 1)
            {
                resource.exoLeaf_2 -= 1;
                resource.reputPoint += rareValue;

                PlayerPrefs.SetInt("exoLeaf_2", resource.exoLeaf_2);
                PlayerPrefs.SetInt("reputPoint", resource.reputPoint);
            }
            else
            {
                StartCoroutine(YouDontHaveEnough());
            }



        }


        public void SellDiamond_5()
        {
            if(resource.diamond >= 5)
            {
                resource.diamond -= 5;
                resource.reputPoint += rareValue * 5;

                PlayerPrefs.SetInt("diamond", resource.diamond);
                PlayerPrefs.SetInt("reputPoint", resource.reputPoint);
            }
            else
            {
                StartCoroutine(YouDontHaveEnough());
            }
            

        }

        public void SellPearl_5()
        {
            if(resource.pearl >= 5)
            {
                resource.pearl -= 5;
                resource.reputPoint += rareValue * 5;

                PlayerPrefs.SetInt("pearl", resource.pearl);
                PlayerPrefs.SetInt("reputPoint", resource.reputPoint);
            }
            else
            {
                StartCoroutine(YouDontHaveEnough());
            }
            

        }

        public void SellDExoFruit1_5()
        {
            if(resource.exoFruit_1 >= 5)
            {
                resource.exoFruit_1 -= 5;
                resource.reputPoint += rareValue * 5;

                PlayerPrefs.SetInt("exoFruit_1", resource.exoFruit_1);
                PlayerPrefs.SetInt("reputPoint", resource.reputPoint);
            }
            else
            {
                StartCoroutine(YouDontHaveEnough());
            }

           

        }

        public void SellDExoFruit2_5()
        {
            if(resource.exoFruit_2 >= 5)
            {
                resource.exoFruit_2 -= 5;
                resource.reputPoint += rareValue * 5;

                PlayerPrefs.SetInt("exoFruit_2", resource.exoFruit_2);
                PlayerPrefs.SetInt("reputPoint", resource.reputPoint);
            }
            else
            {
                StartCoroutine(YouDontHaveEnough());
            }
            

        }


        public void SellDExoLeaf1_5()
        {
            if(resource.exoLeaf_1 >= 5)
            {
                resource.exoLeaf_1 -= 5;
                resource.reputPoint += rareValue * 5;

                PlayerPrefs.SetInt("exoLeaf_1", resource.exoLeaf_1);
                PlayerPrefs.SetInt("reputPoint", resource.reputPoint);
            }
            else
            {
                StartCoroutine(YouDontHaveEnough());
            }

            

        }

        public void SellDExoLeaf2_5()
        {
            if(resource.exoLeaf_2 >= 5)
            {
                resource.exoLeaf_2 -= 5;
                resource.reputPoint += rareValue * 5;

                PlayerPrefs.SetInt("exoLeaf_2", resource.exoLeaf_2);
                PlayerPrefs.SetInt("reputPoint", resource.reputPoint);
            }
            else
            {
                StartCoroutine(YouDontHaveEnough());
            }
            

        }
        #endregion

        #region - PRIVATE_FUNCTIONS -

        

        #endregion


    }
}


