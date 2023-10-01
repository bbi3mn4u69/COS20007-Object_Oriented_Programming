using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using customprogram;
using SplashKitSDK;

namespace customprogram
{
    public class GoDownObjectFactory
    {
        public GodownObject Create (int id, Window win) 
        {
            if (id == 1) 
            {
                return new Heart(win);
            }
            if (id == 2)
            {
                return new Enemies(win);
            }
            if (id == 3) 
            {
                return new BigBoss(win);
            }
            if (id == 4) 
            {
                return new Shield(win);
            }
            return null;
        } 

    }
}
