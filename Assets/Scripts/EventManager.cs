using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager {

    static TimerCountdown invokerMine;
    static TimerCountdown invokerResearch;
    static TimerCountdown invokerReactor;
    static TimerCountdown invokerTower;

    static UnityAction<bool> listenerMine;
    static UnityAction<bool> listenerResearch;
    static UnityAction<bool> listenerReactor;
    static UnityAction<bool> listenerTower;

    public static void AddMineInvoker (TimerCountdown script)
    {
        invokerMine = script;
        if (listenerMine != null)
        {
            invokerMine.AddMineListener(listenerMine);
        }
    }

    public static void AddMineListener(UnityAction<bool> handler)
    {
        listenerMine = handler;
        if (invokerMine!=null)
        {
            invokerMine.AddMineListener(listenerMine);
        }
    }

    public static void AddResearchInvoker(TimerCountdown script)
    {
        invokerResearch = script;
        if (listenerResearch != null)
        {
            invokerResearch.AddReserachListener(listenerResearch);
        }
    }

    public static void AddResearchListener(UnityAction<bool> handler)
    {
        listenerResearch = handler;
        if (invokerResearch != null)
        {
            invokerResearch.AddReserachListener(listenerResearch);
        }
    }

    public static void AddReactorInvoker(TimerCountdown script)
    {
        invokerReactor = script;
        if (listenerReactor != null)
        {
            invokerReactor.AddReactorListener(listenerReactor);
        }
    }

    public static void AddReactorListener(UnityAction<bool> handler)
    {
        listenerReactor = handler;
        if (invokerReactor != null)
        {
            invokerReactor.AddReactorListener(listenerReactor);
        }
    }

    public static void AddTowerInvoker(TimerCountdown script)
    {
        invokerTower = script;
        if (listenerTower != null)
        {
            invokerTower.AddTowerListener(listenerTower);
        }
    }

    public static void AddTowerListener(UnityAction<bool> handler)
    {
        listenerTower = handler;
        if (invokerTower != null)
        {
            invokerTower.AddTowerListener(listenerTower);
        }
    }


}
