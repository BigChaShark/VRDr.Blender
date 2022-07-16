using UnityEngine;

namespace DefaultNamespace
{
    public class ButtonGNT : MonoBehaviour,IHit
    {
        public enum BTMenu
        {
            Red,
            Blue,
            Yellow,
            Generate
        }

        public BTMenu bTmenu;
        
        public void IsHit()
        {
            switch (bTmenu)
            {
                case BTMenu.Red:
                {
                    var GN = GeneratorManager.GN;
                    if (GN.orderNum<=3)
                    {
                        GN.BTSelect[GN.orderNum] = "Red";
                        GN.orderNum += 1;
                    }
                    break;
                }
                case BTMenu.Yellow:
                {
                    var GN = GeneratorManager.GN;
                    if (GN.orderNum<=3)
                    {
                        GN.BTSelect[GN.orderNum] = "Yellow";
                        GN.orderNum += 1;
                    }
                    break;
                }
                case BTMenu.Blue:
                {
                    var GN = GeneratorManager.GN;
                    if (GN.orderNum<=3)
                    {
                        GN.BTSelect[GN.orderNum] = "Blue";
                        GN.orderNum += 1;
                    }
                    break;
                }
                case BTMenu.Generate:
                {
                    GeneratorManager.GN.isGenerate = true;
                    break;
                }
            }
        }
    }
}