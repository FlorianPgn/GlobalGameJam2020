using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{

    public static SoundEffect Instance = null;
    
    public enum Type {PLUMBER, HAMMER, DRILL, SUCCESS, BREAK, EVENT,MACHINE}
    
    [System.Serializable]
    public struct SoundLink
    {
        public Type SoundType;
        public Clip[] Clips;
    }

    public SoundLink[] Links;

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != null)
        {
            Destroy(gameObject);
        }
    }


    public Clip[] GetTypeSounds(Type[] types)
    {
        List<Clip> list = new List<Clip>();
        foreach (var t in types)
        {
            list.AddRange(GetTypeSounds(t));
        }

        return list.ToArray();
    }
    
    public Clip[] GetTypeSounds(Type type)
    {
        List<Clip> list = new List<Clip>();
        foreach (var l in Links)
        {
            if(l.SoundType == type)
                list.AddRange(l.Clips);
        }
        return list.ToArray();
    }
}
