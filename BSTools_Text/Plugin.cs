using CountersPlus;
using IPA;
using IPA.Config;
using IPA.Utilities;
using UnityEngine;
using UnityEngine.SceneManagement;
using IPALogger = IPA.Logging.Logger;


namespace BSTools_Text
{
    public class Plugin : IBeatSaberPlugin
    {
        internal static Ref<PluginConfig> config;
        internal static IConfigProvider configProvider;
        public float size = 0.1f;
        public float x = -0.1f, y = 1.1f, z = 1.5f;
        public int counter = 0;
        TextHelper TheText;
       
        public void Init(IPALogger logger, [Config.Prefer("json")] IConfigProvider cfgProvider)
        {
            Logger.log = logger;
            configProvider = cfgProvider;
            Logger.log.Debug("displaying configProvider : "+ configProvider.ToString()); 

            config = cfgProvider.MakeLink<PluginConfig>((p, v) =>
            {
                if (v.Value == null || v.Value.RegenerateConfig)
                    p.Store(v.Value = new PluginConfig() { RegenerateConfig = false });
                config = v;
            });
            
        }

        public void OnApplicationStart()
        {
            Logger.log.Debug("Running the alpha mod test....");
            Logger.log.Debug("OnApplicationStart");
        }

        public void OnApplicationQuit()
        {
            Logger.log.Debug("OnApplicationQuit");
        }

        public void OnFixedUpdate()
        {

        }

        public void TextMoved()
        {
            if (TheText != null)
            {
                TheText.CANVAS_GO.SetActive(false);
                Logger.log.Debug("Nom de la scene à lequel ou est connecté  " + TheText.CANVAS_GO.name);
                TheText = new TextHelper();
                TheText.CreateTextP(new Vector3(x, y, z), "x :" + x + " | y :" + y + " | z :" + z, counter);
                TheText.COUNTERCANVAS.renderMode = RenderMode.WorldSpace;
                Logger.log.Debug("text assigné !");
                Logger.log.Debug("text mis : " + "x :" + x + " | y :" + y + " | z :" + z);

            }
            else
            {
                TheText = new TextHelper();
                TheText.CreateTextP(new Vector3(x, y, z), "x :" + x + " | y :" + y + " | z :" + z, counter);
                TheText.COUNTERCANVAS.renderMode = RenderMode.WorldSpace;
                Logger.log.Debug("text assigné !");
                Logger.log.Debug("text mis : " + "x :" + x + " | y :" + y + " | z :" + z);
            }

        }

        public void ShowText()
        {

            TheText = new TextHelper();
            TheText.CreateTextP(new Vector3(x, y, z), "x :" + x + " | y :" + y + " | z :" + z, counter);
            TheText.COUNTERCANVAS.renderMode = RenderMode.WorldSpace;
            Logger.log.Debug("text assigné !");
            Logger.log.Debug("text mis : " + "x :" + x + " | y :" + y + " | z :" + z);

        }

        //public void HideText()
        //{
        //    if (TheText != null)
        //    {
        //        TheText.CANVAS_GO.SetActive(false);
                
        //        TheText = new TextHelper();
        //    }

        //}

        //public void ChangeDisplaying()
        //{
        //    if (TheText != null)
        //    {
        //        if (TheText.COUNTERCANVAS.renderMode == RenderMode.WorldSpace)
        //        {
        //            TheText.COUNTERCANVAS.renderMode = RenderMode.ScreenSpaceOverlay;
        //        }
        //        else
        //        {
        //            TheText.COUNTERCANVAS.renderMode = RenderMode.WorldSpace;
        //        }
        //    }
        //}

        public void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.KeypadMinus))
            {
                // Moove UP object
                //open inventory

                z = z - 0.1f;
                Logger.log.Debug("PullOff depth  (value z: " + z + ")");
                TextMoved();
                //text.text = "x :" + x + " | y :" + y + " | z :" + z;
            }
            if (Input.GetKeyDown(KeyCode.KeypadPlus))
            {
                // Moove UP object
                //open inventory

                z = z + 0.1f;
                Logger.log.Debug("Add  depth (value z: " + z + ")");
                TextMoved();
                //text.text = "x :" + x + " | y :" + y + " | z :" + z;
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                // Moove UP object
                //open inventory

                y = y + 0.1f;
                Logger.log.Debug("Add UP (value y: " + y + ")");
                TextMoved();
                //text.text = "x :" + x + " | y :" + y + " | z :" + z;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                // Moove Left Object
                x = x - 0.1f;
                Logger.log.Debug("Pull off LEFT (value x: " + x + ")");
                // text.text = "x :" + x + " | y :" + y + " | z :" + z;
                TextMoved();
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                // Moove Right
                x = x + 0.1f;
                Logger.log.Debug("Add RIGHT (value x: " + x + ")");
                //text.text = "x :" + x + " | y :" + y + " | z :" + z;
                TextMoved();
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                // Moove Down

                y = y - 0.1f;
                Logger.log.Debug("Pull off DOWN (value y: " + y + ")");
                //text.text = "x :" + x + " | y :" + y + " | z :" + z;
                TextMoved();
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ShowText();
            }

        }

        public void OnActiveSceneChanged(Scene prevScene, Scene nextScene)
        {

        }

        public void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
        {

          
        }

        public void OnSceneUnloaded(Scene scene)
        {

        }


    
    }
}

