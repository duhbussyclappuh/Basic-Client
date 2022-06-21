using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using OBJ = UnityEngine.Object;

namespace Basic_Client.Functions
{
    public class InitAllFunctions
    {
        public static void Init()
        {
            Fly.StartUI();
            NoClip.StartUI();
            Esp.StartUI();
            MoreOptions();
            
        }
        public static void MoreOptions()
        {
            var moreOptions = new QMNestedButton("Menu_Dashboard", "More Options", 4, 3, "Other stuff", "More Options");  
            Speed.StartUI(moreOptions);
            Crash.StartUI(moreOptions);
            MicEarrape.MicRape(moreOptions);

        }
       
        public static void Label()
        {
            UnityEngine.GameObject[] objs = Resources.FindObjectsOfTypeAll<UnityEngine.GameObject>();
            foreach(var obj in objs)
            {
                if (obj.name.Contains("Header_QuickActions"))
                {
                    GameObject newheader = OBJ.Instantiate(obj, obj.transform.parent);
                    newheader.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Basic Client";
                    foreach(var btn in newheader.GetComponentsInChildren<UnityEngine.UI.Button>(true))
                    {

                        if(btn.gameObject.active == true)
                        {

                            btn.gameObject.active = false;
                        }
                    }
                    
                }
            }
        }
    }
}
