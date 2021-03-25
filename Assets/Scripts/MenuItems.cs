using UnityEngine;
using UnityEditor;

namespace Geekbrains
{
    public class MenuItems
    {
        [MenuItem("Geekbrains/Окошечко")]
        private static void MenuOption()
        {
            EditorWindow.GetWindow(typeof(MyWindow), false, "Geekbrains");
        }
    }
}