/** This is an automatically generated class by FUICodeSpawner. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET.Client.ExampleListPkg
{
    [EnableClass]
    public partial class FUI_ExampleListPanel: GComponent
    {
        public GList List;
        public GButton BackBtn;
        public const string URL = "ui://73sapar1laxn0";

        public static FUI_ExampleListPanel CreateInstance()
        {
            return (FUI_ExampleListPanel)UIPackage.CreateObject("ExampleListPkg", "ExampleListPanel");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);
            List = (GList)GetChildAt(0);
            BackBtn = (GButton)GetChildAt(1);
        }
    }
}
