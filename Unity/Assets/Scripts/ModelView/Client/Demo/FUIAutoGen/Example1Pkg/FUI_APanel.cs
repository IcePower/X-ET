/** This is an automatically generated class by FUICodeSpawner. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET.Client.Example1Pkg
{
    [EnableClass]
    public partial class FUI_APanel: GComponent
    {
        public GTextField Text;
        public const string URL = "ui://5qlx9ljjcj8s2";

        public static FUI_APanel CreateInstance()
        {
            return (FUI_APanel)UIPackage.CreateObject("Example1Pkg", "APanel");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);
            Text = (GTextField)GetChildAt(2);
        }
    }
}
