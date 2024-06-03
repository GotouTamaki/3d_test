using UnityEngine;
using UnityEditor;

/// <summary>decimal型をInspectorに表示するためのエディタ拡張</summary>
[CustomPropertyDrawer(typeof(DecimalWrapper))]
public class SerializableDecimalDrawer : PropertyDrawer
{
    //　参考URL : https://discussions.unity.com/t/how-to-make-decimal-variables-visible-in-inspector/119343

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var obj = property.serializedObject.targetObject;
        var inst = (DecimalWrapper)this.fieldInfo.GetValue(obj);
        var fieldRect = EditorGUI.PrefixLabel(position, label);
        string text = GUI.TextField(fieldRect, inst.ToString());

        if (GUI.changed)
        {
            decimal val;

            if (decimal.TryParse(text, out val))
            {
                inst.Value = val;
                property.serializedObject.ApplyModifiedProperties();
                AssetDatabase.SaveAssets();
            }
        }
    }
}
