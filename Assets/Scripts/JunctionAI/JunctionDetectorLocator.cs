using System.Collections.Generic;
using UnityEngine;

public class JunctionDetectorLocator
{
    JunctionDetectorLocator() { }

    static JunctionDetectorLocator instance;
    public static JunctionDetectorLocator Instance { get
        {
            if (instance == null)
            {
                instance = new JunctionDetectorLocator();
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
