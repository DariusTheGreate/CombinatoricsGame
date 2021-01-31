using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RandomTransitionContainer
{
    public static List<int> passed_scenes = new List<int>();
    public static List<int> available_scenes = new List<int>();
    public static bool randomTransition = false;
    public static bool isRandomTypeAvailable = false;
    public static bool lastLevelWasStart = false;
    public static int LevelRecord = 0;
    public static int LivesCount = 3;
    public static int sceneCount = 10;
}
