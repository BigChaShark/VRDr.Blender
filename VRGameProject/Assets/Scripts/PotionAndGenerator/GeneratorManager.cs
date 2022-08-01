using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class GeneratorManager : MonoBehaviour
{
    public string[] BTSelect;
    public int orderNum = 0;
    public bool isGenerate;
    public static GeneratorManager GN; 
    [SerializeField] private GameObject PotionTest;
    [SerializeField] private GameObject PotionTest2;
    [SerializeField] private Transform SpawnPotion;
    // Start is called before the first frame update
    void Start()
    {
        GN = this;
        BTSelect = new string[3];
    }

    // Update is called once per frame
    void Update()
    {
        Potion();
    }

    void Potion()
    {
        if (isGenerate)
        {
            if (BTSelect[0]=="Red" & BTSelect[1]=="Red" & BTSelect[2]=="Red")
            {
                Instantiate(PotionTest, SpawnPotion.position,SpawnPotion.rotation);
                SetPotion();
            }
            if (BTSelect[0]=="Yellow" & BTSelect[1]=="Red" & BTSelect[2]=="Blue")
            {
                Instantiate(PotionTest2, SpawnPotion.position,SpawnPotion.rotation);
                SetPotion();
            }
            else
            {
                SetPotion();
            }
        }
        
    }

    void SetPotion()
    {
        for (int i = 0; i < BTSelect.Length;)
        {
            BTSelect[i] = null;
            i++;
        }

        orderNum = 0;
        isGenerate = false;
    }
}
