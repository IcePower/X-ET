/** This is an automatically generated class by FUICodeSpawner. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET.Client.LoginPkg
{
    [EnableClass]
    public partial class FUI_LoginPanel: GComponent
    {
        public ET.Client.LoginPkg.FUI_LoginBtn LoginBtn;
        public ET.Client.LoginPkg.FUI_InputField AccountInput;
        public ET.Client.LoginPkg.FUI_InputField PasswordInput;
        public const string URL = "ui://qptb9pl1ddj20";

        public static FUI_LoginPanel CreateInstance()
        {
            return (FUI_LoginPanel)UIPackage.CreateObject("LoginPkg", "LoginPanel");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);
            LoginBtn = (ET.Client.LoginPkg.FUI_LoginBtn)GetChildAt(0);
            AccountInput = (ET.Client.LoginPkg.FUI_InputField)GetChildAt(1);
            PasswordInput = (ET.Client.LoginPkg.FUI_InputField)GetChildAt(2);
        }
    }
}
