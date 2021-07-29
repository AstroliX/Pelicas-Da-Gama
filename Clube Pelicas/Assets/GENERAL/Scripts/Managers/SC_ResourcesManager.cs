using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Pelicas
{
    public class SC_ResourcesManager : MonoBehaviour
    {
        [Header("Resources")]
        #region Rare Resources
        public int diamond;
        public int pearl;
        public int exoFruit_1;
        public int exoFruit_2;
        public int exoLeaf_1;
        public int exoLeaf_2;
        public int reputPoint;
        #endregion

        #region Resources
        public int tomato;
        public int pepper;
        public int gold;
        public float crew;
        public int nativeGift;
        public int vanillaPlant;
        public int coconut;
        public int wood;
        public int iron;
        #endregion

        [Space]
        [Header("Ãmount of resources per loot")]
        #region Amount
        //Amount of resources per loot
        public int diamondAmount;
        public int pearlAmount;
        public int exoFruit_1Amount;
        public int exoFruit_2Amount;
        public int exoLeaf_1Amount;
        public int exoLeaf_2Amount;
        public int reputPointAmount;

        public int tomatoAmount;
        public int pepperAmount;
        public int goldAmount;
        public float crewAmount;
        public int nativeGiftAmount;
        public int vanillaPlantAmount;
        public int coconutAmount;
        public int woodAmount;
        public int ironAmount;
        #endregion

        [Space]
        [Header("Limit of resources")]
        [SerializeField] int limitStack;
        [SerializeField] int limitReput;
        [SerializeField] int limitCrew;
        [SerializeField] int limitGold;

         int notFirstInstance;

        #region - UNITY_FUNCTIONS- 

        private void Awake()
        {
            /*diamond = PlayerPrefs.GetInt("diamond");
            pearl = PlayerPrefs.GetInt("pearl");
            exoFruit_1 = PlayerPrefs.GetInt("exoFruit_1");
            exoFruit_2 = PlayerPrefs.GetInt("exoFruit_2");
            exoLeaf_1 = PlayerPrefs.GetInt("exoLeaf_1");
            exoLeaf_2 = PlayerPrefs.GetInt("exoLeaf_2");
            reputPoint = PlayerPrefs.GetInt("reputPoint");

            gold = PlayerPrefs.GetInt("gold");

            tomato = PlayerPrefs.GetInt("tomato");
            pepper = PlayerPrefs.GetInt("pepper");
            crew = PlayerPrefs.GetFloat("crew");
            nativeGift = PlayerPrefs.GetInt("nativeGift");
            vanillaPlant = PlayerPrefs.GetInt("vanillaPlant");
            coconut = PlayerPrefs.GetInt("coconut");
            wood = PlayerPrefs.GetInt("wood");
            iron = PlayerPrefs.GetInt("iron");*/


            notFirstInstance = PlayerPrefs.GetInt("notFirstInstance");

            if (notFirstInstance == 0)
            {
                Debug.Log("Not First Instance is false");

            }

                  
        }

        private void Start()
        {
            if(notFirstInstance == 0)
            {
                crew = 100f;
                PlayerPrefs.SetFloat("crew", 100f);
                
                PlayerPrefs.SetInt("notFirstInstance", 1);
                notFirstInstance += 1;
                Debug.Log("First Instance");

            }
            else
            {
                Debug.Log("Not first Instance");
            }

            limitCrew = 100;
            limitGold = 999;
            limitStack = 99;
            limitReput = 999;
        }

        private void Update()
        {
            #region if resource is less than 0 then set the value to 0
            if(diamond < 0)
            {
                diamond = 0;
                PlayerPrefs.SetInt("diamond", 0);

            }

            if (pearl < 0)
            {
                pearl = 0;
                PlayerPrefs.SetInt("pearl", 0);

            }

            if (exoFruit_1 < 0)
            {
                exoFruit_1 = 0;
                PlayerPrefs.SetInt("exoFruit_1", 0);

            }

            if (exoFruit_2 < 0)
            {
                exoFruit_2 = 0;
                PlayerPrefs.SetInt("exoFruit_2", 0);

            }

            if (exoLeaf_1 < 0)
            {
                exoLeaf_1 = 0;
                PlayerPrefs.SetInt("exoLeaf_1", 0);

            }

            if (exoLeaf_2 < 0)
            {
                exoLeaf_2 = 0;
                PlayerPrefs.SetInt("exoLeaf_2", 0);

            }

            if (reputPoint < 0)
            {
                reputPoint = 0;
                PlayerPrefs.SetInt("reputPoint", 0);

            }

            if (gold < 0)
            {
                gold = 0;
                PlayerPrefs.SetInt("gold", 0);

            }

            if (tomato < 0)
            {
                tomato = 0;
                PlayerPrefs.SetInt("tomato", 0);

            }

            if (pepper < 0)
            {
                pepper = 0;
                PlayerPrefs.SetInt("pepper", 0);

            }

            if (crew < 0)
            {
                crew = 0;
                PlayerPrefs.SetFloat("crew", 0);

            }

            if (nativeGift < 0)
            {
                nativeGift = 0;
                PlayerPrefs.SetInt("nativeGift", 0);

            }

            if (vanillaPlant < 0)
            {
                vanillaPlant = 0;
                PlayerPrefs.SetInt("vanillaPlant", 0);

            }


            if (coconut < 0)
            {
                coconut = 0;
                PlayerPrefs.SetInt("coconut", 0);

            }


            if (wood < 0)
            {
                wood = 0;
                PlayerPrefs.SetInt("wood", 0);

            }



            if (iron < 0)
            {
                iron = 0;
                PlayerPrefs.SetInt("iron", 0);

            }

            #endregion

            #region if resource is more than limit then set the value to limit
            if (diamond > limitStack)
            {
                diamond = limitStack;
                PlayerPrefs.SetInt("diamond", limitStack);

            }

            if (pearl > limitStack)
            {
                pearl = limitStack;
                PlayerPrefs.SetInt("pearl", limitStack);

            }

            if (exoFruit_1 > limitStack)
            {
                exoFruit_1 = limitStack;
                PlayerPrefs.SetInt("exoFruit_1", limitStack);

            }

            if (exoFruit_2 > limitStack)
            {
                exoFruit_2 = limitStack;
                PlayerPrefs.SetInt("exoFruit_2", limitStack);

            }

            if (exoLeaf_1 > limitStack)
            {
                exoLeaf_1 = limitStack;
                PlayerPrefs.SetInt("exoLeaf_1", limitStack);

            }

            if (exoLeaf_2 > limitStack)
            {
                exoLeaf_2 = limitStack;
                PlayerPrefs.SetInt("exoLeaf_2", limitStack);

            }

            if (reputPoint > limitReput)
            {
                reputPoint = limitReput;
                PlayerPrefs.SetInt("reputPoint", limitReput);

            }

            if (gold > limitGold)
            {
                gold = limitGold;
                PlayerPrefs.SetInt("gold", limitGold);

            }

            if (tomato > limitStack)
            {
                tomato = limitStack;
                PlayerPrefs.SetInt("tomato", limitStack);

            }

            if (pepper > limitStack)
            {
                pepper = limitStack;
                PlayerPrefs.SetInt("pepper", limitStack);

            }

            if (crew > limitCrew)
            {
                crew = limitCrew;
                PlayerPrefs.SetInt("crew", limitCrew);

            }

            if (nativeGift > limitStack)
            {
                nativeGift = limitStack;
                PlayerPrefs.SetInt("nativeGift", limitStack);

            }

            if (vanillaPlant > limitStack)
            {
                vanillaPlant = limitStack;
                PlayerPrefs.SetInt("vanillaPlant", limitStack);

            }


            if (coconut > limitStack)
            {
                coconut = limitStack;
                PlayerPrefs.SetInt("coconut", limitStack);

            }


            if (wood > limitStack)
            {
                wood = limitStack;
                PlayerPrefs.SetInt("wood", limitStack);

            }



            if (iron > limitStack)
            {
                iron = limitStack;
                PlayerPrefs.SetInt("iron", limitStack);

            }

            #endregion

            #region Get Int

            diamond = PlayerPrefs.GetInt("diamond");
            pearl = PlayerPrefs.GetInt("pearl");
            exoFruit_1 = PlayerPrefs.GetInt("exoFruit_1");
            exoFruit_2 = PlayerPrefs.GetInt("exoFruit_2");
            exoLeaf_1 = PlayerPrefs.GetInt("exoLeaf_1");
            exoLeaf_2 = PlayerPrefs.GetInt("exoLeaf_2");
            reputPoint = PlayerPrefs.GetInt("reputPoint");

            gold = PlayerPrefs.GetInt("gold");

            tomato = PlayerPrefs.GetInt("tomato");
            pepper = PlayerPrefs.GetInt("pepper");
            crew = PlayerPrefs.GetFloat("crew");
            nativeGift = PlayerPrefs.GetInt("nativeGift");
            vanillaPlant = PlayerPrefs.GetInt("vanillaPlant");
            coconut = PlayerPrefs.GetInt("coconut");
            wood = PlayerPrefs.GetInt("wood");
            iron = PlayerPrefs.GetInt("iron");
            #endregion

            
        }

        #endregion


        #region - PUBLIC_FUNCTIONS -
        #endregion


        #region - PRIVATE_FUNCTIONS -
        #endregion



    }
}

