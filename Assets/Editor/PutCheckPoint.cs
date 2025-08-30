using UnityEngine;
using UnityEditor;

public class PutCheckPoint : EditorWindow
{
    [MenuItem("Wizard/Put Check Point")]
    static void OpenWindow()
    {
        GetWindow<PutCheckPoint>("Put It");
    }

    void OnEnable()
    {
        SceneView.duringSceneGui += Handle;
    }

    void Handle(SceneView s)
    {
        if (Event.current.type == EventType.Layout)
        {
            HandleUtility.AddDefaultControl(GUIUtility.GetControlID(FocusType.Passive));
        }

        if (Event.current.type == EventType.MouseDown)
        {
            if (Physics.Raycast(HandleUtility.GUIPointToWorldRay(Event.current.mousePosition), out RaycastHit hit))
            {
                GameObject createe = new GameObject();
                createe.transform.position = hit.point;
                createe.AddComponent<JunctionDetector>();
                Event.current.Use();
            }
        }
    }

    void OnDisable()
    {
        SceneView.duringSceneGui -= Handle;
    }
}
