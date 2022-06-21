using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using O = UnityEngine.Object;
namespace Basic_Client.BasicButtons
{
    public class UserButton
    {   
        public static GameObject newUserMenuLable(string text)
        {
            GameObject newlable = O.Instantiate(LablePrefab(), LablePrefab().transform.parent);
            newlable.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = text;
            foreach (var btn in newlable.GetComponentsInChildren<UnityEngine.UI.Button>(true))
            {
                if (btn.gameObject.active == true)
                {

                    btn.gameObject.active = false;
                } 
            }
            foreach (var Tog in newlable.GetComponentsInChildren<UnityEngine.UI.Toggle>(true))
            {
                if (Tog.gameObject.active == true)
                {

                    Tog.gameObject.active = false;
                }
            }
            return newlable;


        }
        public static GameObject LablePrefab()
        {
            var ui = GameObject.Find("UserInterface");
            if(ui != null)
            {
                foreach (var button in ui.GetComponentsInChildren<UnityEngine.UI.Button>(true))
                {
                    if (button.name.Contains("Button_Clone"))
                    {
                        return button.gameObject.transform.parent.gameObject;
                    }
                }
            }
            return null;
        }
        public static GameObject ButtonParentPrefab()
        {
            var ui = GameObject.Find("UserInterface");
            if (ui != null)
            {
                foreach (var button in ui.GetComponentsInChildren<UnityEngine.UI.Button>(true))
                {
                    if (button.name.Contains("Button_FriendRequest"))
                    {
                        return button.gameObject;
                    }
                }
            }
            return null;
        }

        public static GameObject ButtonPrefab()
        {
            var ui = GameObject.Find("UserInterface");
            if (ui != null)
            {
                foreach (var button in ui.GetComponentsInChildren<UnityEngine.UI.Button>(true))
                {
                    if (button.name.Contains("Button_Screenshot"))
                    {
                        return button.gameObject;
                    }
                }
            }
            return null;
        }
        public static void create(string Text, string tooltip,Action OnClick)
        {
            GameObject NewBtn = UnityEngine.Object.Instantiate(ButtonPrefab().gameObject, ButtonParentPrefab().transform.parent);
            NewBtn.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = Text;
            NewBtn.transform.Find("Icon").GetComponent<UnityEngine.UI.Image>().enabled = false;
            NewBtn.GetComponentInChildren<TMPro.TextMeshProUGUI>().rectTransform.anchoredPosition = new Vector2(0, 50);
            NewBtn.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>().field_Public_String_0 = tooltip;
            NewBtn.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>().field_Public_String_1 = tooltip;
            if (OnClick != null)
            {
                NewBtn.GetComponent<UnityEngine.UI.Button>().onClick.AddListener
                    (UnhollowerRuntimeLib.DelegateSupport.ConvertDelegate<UnityEngine.Events.UnityAction>(OnClick));
            }
        }
        public static void createUserButton(string Text, string tooltip, Action OnClick,Transform parent)
        {
            GameObject NewBtn = UnityEngine.Object.Instantiate(ButtonPrefab().gameObject, parent);
            NewBtn.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = Text;
            NewBtn.transform.Find("Icon").GetComponent<UnityEngine.UI.Image>().enabled = false;
            NewBtn.GetComponentInChildren<TMPro.TextMeshProUGUI>().rectTransform.anchoredPosition = new Vector2(0, 50);
            NewBtn.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>().field_Public_String_0 = tooltip;
            NewBtn.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>().field_Public_String_1 = tooltip;
            if (OnClick != null)
            {
                NewBtn.GetComponent<UnityEngine.UI.Button>().onClick.AddListener
                    (UnhollowerRuntimeLib.DelegateSupport.ConvertDelegate<UnityEngine.Events.UnityAction>(OnClick));
            }
        }
    }
}
