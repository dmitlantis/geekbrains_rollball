using UnityEngine;
using UnityEditor;

namespace Geekbrains
{
    public class MyWindow : EditorWindow
    {
        private void OnGUI()
        {
            GUILayout.Label("Окошечко", EditorStyles.boldLabel);
            EditorGUILayout.TextField("TextField", "");
            EditorGUILayout.BeginToggleGroup("Дополнительные настройки",
                false);
            EditorGUILayout.Toggle("Toggle", false);
            EditorGUILayout.IntSlider("IntSlider",
                0, 1, 100);
            EditorGUILayout.Slider("Slider", 0, 10, 50);
            
            EditorGUILayout.EndToggleGroup();
        }

    }
}
