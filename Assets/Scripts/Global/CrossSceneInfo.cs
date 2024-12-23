using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CrossSceneInfo
{
    private static Dictionary<int, int> collectibleDict = new Dictionary<int, int> 
    { 
        {0 , 1},
        {1 , 5},
        {2 , 9},
        {3 , 8},
        {4 , 4},
        {5 , 5},
        {6 , 1},
        {7 , 3},
        {8 , 2},
        {9 , 2}
    };


    public static float oneShotVolume
    {
        get;
        set;
    } = 1f;

    public static float musicVolume
    {
        get;
        set;
    } = 1f;

    public static bool showContinueButton = false;

    public struct LevelState 
    {
        public int index;
        public bool unlocked;
        public bool collected;
    }

    public static LevelState[] levels;

    public static void Reset()
    {
        levels = new LevelState[11];

        for(int i = 0; i < levels.Length; i++)
        {
            levels[i].index = i + 4;
            levels[i].unlocked = false;
            levels[i].collected = false;
        }
    }

    public static void CheckCollectible(int amount, int levelIndex)
    {
        if (collectibleDict[levelIndex] <= amount)
        {
            levels[levelIndex].collected = true;
        }
    }
}