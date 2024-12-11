/** This is an automatically generated class by FUICodeSpawner. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET.Client.Example1Pkg
{
    [EnableClass]
    public partial class FUI_Example1Panel: GComponent
    {
        public GButton Btn1;
        public GButton BackBtn;
        public GButton Btn2;
        public const string URL = "ui://5qlx9ljjcj8s0";

        public static FUI_Example1Panel CreateInstance()
        {
            return (FUI_Example1Panel)UIPackage.CreateObject("Example1Pkg", "Example1Panel");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);
            Btn1 = (GButton)GetChildAt(1);
            BackBtn = (GButton)GetChildAt(3);
            Btn2 = (GButton)GetChildAt(4);
        }
    }
}
