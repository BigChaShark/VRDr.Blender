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
            Generate,
            Start,
            Restart,
            Menu
        }

        public BTMenu bTmenu;
        
        public void IsHit()
        {
            switch (bTmenu)
            {
                case BTMenu.Red:
                {
                    Soundmanager.sM.pushBotton1();
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
                    Soundmanager.sM.pushBotton2();
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
                    Soundmanager.sM.pushBotton3();
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
                    Soundmanager.sM.MixPoiton();
                    GeneratorManager.GN.isGenerate = true;
                    break;
                }
                case BTMenu.Start:
                {
                    Soundmanager.sM.Gamestart();
                    GameManager.game.isClickStart = true;
                    break;
                }
                case BTMenu.Restart:
                {
                    GameManager.game.isClickReStart = true;
                    Soundmanager.sM.Onclick();
                    break;
                }
                case BTMenu.Menu:
                {
                    GameManager.game.isClickReturnMenu = true;
                    Soundmanager.sM.Onclick();
                    Soundmanager.sM.OnWait();
                    break;
                }
            }
        }
    }
}