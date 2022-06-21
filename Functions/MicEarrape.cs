using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRC.SDKBase;

namespace Basic_Client.Functions
{
    public class MicEarrape
    {
        public static bool On = false;
        public static void MicRape(QMNestedButton location)
        {
           
                new QMToggleButton(location, 3, 0, "Loud Mic", delegate
                {
                    USpeaker.field_Internal_Static_Single_1 += 200;
                }, delegate
                {
                    USpeaker.field_Internal_Static_Single_1 -= 200;
                }, "Loud mic");
            
        }
        
    }
}
