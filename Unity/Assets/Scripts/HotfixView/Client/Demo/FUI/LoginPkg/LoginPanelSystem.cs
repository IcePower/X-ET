using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof(LoginPanel))]
    [FriendOf(typeof(LoginPanel))]
    public static partial class LoginPanelSystem
    {
        [EntitySystem]
        private static void Awake(this LoginPanel self)
        {
            self.FUILoginPanel.LoginBtn.AddListner(self.OnLogin);
        }

        [EntitySystem]
        private static void Show(this LoginPanel self)
        {
        }
        
        private static void OnLogin(this LoginPanel self)
        {
            LoginHelper.Login(
                self.Root(), 
                self.FUILoginPanel.AccountInput.Input.text,
                self.FUILoginPanel.PasswordInput.Input.text).NoContext();
        }
    }
}