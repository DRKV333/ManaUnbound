# Mana Unbound

This a really simple mod, that allows you to have more than 600 mana, by removing the 400 cap from `statManaMax2`.

## How it works

All this mod does, is replace a single instruction in `Player.Update` using tModLoader's built-in IL patcher.

In the part that looks like this:

```
IL_2DEC: ldarg.0
IL_2DED: ldfld     int32 Terraria.Player::statManaMax2
IL_2DF2: ldc.i4    400
IL_2DF7: ble.s     IL_2E04

IL_2DF9: ldarg.0
IL_2DFA: ldc.i4    400
IL_2DFF: stfld     int32 Terraria.Player::statManaMax2
```

`ldc.i4 400` is replaced with `ldc.i4 2147483647` which is `int.MaxValue`. Since `statManaMax2` can never be greater than this value, the last three instructions are always skipped.