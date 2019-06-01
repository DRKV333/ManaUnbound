using Harmony;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using Terraria;

namespace ManaUnbound
{
    [HarmonyPatch(typeof(Player), "Update")]
    [HarmonyPriority(Priority.Normal)]
    internal static class PlyerUpdatePatch
    {
        [HarmonyTranspiler]
        private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> original)
        {
            bool patchDone = false;
            bool patchNow = false;

            foreach (var item in original)
            {
                if (patchNow && item.opcode == OpCodes.Ldc_I4 && (int)item.operand == 400)
                {
                    patchDone = true;
                    yield return new CodeInstruction(OpCodes.Ldc_I4, int.MaxValue);
                }
                else
                {
                    yield return item;
                }

                patchNow = false;

                if (!patchDone && item.opcode == OpCodes.Ldfld && (FieldInfo)item.operand == typeof(Player).GetField("statManaMax2"))
                {
                    patchNow = true;
                }
            }
        }
    }
}