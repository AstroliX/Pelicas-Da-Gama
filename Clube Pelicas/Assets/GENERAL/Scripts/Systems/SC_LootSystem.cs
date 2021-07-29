using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pelicas
{
    [System.Serializable]
    public class ItemToSpawn
    {
        public GameObject item;
        public float spawnRate;
        [HideInInspector] public float minSpawnProb, maxSpawnProb;
    }

    public class SC_LootSystem : MonoBehaviour
    {
        public ItemToSpawn[] itemToSpawn_1;
        public ItemToSpawn[] itemToSpawn_2;
        public ItemToSpawn[] itemToSpawn_3;

        [Space]
        [Header("Int needed until full")]
        [SerializeField] int nbrNeeded_1;
        [SerializeField] int nbrNeeded_2;
        [SerializeField] int nbrNeeded_3;
        int nbrOfResource;

        [Space]
        [Header("Which stock are we using ?")]
        [SerializeField] GameObject rCollector_1;
        [SerializeField] GameObject rCollector_2;
        [SerializeField] GameObject rCollector_3;

        [Space]
        public int waitBetweenResource;

        SC_LootedItemSlot lootedItem;
        SC_UpgradeSystem upgrade;

        #region - UNITY_FUNCTIONS -

        private void Awake()
        {
            

            #region Check stock
            if (PlayerPrefs.GetInt("stock") == 0)
            {
                rCollector_1.SetActive(true);
                Debug.Log("Stock is 0");
            }

            if (PlayerPrefs.GetInt("stock") == 1)
            {
                rCollector_2.SetActive(true);
                Debug.Log("Stock is 1");
            }

            if (PlayerPrefs.GetInt("stock") == 2)
            {
                rCollector_3.SetActive(true);
                Debug.Log("Stock is 2");
            }
            #endregion

            lootedItem = FindObjectOfType<SC_LootedItemSlot>();
            upgrade = FindObjectOfType<SC_UpgradeSystem>();


            

        }

        void Start()
        {
            upgrade.hull += 1;
            PlayerPrefs.GetInt("hull", upgrade.hull);


            #region Check hull
            if (PlayerPrefs.GetInt("hull") == 0)
            {
                Debug.Log("HULL IS 0 BRO");
                for (int i = 0; i < itemToSpawn_1.Length; i++)
                {

                    if (i == 0)
                    {
                        itemToSpawn_1[i].minSpawnProb = 0;
                        itemToSpawn_1[i].maxSpawnProb = itemToSpawn_1[i].spawnRate - 1;
                    }
                    else
                    {
                        itemToSpawn_1[i].minSpawnProb = itemToSpawn_1[i - 1].maxSpawnProb + 1;
                        itemToSpawn_1[i].maxSpawnProb = itemToSpawn_1[i].minSpawnProb + itemToSpawn_1[i].spawnRate - 1;
                    }
                }
                Debug.Log("Hull is 0");
            }

            if (PlayerPrefs.GetInt("hull") == 1)
            {
                Debug.Log("HULL IS 1 BRO");
                for (int i = 0; i < itemToSpawn_2.Length; i++)
                {

                    if (i == 0)
                    {
                        itemToSpawn_2[i].minSpawnProb = 0;
                        itemToSpawn_2[i].maxSpawnProb = itemToSpawn_2[i].spawnRate - 1;
                    }
                    else
                    {
                        itemToSpawn_2[i].minSpawnProb = itemToSpawn_2[i - 1].maxSpawnProb + 1;
                        itemToSpawn_2[i].maxSpawnProb = itemToSpawn_2[i].minSpawnProb + itemToSpawn_2[i].spawnRate - 1;
                    }
                }
                Debug.Log("Hull is 1");
            }


            if (PlayerPrefs.GetInt("hull") == 2)
            {
                Debug.Log("HULL IS 2 BRO");
                for (int i = 0; i < itemToSpawn_3.Length; i++)
                {

                    if (i == 0)
                    {
                        itemToSpawn_3[i].minSpawnProb = 0;
                        itemToSpawn_3[i].maxSpawnProb = itemToSpawn_3[i].spawnRate - 1;
                    }
                    else
                    {
                        itemToSpawn_3[i].minSpawnProb = itemToSpawn_3[i - 1].maxSpawnProb + 1;
                        itemToSpawn_3[i].maxSpawnProb = itemToSpawn_3[i].minSpawnProb + itemToSpawn_3[i].spawnRate - 1;
                    }
                }

                Debug.Log("Hull is 2");
            }
            #endregion


            nbrOfResource = 0;



            StartCoroutine(CollectingResources());
            
        }

        IEnumerator CollectingResources()
        {
            yield return new WaitForSeconds(waitBetweenResource);
            if (PlayerPrefs.GetInt("hull") == 0)
            {
                SpawnnerHull_1();
                nbrOfResource += 1;

            }

            if (PlayerPrefs.GetInt("hull") == 1)
            {
                SpawnnerHull_2();
                nbrOfResource += 1;
            }

            if (PlayerPrefs.GetInt("hull") == 2)
            {
                SpawnnerHull_3();
                nbrOfResource += 1;
            }
        }



        #endregion

        #region - PRIVATE_FUNCTIONS -
        void SpawnnerHull_1()
        {
            float randomNum = Random.Range(0, 100);

            for (int i = 0; i < itemToSpawn_1.Length; i++)
            {
                if (randomNum >= itemToSpawn_1[i].minSpawnProb && randomNum <= itemToSpawn_1[i].maxSpawnProb)
                {

                    if(PlayerPrefs.GetInt("stock") == 0)
                    {
                        for (int e = 0; e < lootedItem.slots_1.Length; e++)
                        {
                            if (lootedItem.isFull_1[e] == false)
                            {
                                if(nbrOfResource < nbrNeeded_1)
                                {
                                    Instantiate(itemToSpawn_1[i].item, lootedItem.slots_1[e].transform, false);
                                    Debug.Log("[Hull 0 & Stock 0] Item Spawned");
                                    lootedItem.isFull_1[e] = true;
                                    StartCoroutine(CollectingResources());
                                }
                                
                                break;
                            }
                        }
                    }


                    if (PlayerPrefs.GetInt("stock") == 1)
                    {
                        for (int e = 0; e < lootedItem.slots_2.Length; e++)
                        {
                            if (lootedItem.isFull_2[e] == false)
                            {
                                if(nbrOfResource < nbrNeeded_2)
                                {
                                    Instantiate(itemToSpawn_1[i].item, lootedItem.slots_2[e].transform, false);
                                    Debug.Log("[Hull 0 & Stock 1] Item Spawned");
                                    lootedItem.isFull_2[e] = true;
                                    StartCoroutine(CollectingResources());
                                }
                                
                                break;
                            }
                        }
                    }


                    if (PlayerPrefs.GetInt("stock") == 2)
                    {
                        for (int e = 0; e < lootedItem.slots_3.Length; e++)
                        {
                            if (lootedItem.isFull_3[e] == false)
                            {
                                if(nbrOfResource < nbrNeeded_3)
                                {
                                    Instantiate(itemToSpawn_1[i].item, lootedItem.slots_3[e].transform, false);
                                    Debug.Log("[Hull 0 & Stock 3] Item Spawned");
                                    lootedItem.isFull_3[e] = true;
                                    StartCoroutine(CollectingResources());
                                }
                                
                                break;
                            }
                        }
                    }

                }
            }
        }


        void SpawnnerHull_2()
        {
            float randomNum = Random.Range(0, 100);

            for (int i = 0; i < itemToSpawn_2.Length; i++)
            {
                if (randomNum >= itemToSpawn_2[i].minSpawnProb && randomNum <= itemToSpawn_2[i].maxSpawnProb)
                {

                    if (PlayerPrefs.GetInt("stock") == 0)
                    {
                        for (int e = 0; e < lootedItem.slots_1.Length; e++)
                        {
                            if (lootedItem.isFull_1[e] == false)
                            {
                                if(nbrOfResource < nbrNeeded_1)
                                {
                                    Instantiate(itemToSpawn_2[i].item, lootedItem.slots_1[e].transform, false);
                                    Debug.Log("[Hull 1 & Stock 0] Item Spawned");
                                    lootedItem.isFull_1[e] = true;
                                    StartCoroutine(CollectingResources());
                                }
                                
                                break;
                            }
                        }
                    }


                    if (PlayerPrefs.GetInt("stock") == 1)
                    {
                        for (int e = 0; e < lootedItem.slots_2.Length; e++)
                        {
                            if (lootedItem.isFull_2[e] == false)
                            {
                                if(nbrOfResource < nbrNeeded_2)
                                {
                                    Instantiate(itemToSpawn_2[i].item, lootedItem.slots_2[e].transform, false);
                                    Debug.Log("[Hull 1 & Stock 1] Item Spawned");
                                    lootedItem.isFull_2[e] = true;
                                    StartCoroutine(CollectingResources());
                                }
                                
                                break;
                            }
                        }
                    }


                    if (PlayerPrefs.GetInt("stock") == 2)
                    {
                        for (int e = 0; e < lootedItem.slots_3.Length; e++)
                        {
                            if (lootedItem.isFull_3[e] == false)
                            {
                                if(nbrOfResource < nbrNeeded_3)
                                {
                                    Instantiate(itemToSpawn_2[i].item, lootedItem.slots_3[e].transform, false);
                                    Debug.Log("[Hull 1 & Stock 2] Item Spawned");
                                    lootedItem.isFull_3[e] = true;
                                    StartCoroutine(CollectingResources());
                                }
                                
                                break;
                            }
                        }
                    }

                }
            }
        }


        void SpawnnerHull_3()
        {
            float randomNum = Random.Range(0, 100);

            for (int i = 0; i < itemToSpawn_3.Length; i++)
            {
                if (randomNum >= itemToSpawn_3[i].minSpawnProb && randomNum <= itemToSpawn_3[i].maxSpawnProb)
                {

                    if (PlayerPrefs.GetInt("stock") == 0)
                    {
                        for (int e = 0; e < lootedItem.slots_1.Length; e++)
                        {
                            if (lootedItem.isFull_1[e] == false)
                            {
                                if(nbrOfResource < nbrNeeded_1)
                                {
                                    Instantiate(itemToSpawn_3[i].item, lootedItem.slots_1[e].transform, false);
                                    Debug.Log("[Hull 2 & Stock 0] Item Spawned");
                                    lootedItem.isFull_1[e] = true;
                                    StartCoroutine(CollectingResources());
                                }
                                
                                break;
                            }
                        }
                    }


                    if (PlayerPrefs.GetInt("stock") == 1)
                    {
                        for (int e = 0; e < lootedItem.slots_2.Length; e++)
                        {
                            if (lootedItem.isFull_2[e] == false)
                            {
                                if(nbrOfResource < nbrNeeded_2)
                                {
                                    Instantiate(itemToSpawn_3[i].item, lootedItem.slots_2[e].transform, false);
                                    Debug.Log("[Hull 2 & Stock 1] Item Spawned");
                                    lootedItem.isFull_2[e] = true;
                                    StartCoroutine(CollectingResources());
                                }
                                
                                break;
                            }
                        }
                    }


                    if (PlayerPrefs.GetInt("stock") == 2)
                    {
                        for (int e = 0; e < lootedItem.slots_3.Length; e++)
                        {
                            if (lootedItem.isFull_3[e] == false)
                            {
                                if(nbrOfResource < nbrNeeded_3)
                                {
                                    Instantiate(itemToSpawn_3[i].item, lootedItem.slots_3[e].transform, false);
                                    Debug.Log("[Hull 2 & Stock 3] Item Spawned");
                                    lootedItem.isFull_3[e] = true;
                                    StartCoroutine(CollectingResources());
                                }
                               
                                break;
                            }
                        }
                    }

                }
            }
        }

        #endregion

    }
}

