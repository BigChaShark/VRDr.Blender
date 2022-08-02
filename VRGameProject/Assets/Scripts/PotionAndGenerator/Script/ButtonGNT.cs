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
                    if (GN.orderNum<3)
                    {
                        GN.BTSelect[GN.orderNum] = "Red";
                        GN._color = Color.red;
                        GN._renderer[GN.orderNum].material.SetColor("_Color",GN._color);
                    }
                    GN.orderNum += 1;
                    if (GN.orderNum>3)
                    {
                        GN.SetPotion();
                    }
                    break;
                }
                case BTMenu.Yellow:
                {
                    var GN = GeneratorManager.GN;
                    if (GN.orderNum<3)
                    {
                        GN.BTSelect[GN.orderNum] = "Yellow";
                        GN._color = Color.yellow;
                        GN._renderer[GN.orderNum].material.SetColor("_Color",GN._color);
                    }
                    GN.orderNum += 1;
                    if (GN.orderNum>3)
                    {
                        GN.SetPotion();
                    }
                    break;
                }
                case BTMenu.Blue:
                {
                    var GN = GeneratorManager.GN;
                    if (GN.orderNum<3)
                    {
                        GN.BTSelect[GN.orderNum] = "Blue";
                        GN._color = Color.blue;
                        GN._renderer[GN.orderNum].material.SetColor("_Color",GN._color);
                    }
                    GN.orderNum += 1;
                    if (GN.orderNum>3)
                    {
                        GN.SetPotion();
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