using UnityEngine;

namespace DefaultNamespace.GNPotionSetting
{
    [CreateAssetMenu (fileName = "Potion",menuName = "GNPotionSetting",order = 1)]
    public class PotionGNSO:ScriptableObject
    {
        public enum PotionCondition
        {
            Red,Blue,Yellow
        }
        public GameObject potion;
        public PotionCondition condition1;
        public PotionCondition condition2;
        public PotionCondition condition3;
        //private string condition1, condition2, condition3;
    }
}