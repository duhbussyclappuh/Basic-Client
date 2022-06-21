using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using MelonLoader;
using UnityEngine;
using VRC.UI.Core;
using Basic_Client.Functions;

namespace Basic_Client
{
    public class MainClass : MelonMod
    {
       
        public override void OnUpdate()
        {
            Fly.Functions();
            NoClip.NoClipfunctions();
            Speed.ModWS();
            
        }
        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            UICleaner.start();
        }
        public override void OnApplicationStart()
        {
            UITime(delegate
            {
                InitAllFunctions.Init();
            });
        }
        public static IEnumerator WaitForUI(Action action)
        {
            while (VRCUiManager.prop_VRCUiManager_0 == null || UIManager.field_Private_Static_UIManager_0 == null ||
              GameObject.Find("UserInterface").GetComponentInChildren<VRC.UI.Elements.QuickMenu>(true) == null ||
             APIUtils.GetMenuStateControllerInstance() == null || APIUtils.GetMenuPageTemplate() == null)
            {
                yield return null;
            }

            action();
        }
        public static void UITime(Action action)
        {
            MelonCoroutines.Start(WaitForUI(action));
        }
    }
}
