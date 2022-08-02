using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using DefaultNamespace;
using DefaultNamespace.GNPotionSetting;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class GeneratorManager : MonoBehaviour
{
    [SerializeField] private PotionGNSO[] potionSO;
    [SerializeField]private string[] Condition1, Condition2, Condition3;
    public GameObject[] Light;
    public Color _color;
    public Renderer[] _renderer;
    public string[] BTSelect;
    public int orderNum = 0;
    public bool isGenerate;
    public static GeneratorManager GN;
    [SerializeField] private Transform SpawnPotion;
    // Start is called before the first frame update
    void Start()
    {
        _renderer = new Renderer[Light.Length];
        for (int i = 0; i < Light.Length; i++)
        {
            _renderer[i] = Light[i].GetComponent<Renderer>();
        }
        GN = this;
        BTSelect = new string[3];
        Condition1 = new string[potionSO.Length];
        Condition2 = new string[potionSO.Length];
        Condition3 = new string[potionSO.Length];
        for (int i = 0; i < potionSO.Length;)
        {
            if (potionSO[i].condition1==PotionGNSO.PotionCondition.Red)
            {
                Condition1[i] = "Red";
            }
            if (potionSO[i].condition1==PotionGNSO.PotionCondition.Blue)
            {
                Condition1[i] = "Blue";
            }
            if (potionSO[i].condition1==PotionGNSO.PotionCondition.Yellow)
            {
                Condition1[i] = "Yellow";
            }
            //Condition2
            if (potionSO[i].condition2==PotionGNSO.PotionCondition.Red)
            {
                Condition2[i] = "Red";
            }
            if (potionSO[i].condition2==PotionGNSO.PotionCondition.Blue)
            {
                Condition2[i] = "Blue";
            }
            if (potionSO[i].condition2==PotionGNSO.PotionCondition.Yellow)
            {
                Condition2[i] = "Yellow";
            }
            //Condition3
            if (potionSO[i].condition3==PotionGNSO.PotionCondition.Red)
            {
                Condition3[i] = "Red";
            }
            if (potionSO[i].condition3==PotionGNSO.PotionCondition.Blue)
            {
                Condition3[i] = "Blue";
            }
            if (potionSO[i].condition3==PotionGNSO.PotionCondition.Yellow)
            {
                Condition3[i] = "Yellow";
            }
            i++;
        }
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
            for (int i = 0; i < potionSO.Length;)
            {
                if (BTSelect[0]==Condition1[i] & BTSelect[1]==Condition2[i] & BTSelect[2]==Condition3[i])
                {
                    Debug.Log("Is On");
                    Instantiate(potionSO[i].potion, SpawnPotion.position,SpawnPotion.rotation);
                    SetPotion();
                }
                i++;
            }
            SetPotion();
        }
    }

    public void SetPotion()
    {
        for (int i = 0; i < BTSelect.Length;)
        {
            BTSelect[i] = null;
            i++;
        }

        for (int i = 0; i < _renderer.Length;)
        {
            _color = Color.white;
            _renderer[i].material.SetColor("_Color",GN._color);
            i++;
        }

        orderNum = 0;
        isGenerate = false;
    }
}
