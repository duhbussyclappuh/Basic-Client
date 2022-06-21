using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using VRC.UI;

namespace Basic_Client.PlayerManager
{
    public class PlayerHandler
    {
        private static UIManagerImpl GetUIManagerImpl() { return UIManagerImpl.prop_UIManagerImpl_0; }
        private static MenuController GetMenuController() { return GetUIManagerImpl().field_Public_MenuController_0; }

        public static VRCPlayer SelectedPlayer()
        {
            return GetMenuController().activePlayer;
        }
        public static VRCPlayer LocalPlayer()
        {
            var player = VRCPlayer.field_Internal_Static_VRCPlayer_0;
            if(player != null)
            {
                return VRCPlayer.field_Internal_Static_VRCPlayer_0;
            }
            return null;
        }
    }
}
