using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pelicas
{
    public class SC_AddLootToResource : MonoBehaviour
    {
        [SerializeField] bool isDiamond;
        [SerializeField] bool isPearl;
        [SerializeField] bool isExoFruit_1;
        [SerializeField] bool isExoFruit_2;
        [SerializeField] bool isExoLeaf_1;
        [SerializeField] bool isExoLeaf_2;


        [SerializeField] bool isTomato;
        [SerializeField] bool isPepper;
        [SerializeField] bool isNativeGift;
        [SerializeField] bool isVanillaPlant;
        [SerializeField] bool isCoconut;
        [SerializeField] bool isWood;
        [SerializeField] bool isIron;


        SC_ResourcesManager resource;


        private void Start()
        {
            resource = FindObjectOfType<SC_ResourcesManager>();

            if (isDiamond)
            {
                resource.diamond += resource.diamondAmount;
                PlayerPrefs.SetInt("diamond", resource.diamond);
            }

            if (isPearl)
            {
                resource.pearl += resource.pearlAmount;
                PlayerPrefs.SetInt("pearl", resource.pearl);
            }

            if (isExoFruit_1)
            {
                resource.exoFruit_1 += resource.exoFruit_1Amount;
                PlayerPrefs.SetInt("exoFruit_1", resource.exoFruit_1);
            }

            if (isExoFruit_2)
            {
                resource.exoFruit_2 += resource.exoFruit_2Amount;
                PlayerPrefs.SetInt("exoFruit_2", resource.exoFruit_2);
            }

            if (isExoLeaf_1)
            {
                resource.exoLeaf_1 += resource.exoLeaf_1Amount;
                PlayerPrefs.SetInt("exoLeaf_1", resource.exoLeaf_1);
            }


            if (isExoLeaf_2)
            {
                resource.exoLeaf_2 += resource.exoLeaf_2Amount;
                PlayerPrefs.SetInt("exoLeaf_2", resource.exoLeaf_2);
            }








            if (isTomato)
            {
                resource.tomato += resource.tomatoAmount;
                PlayerPrefs.SetInt("tomato", resource.tomato);
            }


            if (isPepper)
            {
                resource.pepper += resource.pepperAmount;
                PlayerPrefs.SetInt("pepper", resource.pepper);
            }

            if (isNativeGift)
            {
                resource.nativeGift += resource.nativeGiftAmount;
                PlayerPrefs.SetInt("nativeGift", resource.nativeGift);
            }


            if (isVanillaPlant)
            {
                resource.vanillaPlant += resource.vanillaPlantAmount;
                PlayerPrefs.SetInt("vanillaPlant", resource.vanillaPlant);
            }



            if (isCoconut)
            {
                resource.coconut += resource.coconutAmount;
                PlayerPrefs.SetInt("coconut", resource.coconut);
            }


            if (isWood)
            {
                resource.wood += resource.woodAmount;
                PlayerPrefs.SetInt("wood", resource.wood);
            }


            if (isIron)
            {
                resource.iron += resource.ironAmount;
                PlayerPrefs.SetInt("iron", resource.iron);
            }


        }
    }

}
