using Agate.MVC.Base;
using Agate.MVC.Core;
using ColorGlide.Boot;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ColorGlide.Home
{
    public class HomeLauncher : SceneLauncher<HomeLauncher, HomeView>
    {
        public override string SceneName => "Home";
        protected override IConnector[] GetSceneConnectors()
        {
            return null;
        }

        protected override IController[] GetSceneDependencies()
        {
            return null;
        }

        protected override IEnumerator InitSceneObject()
        {
            _view.SetCallbacks(OnClickPlayButton);
            yield return null;
        }

        protected override IEnumerator LaunchScene()
        {
            yield return null;
        }


        private void OnClickPlayButton()
        {
            
            SceneLoader.Instance.LoadScene("Gameplay");
        }
    }
}
