/** This is an automatically generated class by FUICodeSpawner. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET.Client.LoginPkg
{
    [EnableClass]
    public partial class FUI_InputField: GComponent
    {
        public GTextInput Input;
        public const string URL = "ui://qptb9pl1jfzh5";

        public static FUI_InputField CreateInstance()
        {
            return (FUI_InputField)UIPackage.CreateObject("LoginPkg", "InputField");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);
            Input = (GTextInput)GetChildAt(1);
        }
    }
}
