using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Basic_Client.Functions
{
    public class Esp
    {
        public static void StartUI()
        {
            new QMToggleButton("Menu_Dashboard", 3, 3, "Esp", delegate
            {
                GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
                for(int i = 0; i <players.Length; i++)
                {
                    if (players[i].transform.Find("SelectRegion"))
                    {
                        
                        HighlightsFX.prop_HighlightsFX_0.Method_Public_Void_Renderer_Boolean_0(players[i].transform.Find("SelectRegion").GetComponent<Renderer>(),true);
                    }
                }
            }, delegate
            {
                GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
                for (int i = 0; i < players.Length; i++)
                {
                    if (players[i].transform.Find("SelectRegion"))
                    {

                        HighlightsFX.prop_HighlightsFX_0.Method_Public_Void_Renderer_Boolean_0(players[i].transform.Find("SelectRegion").GetComponent<Renderer>(), false);
                    }
                }
            }, "See people", false);
        }
    }
}
