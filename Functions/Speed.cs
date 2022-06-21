using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Basic_Client.PlayerManager;

namespace Basic_Client.Functions
{
    public class Speed
    {
        public static bool ModedWalkSpeed = false;
        public static bool ModdedFlyNoclipSpeed = false;
        
        public static float WalkSpeed = .3f;
        
        public static float sprintSpeed = WalkSpeed;
        public static float FlyNoclipspeed = .3f;
        public static float fastNFS = FlyNoclipspeed;
        public static void StartUI(QMNestedButton Location)
        {
            var speedmen = new QMNestedButton(Location, "Speed Options", 1, 0, "Adjust Speed", "Speed Options");
            RunSpeed(speedmen);
            FlyNoClipSpeed(speedmen);
        }
        public static void RunSpeed(QMNestedButton location)
        {
            new QMToggleButton(location, 1, 0, "Mod Walk Speed", delegate
            {
                ModedWalkSpeed = true;
            }, delegate
            {
                ModedWalkSpeed = false;
                WalkSpeed = .3f;
            }, "Mess with walkSpeed");
            new QMSingleButton(location, 2, 0, "Up", delegate
            {
                WalkSpeed += .5f;
            }, "Turn up walk speed",Color.black,true);
            new QMSingleButton(location, 2, .5f, "Down", delegate
            {
                WalkSpeed -= .5f;
                
            }, "Turn Down walk speed", Color.black, true);
            new QMSingleButton(location, 3, 0, "Reset", delegate
            {
                WalkSpeed = .3f;
            }, "reset Walk speed clip speed", Color.green, false);


        }
        public static void ModWS()
        {
            if(ModedWalkSpeed == true && Fly._fly == false)
            {
                if (PlayerHandler.LocalPlayer() != null)
                {
                    if (Input.GetKey(KeyCode.W))
                    {
                        PlayerHandler.LocalPlayer().transform.position += PlayerHandler.LocalPlayer().transform.forward * WalkSpeed * sprintSpeed;
                    }
                    if (Input.GetKey(KeyCode.S))
                    {
                        PlayerHandler.LocalPlayer().transform.position += PlayerHandler.LocalPlayer().transform.forward * -WalkSpeed * sprintSpeed;
                    }
                    if (Input.GetKey(KeyCode.A))
                    {
                        PlayerHandler.LocalPlayer().transform.position += PlayerHandler.LocalPlayer().transform.right * -WalkSpeed*sprintSpeed;
                    }
                    if (Input.GetKey(KeyCode.D))
                    {
                        PlayerHandler.LocalPlayer().transform.position += PlayerHandler.LocalPlayer().transform.right * WalkSpeed*sprintSpeed;
                    }
                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        sprintSpeed = WalkSpeed +.3f;
                    }
                    if (Input.GetKeyUp(KeyCode.LeftShift))
                    {
                        sprintSpeed = WalkSpeed;
                    }
                }
            }
        }
       
        public static void FlyNoClipSpeed(QMNestedButton location)
        {
            new QMToggleButton(location, 1, 1, "Fly/Noclip Speed", delegate
            {
                ModdedFlyNoclipSpeed = true;
            }, delegate
            {
                ModdedFlyNoclipSpeed = false;
                FlyNoclipspeed = .3f;
            }, "Mess with walkSpeed");
            new QMSingleButton(location, 2, 1, "Up", delegate
            {
                FlyNoclipspeed += .5f;
            }, "Turn up Fly/Noclip speed", Color.black, true);
            new QMSingleButton(location, 2, 1.5f, "Down", delegate
            {
                FlyNoclipspeed -= .5f;
            }, "Turn Down Fly/Noclip speed", Color.black, true);
            new QMSingleButton(location, 3, 1, "Reset", delegate
            {
                FlyNoclipspeed = .3f;
            }, "reset Fly/No clip speed", Color.green,false);

        }
    }
}
