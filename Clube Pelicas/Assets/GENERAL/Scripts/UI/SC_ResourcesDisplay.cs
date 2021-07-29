using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace Pelicas
{
    public class SC_ResourcesDisplay : MonoBehaviour
    {
        #region Resources

        [Space]
        [Header("Amount of rare resources TXT")]
        [SerializeField] TextMeshProUGUI pearl_TXT;
        [SerializeField] TextMeshProUGUI pineapple_TXT;
        [SerializeField] TextMeshProUGUI erable_TXT;
        [SerializeField] TextMeshProUGUI banana_TXT;
        [SerializeField] TextMeshProUGUI tobacco_TXT;
        [SerializeField] TextMeshProUGUI diamond_TXT;
        [SerializeField] TextMeshProUGUI reput_TXT;

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
        int reput;

        #endregion

        SC_ResourcesManager resource;

        #region - UNITY_FUNCTIONS -


        private void Awake()
        {
            resource = FindObjectOfType<SC_ResourcesManager>();
        }

        private void Update()
        {
            pearl = resource.pearl;
            pearl_TXT.text = "x" + pearl;

            banana = resource.exoFruit_2;
            banana_TXT.text = "x" + banana;

            pineapple = resource.exoFruit_1;
            pineapple_TXT.text = "x" + pineapple;

            erable = resource.exoLeaf_1;
            erable_TXT.text = "x" + erable;

            tobacco = resource.exoLeaf_2;
            tobacco_TXT.text = "x" + tobacco;

            diamond = resource.diamond;
            diamond_TXT.text = "x" + diamond;




            wood = resource.wood;
            wood_TXT.text = "x" + wood;

            iron = resource.iron;
            iron_TXT.text = "x" + iron;

            tomato = resource.tomato;
            tomato_TXT.text = "x" + tomato;

            pepper = resource.pepper;
            pepper_TXT.text = "x" + pepper;

            vanilla = resource.vanillaPlant;
            vanilla_TXT.text = "x" + vanilla;

            cococnut = resource.coconut;
            coconut_TXT.text = "x" + cococnut;

            native = resource.nativeGift;
            native_TXT.text = "x" + native;

            gold = resource.gold;
            gold_TXT.text = "x" + gold;

            reput = resource.reputPoint;
            reput_TXT.text = "x" + gold;
        }
        #endregion

        #region - PUBLIC_FUNCTIONS -
        #endregion

        #region - PRIVATE_FUNCTIONS -
        #endregion
    }
}

