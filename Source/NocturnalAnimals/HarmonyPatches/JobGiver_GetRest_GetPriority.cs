using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using HarmonyLib;
using RimWorld;
using Verse;

namespace NocturnalAnimals;

[HarmonyPatch(typeof(JobGiver_GetRest), nameof(JobGiver_GetRest.GetPriority))]
public static class JobGiver_GetRest_GetPriority
{
    public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var instructionList = instructions.ToList();
        var done = false;

        for (var i = 0; i < instructionList.Count; i++)
        {
            var instruction = instructionList[i];

            // Effectively turn 'if (num < 7 || num > 21)' into 'if (SleepHourFor(num, pawn))'
            //Log.Message(instruction.operand?.GetType()?.ToStringSafe());
            if (!done && instruction.opcode == OpCodes.Ldloc_S &&
                ((LocalBuilder)instruction.operand).LocalIndex == 4)
            {
                yield return instruction; // int num = GenLocalDate.HourOfDay(pawn)
                yield return new CodeInstruction(OpCodes.Ldarg_1); // pawn
                yield return new CodeInstruction(OpCodes.Call,
                    AccessTools.Method(typeof(JobGiver_GetRest_GetPriority),
                        nameof(SleepHourFor))); // SleepHourFor(num, pawn)

                var j = 1;
                while (true)
                {
                    if (instructionList[i + j].opcode == OpCodes.Ble_S)
                    {
                        instruction = new CodeInstruction(OpCodes.Brfalse, instructionList[i + j].operand);
                        instructionList[i + j] = new CodeInstruction(OpCodes.Nop);
                        done = true;
                        break;
                    }

                    instructionList[i + j] = new CodeInstruction(OpCodes.Nop);
                    j++;
                }
            }

            yield return instruction;
        }
    }

    public static bool SleepHourFor(int hour, Pawn pawn)
    {
        if (!NocturnalAnimalsMod.Instance.Settings.AnimalSleepType.TryGetValue(pawn.def.defName, out var value))
        {
            return hour is < 7 or > 21;
        }

        switch ((BodyClock)value)
        {
            case BodyClock.Crepuscular:
                return hour is > 21 or < 2 or > 10 and < 15;

            case BodyClock.Nocturnal:
                return hour is > 10 and < 19;

            case BodyClock.Cathemeral:
                return Rand.Bool;

            default:
                return hour is < 7 or > 21;
        }
    }
}