using System;
using System.Runtime.InteropServices;
using Sirenix.OdinInspector;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace PrimeTween {
    [Serializable]
    internal struct ValueContainerStartEnd {
        [HideInInspector]
        [SerializeField] internal TweenType tweenType; // todo HideInInspector?
        [SerializeField, Tooltip(Constants.startFromCurrentTooltip)] internal bool startFromCurrent;
        [Tooltip(Constants.startValueTooltip)]
        [HideInInspector]
        [SerializeField] internal ValueContainer startValue;
        [Tooltip(Constants.endValueTooltip)]
        [HideInInspector]
        [SerializeField] internal ValueContainer endValue;

#if UNITY_EDITOR
        [OnInspectorGUI]
        void OnGUI()
        {
            var propType = Utils.TweenTypeToTweenData(tweenType).Item1;
            if(!startFromCurrent)
                startValue.DrawGUI(GetSingleItemHeight(propType), "StartValue");
            endValue.DrawGUI(GetSingleItemHeight(propType), "EndValue");
        }

        static int GetSingleItemHeight(PropType propType)
        {
            switch (propType)
            {
                case PropType.Float:
                case PropType.Double:
                case PropType.Int:
                    return 1;
                case PropType.Vector2:
                    return 2;
                case PropType.Vector3:
                    return 3;
                case PropType.Vector4:
                case PropType.Color:
                case PropType.Rect:
                case PropType.Quaternion:
                    return 4;
                case PropType.None:
                    return 0;
                default:
                    throw new Exception();
            }
        }
#endif
    }

    [Serializable, StructLayout(LayoutKind.Explicit)]
    internal struct ValueContainer {
        // todo check if it was possible to modify ValueContainer in Debug Inspector before
        [FieldOffset(sizeof(float) * 0), SerializeField] internal float x;
        [FieldOffset(sizeof(float) * 1), SerializeField] internal float y;
        [FieldOffset(sizeof(float) * 2), SerializeField] internal float z;
        [FieldOffset(sizeof(float) * 3), SerializeField] internal float w;
        [FieldOffset(0), NonSerialized] internal float FloatVal;
        [FieldOffset(0), NonSerialized] internal Color ColorVal;
        [FieldOffset(0), NonSerialized] internal Vector2 Vector2Val;
        [FieldOffset(0), NonSerialized] internal Vector3 Vector3Val;
        [FieldOffset(0), NonSerialized] internal Vector4 Vector4Val;
        [FieldOffset(0), NonSerialized] internal Quaternion QuaternionVal;
        [FieldOffset(0), NonSerialized] internal Rect RectVal;
        [FieldOffset(0), NonSerialized] internal double DoubleVal;

#if UNITY_EDITOR
        public void DrawGUI(int count, string label)
        {
            switch (count)
            {
                case 1:
                    x =EditorGUILayout.FloatField(new GUIContent(label), x);
                    break;
                case 2:
                    var val = EditorGUILayout.Vector2Field(label, new Vector2(x, y));
                    x = val.x;
                    y = val.y;
                    break;
                case 3:
                    var val2 = EditorGUILayout.Vector3Field(label, new Vector3(x, y, z));
                    x = val2.x;
                    y = val2.y;
                    z = val2.z;
                    break;
                case 4:
                    var val3 = EditorGUILayout.Vector4Field(label, new Vector4(x, y, z, w));
                    x = val3.x;
                    y = val3.y;
                    z = val3.z;
                    w = val3.w;
                    break;
            }
        }

        public static string GetValNameFromPropType(PropType propType)
        {
            switch (propType)
            {
                case PropType.None:
                    return string.Empty;
                case PropType.Float:
                    return nameof(FloatVal);
                case PropType.Color:
                    return nameof(ColorVal);
                case PropType.Vector2:
                    return nameof(Vector2Val);
                case PropType.Vector3:
                    return nameof(Vector3Val);
                case PropType.Vector4:
                    return nameof(Vector4Val);
                case PropType.Quaternion:
                    return nameof(QuaternionVal);
                case PropType.Rect:
                    return nameof(RectVal);
                case PropType.Int:
                    return nameof(x);
                case PropType.Double:
                    return nameof(DoubleVal);
                default:
                    throw new ArgumentOutOfRangeException(nameof(propType), propType, null);
            }
        }
#endif

        internal void CopyFrom<T>(ref T val) where T : struct
        {
            switch (val)
            {
                case float f:
                    CopyFrom(ref f);
                    break;
                case Color c:
                    CopyFrom(ref c);
                    break;
                case Vector2 v:
                    CopyFrom(ref v);
                    break;
                case Vector3 v:
                    CopyFrom(ref v);
                    break;
                case Vector4 v:
                    CopyFrom(ref v);
                    break;
                case Quaternion q:
                    CopyFrom(ref q);
                    break;
                case Rect r:
                    CopyFrom(ref r);
                    break;
                case double d:
                    CopyFrom(ref d);
                    break;
                default:
                    throw new ArgumentException($"{nameof(ValueContainer)} can't copy from {val.GetType()}");
            }
        }

        internal void CopyFrom(ref float val) {
            x = val;
            y = 0f;
            z = 0f;
            w = 0f;
        }

        internal void CopyFrom(ref Color val) {
            x = val.r;
            y = val.g;
            z = val.b;
            w = val.a;
        }

        internal void CopyFrom(ref Vector2 val) {
            x = val.x;
            y = val.y;
            z = 0f;
            w = 0f;
        }

        internal void CopyFrom(ref Vector3 val) {
            x = val.x;
            y = val.y;
            z = val.z;
            w = 0f;
        }

        internal void CopyFrom(ref Vector4 val) {
            x = val.x;
            y = val.y;
            z = val.z;
            w = val.w;
        }

        internal void CopyFrom(ref Rect val) {
            x = val.x;
            y = val.y;
            z = val.width;
            w = val.height;
        }

        internal void CopyFrom(ref Quaternion val) {
            x = val.x;
            y = val.y;
            z = val.z;
            w = val.w;
        }

        internal void CopyFrom(ref double val) {
            Reset();
            DoubleVal = val;
        }

        internal void Reset() {
            x = y = z = w = 0f;
        }

        internal float this[int i] {
            get => Vector4Val[i];
            set => Vector4Val[i] = value;
        }

        public override string ToString() => Vector4Val.ToString();
    }
}
