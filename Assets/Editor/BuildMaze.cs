using UnityEngine;
using UnityEditor;

public class BuildMaze: ScriptableWizard
{
    [MenuItem("Wizard/Make Wall")]
    static void CreateWizard()
    {
        DisplayWizard<BuildMaze>("On Axis");
    }

    public enum Axis { X, Y, Z }

    [SerializeField]
    Vector3 pivot;

    [SerializeField]
    int length = 1;

    [SerializeField]
    Axis onAxis;

    [SerializeField]
    Transform parent;

    void OnWizardCreate()
    {
        GameObject unit = GameObject.CreatePrimitive(PrimitiveType.Cube);
        for (int i = 0; i < length; i++)
        {
            Instantiate(unit, pivot + GetDelta(i), Quaternion.identity, parent);
        }
        DestroyImmediate(unit);
    }
    Vector3 GetDelta(int delta)
    {
        switch (onAxis)
        {
            case Axis.X:
                return new Vector3(delta, 0, 0);
            case Axis.Y:
                return new Vector3(0, delta, 0);
            case Axis.Z:
                return new Vector3(0, 0, delta);
            default:
                return Vector3.zero;
        }
    }
}
