using UnityEditor;
using UnityEngine;

namespace Geekbrains
{
    [CustomEditor(typeof(TestBehaviour))]
    public class TestBehaviourEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            TestBehaviour testTarget = (TestBehaviour)target;
         
            testTarget.count = EditorGUILayout.IntSlider(testTarget.count, 10, 50);
        }
    }
}