using Agate.MVC.Base;
using Agate.MVC.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ColorGlide.Boot
{
    public class SplashScreen : BaseSplash<SplashScreen>
    {
        protected override ILoad GetLoader()
        {
            return SceneLoader.Instance;
        }

        protected override IMain GetMain()
        {
            return GameMain.Instance;
        }
    }
}
