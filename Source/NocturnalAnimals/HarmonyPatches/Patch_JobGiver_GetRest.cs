﻿using System;
using System.Collections.Generic;
using System.Linq;
using Verse;
using RimWorld;
using System.Reflection.Emit;
using HarmonyLib;

namespace NocturnalAnimals
{

    public static class Patch_JobGiver_GetRest
    {
        
        [HarmonyPatch(typeof(JobGiver_GetRest), nameof(JobGiver_GetRest.GetPriority))]
        public static class Patch_GetPriority
        {

            public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
            {
                #if DEBUG
                    Log.Message("Transpiler start: JobGiver_GetRest.GetPriority (2 matches)");
                #endif

                var instructionList = instructions.ToList();
                bool done = false;

                for (int i = 0; i < instructionList.Count; i++)
                {
                    var instruction = instructionList[i];

                    // Effectively turn 'if (num < 7 || num > 21)' into 'if (SleepHourFor(num, pawn))'
                    //Log.Message(instruction.operand?.GetType()?.ToStringSafe());
                    if (!done && instruction.opcode == OpCodes.Ldloc_S && ((LocalBuilder)instruction.operand).LocalIndex == 4)
                    {
                        #if DEBUG
                            Log.Message("JobGiver_GetRest.GetPriority match 1 of 2");
                        #endif

                        yield return instruction; // int num = GenLocalDate.HourOfDay(pawn)
                        yield return new CodeInstruction(OpCodes.Ldarg_1); // pawn
                        yield return new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(Patch_GetPriority), nameof(SleepHourFor))); // SleepHourFor(num, pawn)

                        int j = 1;
                        while (true)
                        {
                            if (instructionList[i + j].opcode == OpCodes.Ble_S)
                            {
                                #if DEBUG
                                    Log.Message("JobGiver_GetRest.GetPriority match 2 of 2");
                                #endif

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
                var extendedRaceProps = ExtendedRaceProperties.Get(pawn.def);

                if (extendedRaceProps != null)
                {
                    switch (extendedRaceProps.bodyClock)
                    {
                        case BodyClock.Diurnal:
                            return hour < 7 || hour > 21;

                        case BodyClock.Crepuscular:
                            return hour > 21 || hour < 2 || (hour > 10 && hour < 15);

                        case BodyClock.Nocturnal:
                            return hour > 10 && hour < 19;

                        default:
                            throw new NotImplementedException();
                    }
                }

                return hour < 7 || hour > 21;
            }

        }

    }

}
