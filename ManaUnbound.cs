using Harmony;
using Terraria.ModLoader;

namespace ManaUnbound
{
    public class ManaUnbound : Mod
    {
        private HarmonyInstance harmonyInstance;

        public ManaUnbound()
        {
            Properties = new ModProperties() { Autoload = false, AutoloadBackgrounds = false, AutoloadGores = false, AutoloadSounds = false };
        }

        public override void Load()
        {
            if (harmonyInstance == null)
                harmonyInstance = HarmonyInstance.Create(Name);

            harmonyInstance.PatchAll();
        }

        public override void Unload()
        {
            harmonyInstance.UnpatchAll();
        }
    }
}