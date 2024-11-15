using System;
using System.Collections.Generic;
using UnityEngine;

public class CommandFactory
{
    private static Dictionary<Type, Queue<Command>> commandPools = new();
    private const int INITIAL_POOL_SIZE = 10;
    
    static CommandFactory()
    {
        // Pre-initialize pools for known command types
        InitializePool<MoveCmd>();
    }
    
    private static void InitializePool<T>() where T : Command, new()
    {
        var pool = new Queue<Command>();
        for (int i = 0; i < INITIAL_POOL_SIZE; i++)
        {
            pool.Enqueue(new T());
        }
        commandPools[typeof(T)] = pool;
    }

    public static T Get<T>() where T : Command, new()
    {
        var type = typeof(T);
        if (!commandPools.ContainsKey(type))
        {
            InitializePool<T>();
        }
        Debug.Log($"commandPools size {commandPools[type].Count}");

        var pool = commandPools[type];
        if (pool.Count == 0)
        {
            return new T();
        }
        
        return (T)pool.Dequeue();
    }

    public static void Return(Command command)
    {
        var type = command.GetType();
        if (!commandPools.ContainsKey(type))
        {
            commandPools[type] = new Queue<Command>();
        }
        
        commandPools[type].Enqueue(command);
    }    
}
