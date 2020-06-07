using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(RangedFloat), true)]
public class RangedFloatDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        label = EditorGUI.BeginProperty(position, label, property);
        position = EditorGUI.PrefixLabel(position, label);

        SerializedProperty minProp = property.FindPropertyRelative("minValue");
        SerializedProperty maxProp = property.FindPropertyRelative("maxValue");

        float minValue = minProp.floatValue;
        float maxValue = maxProp.floatValue;

        float rangeMin = 0f;
        float rangeMax = 1f;

        MinMaxRangeAttribute[] ranges = (MinMaxRangeAttribute[])fieldInfo.GetCustomAttributes(typeof(MinMaxRangeAttribute), true);
        if (ranges.Length > 0)
        {
            rangeMin = ranges[0].Min;
            rangeMax = ranges[0].Max;
        }

        var minLabelRect = new Rect(position);
        minLabelRect.width = 40;
        GUI.Label(minLabelRect, new GUIContent(minValue.ToString("F2")));
        position.xMin += 40;

        var maxLabelRect = new Rect(position);
        maxLabelRect.xMin = maxLabelRect.xMax - 40;
        GUI.Label(maxLabelRect, new GUIContent(maxValue.ToString("F2")));
        position.xMax -= 40;

        EditorGUI.BeginChangeCheck();
        EditorGUI.MinMaxSlider(position, ref minValue, ref maxValue, rangeMin, rangeMax);
        if (EditorGUI.EndChangeCheck())
        {
            minProp.floatValue = minValue;
            maxProp.floatValue = maxValue;
        }

        EditorGUI.EndProperty();
   }
}
