using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basic_Client.PlayerManager;
using UnityEngine;

namespace Basic_Client.Functions
{
    public class NoClip
    {
        public static bool _NoClip = false;
        public static float DefaultSpeed = .3f;
        public static float SpeedMult = DefaultSpeed;
        public static void NoClipfunctions()
        {
            if (PlayerHandler.LocalPlayer() != null)
            {
                if (_NoClip == true)
                {
                    PlayerHandler.LocalPlayer().GetComponent<CharacterController>().enabled = false;
                    PlayerHandler.LocalPlayer().gameObject.AddComponent<CapsuleCollider>();
                    NoClipLogic();

                }
                else
                {
                    if (Fly._fly == false && _NoClip == false)
                    {
                        PlayerHandler.LocalPlayer().GetComponent<CharacterController>().enabled = true;
                    }
                }
            }
        }
        public static void NoClipLogic()
        {
            if(Speed.ModdedFlyNoclipSpeed == true && _NoClip == true)
            {
                DefaultSpeed = Speed.FlyNoclipspeed;

            }
           
            if (Input.GetKey(KeyCode.W))
            {
                PlayerHandler.LocalPlayer().transform.position += Camera.main.transform.forward * DefaultSpeed * SpeedMult;
            }
            if (Input.GetKey(KeyCode.S))
            {
                PlayerHandler.LocalPlayer().transform.position += Camera.main.transform.forward * -DefaultSpeed * SpeedMult;
            }
            if (Input.GetKey(KeyCode.A))
            {
                PlayerHandler.LocalPlayer().transform.position += Camera.main.transform.right * -DefaultSpeed * SpeedMult;
            }
            if (Input.GetKey(KeyCode.D))
            {

                PlayerHandler.LocalPlayer().transform.position += Camera.main.transform.right * DefaultSpeed * SpeedMult;
            }
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                SpeedMult = DefaultSpeed + .2f;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                SpeedMult = .3f;
                DefaultSpeed = .3f;
            }
            if (Input.GetKey(KeyCode.E))
            {
                PlayerHandler.LocalPlayer().transform.position += Vector3.up * DefaultSpeed * SpeedMult;
            }
            if (Input.GetKey(KeyCode.Q))
            {
                PlayerHandler.LocalPlayer().transform.position += Vector3.down * DefaultSpeed * SpeedMult;
            }
        }
        public static void StartUI()
        {
            new QMToggleButton("Menu_Dashboard", 2, 3, "No Clip", delegate
            {
                _NoClip = true;
            }, delegate
            {
                _NoClip = false;
            }, "Toggle No Clip Mode", false);
        }
    }
}
