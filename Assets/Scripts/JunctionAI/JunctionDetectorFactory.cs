using System.Collections.Generic;
using UnityEngine;

public class JunctionDetectorFactory
{
    JunctionDetectorFactory() { }

    static JunctionDetectorFactory instance;
    public static JunctionDetectorFactory Instance { get
        {
            if (instance == null)
            {
                instance = new JunctionDetectorFactory();
            }
            return instance;
        }
    }

    Dictionary<Collider, JunctionDetector> detectorDict;

    public void Register(Collider key, JunctionDetector value)
    {
        if (detectorDict == null)
        {
            detectorDict = new();
        }
        detectorDict.Add(key, value);
    }

    public JunctionDetector GetJunctionDetector(Collider junctionCollider)
    {
        return detectorDict[junctionCollider];
    }

}
