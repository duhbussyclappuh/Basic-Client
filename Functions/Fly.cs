using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basic_Client.PlayerManager;
using UnityEngine;

namespace Basic_Client.Functions
{
    public class Fly 
    {
        public static bool _fly = false;
        public static float DefaultSpeed = .3f;
        public static float SpeedMult = DefaultSpeed;
        public static void Functions()
        {
            if (PlayerHandler.LocalPlayer() != null)
            {
                if (_fly == true)
                {
                    FlyLogic();
                    //PlayerHandler.LocalPlayer().GetComponent<CharacterController>().enabled = false;
                    Physics.gravity = Vector3.zero;
                    
                    
                }
                if (Fly._fly == false && NoClip._NoClip == false)
                {
                    Physics.gravity = new Vector3(0, -10, 0);
                    // PlayerHandler.LocalPlayer().GetComponent<CharacterController>().enabled = true;
                }
            }
        }
        public static void R()
        {
            
            if (Input.GetKeyUp(KeyCode.W))
            {
                ControllorActive(false);
            }
           
            if (Input.GetKeyUp(KeyCode.S))
            {
                ControllorActive(false);
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                ControllorActive(false);
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                ControllorActive(false);
            }
            if (Input.GetKeyUp(KeyCode.Q))
            {
                ControllorActive(false);
            }
            if (Input.GetKeyUp(KeyCode.E))
            {
                ControllorActive(false);
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                ControllorActive(false);
            }

        }
        public static void ControllorActive(bool state)
        {
            PlayerHandler.LocalPlayer().GetComponent<CharacterController>().enabled = state;
        }
        public static void FlyLogic()
        {
            if(_fly == true && Speed.ModdedFlyNoclipSpeed == true)
            {
                DefaultSpeed = Speed.FlyNoclipspeed;
            }
            ControllorActive(false);
            ControllorActive(false);
            R();
            if (Input.GetKey(KeyCode.W))
            {
                PlayerHandler.LocalPlayer().transform.position += Camera.main.transform.forward * DefaultSpeed * SpeedMult;
                ControllorActive(true);
            }
           

            if (Input.GetKey(KeyCode.S))
            {
                PlayerHandler.LocalPlayer().transform.position += Camera.main.transform.forward * -DefaultSpeed * SpeedMult;
                ControllorActive(true);
            }
            if (Input.GetKey(KeyCode.A))
            {
                PlayerHandler.LocalPlayer().transform.position += Camera.main.transform.right * -DefaultSpeed * SpeedMult;
                ControllorActive(true);
            }
            if (Input.GetKey(KeyCode.D))
            {

                PlayerHandler.LocalPlayer().transform.position += Camera.main.transform.right * DefaultSpeed * SpeedMult;
                ControllorActive(true);
            }
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                SpeedMult = DefaultSpeed + .2f;
                ControllorActive(true);
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                SpeedMult = DefaultSpeed;
                ControllorActive(true);
            }
            if (Input.GetKey(KeyCode.E))
            {
                PlayerHandler.LocalPlayer().transform.position += Vector3.up * DefaultSpeed * SpeedMult;
                ControllorActive(true);
            }
            if (Input.GetKey(KeyCode.Q))
            {
                PlayerHandler.LocalPlayer().transform.position += Vector3.down * DefaultSpeed * SpeedMult;
                ControllorActive(true);
            }
        }
        public static void StartUI()
        {
            new QMToggleButton("Menu_Dashboard", 1, 3, "Fly", delegate
            {
                _fly = true;
            }, delegate
            {
                _fly = false;
            }, "Toggle Fly Mode", false);
        }
    }
}
