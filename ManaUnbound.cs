using MonoMod.Cil;
using Terraria.ModLoader;

namespace ManaUnbound
{
    public class ManaUnbound : Mod
    {
        public ManaUnbound()
        {
            Properties = new ModProperties() { Autoload = false, AutoloadBackgrounds = false, AutoloadGores = false, AutoloadSounds = false };
        }

        public override void Load()
        {
            IL.Terraria.Player.Update += Player_Update;
        }

        private void Player_Update(ILContext il)
        {
            ILCursor cursor = new ILCursor(il);

            if (!cursor.TryGotoNext(MoveType.Before,
                                    i => i.MatchLdfld("Terraria.Player", "statManaMax2"),
                                    i => i.MatchLdcI4(400)))
            {
                Logger.Fatal("Could not find instruction to patch");
                return;
            }

            cursor.Next.Next.Operand = int.MaxValue;
        }
    }
}