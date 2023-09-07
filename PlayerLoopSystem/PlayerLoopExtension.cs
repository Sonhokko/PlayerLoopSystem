﻿using System;
using UnityEngine.LowLevel;


public static class PlayerLoopExtension
{
    public delegate void ModifyLoop(ref PlayerLoopSystem playerLoopSystem);

    public static void ModifyCurrentLoop(ModifyLoop modifyPlayerLoop)
    {
        var currentLoop = PlayerLoop.GetCurrentPlayerLoop();
        modifyPlayerLoop(ref currentLoop);
        PlayerLoop.SetPlayerLoop(currentLoop);
    }

    public static ref PlayerLoopSystem GetSystem<TSystem>(ref this PlayerLoopSystem loop)
    {
        var type = typeof(TSystem);
        for (var index = 0; index < loop.subSystemList.Length; index++)
        {
            ref var playerLoopSystem = ref loop.subSystemList[index];
            if (playerLoopSystem.type == type)
                return ref playerLoopSystem;
        }
        throw new Exception("System not found");
    }

    public static void AddSystem<TSystem>(ref this PlayerLoopSystem loop, PlayerLoopSystem.UpdateFunction action)
    {
        var type = typeof(TSystem);
        loop.subSystemList = loop.subSystemList.Add(new PlayerLoopSystem()
        {
            type = type,
            updateDelegate = action
        });
    }

    public static void RemoveSystem<TSystem>(ref this PlayerLoopSystem loop, bool recursive = true)
    {
        if (loop.subSystemList == null) return;
        var type = typeof(TSystem);
        for (var index = loop.subSystemList.Length - 1; index >= 0; index--)
        {
            ref var playerLoopSystem = ref loop.subSystemList[index];
            
            if (playerLoopSystem.type == type)
                loop.subSystemList = loop.subSystemList.RemoveAt(index);
            else if (recursive)
                playerLoopSystem.RemoveSystem<TSystem>(true);
        }
    }

    public static T[] RemoveAt<T>(this T[] array, int index)
    {
        if (array == null || index < 0) return array;

        var newArray = new T[array.Length - 1];
        if (index > 0)
            Array.Copy(array, 0, 
                newArray, 0, 
                index);
        if (index < newArray.Length)
            Array.Copy(array, 
                index + 1, 
                newArray, 
                index, 
                array.Length - (index + 1));

        return newArray;
    }
    public static T[] Add<T>(this T[] array, T value)
    {
        if (array == null) 
            array = new T[1];
        else 
            Array.Resize(ref array, array.Length + 1);
        array[array.Length - 1] = value;
        return array;
    }
}
