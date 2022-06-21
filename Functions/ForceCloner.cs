using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Basic_Client.BasicButtons;
using VRC;
using VRC.UI;
using VRC.Core;
using VRC.SDKBase;

namespace Basic_Client.Functions
{
    public class ForceCloner 
    {
        public static SimpleAvatarPedestal avatar;
        public static void Start()
        {
            
            UserButton.create("Force Clone Avatar", "Clone his/her avatar even if the government doesn't want you to", delegate
            {
                try
                {
                    var id = GameObject.Find("/_Application").transform.Find("UIManager/SelectedUserManager").gameObject.GetComponent<VRC.DataModel.UserSelectionManager>().field_Private_APIUser_1.id;
                    foreach (VRC.Player player1 in VRC.PlayerManager.prop_PlayerManager_0.field_Private_List_1_Player_0.ToArray())
                    {
                        if (player1.field_Private_APIUser_0.id == id)
                        {
                            PlayerManager.PlayerHandler.SelectedPlayer().GetComponent<VRC.Player>().field_Private_APIUser_0.id = player1.ToString();
                        }

                    }
                    var aviid = PlayerManager.PlayerHandler.SelectedPlayer().GetComponent<VRCPlayer>().field_Private_ApiAvatar_0.id;
                    PageAvatar component = GameObject.Find("Screens").transform.Find("Avatar").GetComponent<PageAvatar>();
                    component.field_Public_SimpleAvatarPedestal_0.field_Internal_ApiAvatar_0 = new ApiAvatar
                    {
                        id = aviid
                    };
                    component.ChangeToSelectedAvatar();
                }

                catch
                {
                    MelonLoader.MelonLogger.Msg("Something went wrong while force cloning");
                }

            });
        }
    }
}
