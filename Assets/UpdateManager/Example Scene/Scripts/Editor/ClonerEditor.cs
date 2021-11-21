#if UNITY_EDITOR
using UnityEditor;

[CustomEditor(typeof(Cloner))]
public class ClonerEditor : UnityEditor.Editor {
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();

        Cloner cloner = (Cloner)target;
        cloner.cachedObject = EditorGUILayout.ObjectField(cloner.cachedObject, typeof(MonoScript), false);
        if(cloner.cachedObject != null) cloner.componentName = cloner.cachedObject.name;
    }
}
#endif