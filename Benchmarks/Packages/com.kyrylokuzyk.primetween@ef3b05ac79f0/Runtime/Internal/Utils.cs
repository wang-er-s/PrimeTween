using System;
using PrimeTween;

internal static class Utils {
    internal static (PropType, Type) TweenTypeToTweenData(TweenType tweenType) {
        switch (tweenType) {
            case TweenType.LightIntensity:
                return (PropType.Float, typeof(UnityEngine.Light));
            case TweenType.LightColor:
                return (PropType.Color, typeof(UnityEngine.Light));
            case TweenType.CameraOrthographicSize:
                return (PropType.Float, typeof(UnityEngine.Camera));
            case TweenType.CameraFieldOfView:
                return (PropType.Float, typeof(UnityEngine.Camera));
            case TweenType.LocalRotation:
                return (PropType.Vector3, typeof(UnityEngine.Transform));
            case TweenType.Rotation:
                return (PropType.Vector3, typeof(UnityEngine.Transform));
            case TweenType.Position:
                return (PropType.Vector3, typeof(UnityEngine.Transform));
            case TweenType.PositionX:
                return (PropType.Float, typeof(UnityEngine.Transform));
            case TweenType.PositionY:
                return (PropType.Float, typeof(UnityEngine.Transform));
            case TweenType.PositionZ:
                return (PropType.Float, typeof(UnityEngine.Transform));
            case TweenType.LocalPosition:
                return (PropType.Vector3, typeof(UnityEngine.Transform));
            case TweenType.LocalPositionX:
                return (PropType.Float, typeof(UnityEngine.Transform));
            case TweenType.LocalPositionY:
                return (PropType.Float, typeof(UnityEngine.Transform));
            case TweenType.LocalPositionZ:
                return (PropType.Float, typeof(UnityEngine.Transform));
            case TweenType.RotationQuaternion:
                return (PropType.Quaternion, typeof(UnityEngine.Transform));
            case TweenType.LocalRotationQuaternion:
                return (PropType.Quaternion, typeof(UnityEngine.Transform));
            case TweenType.Scale:
                return (PropType.Vector3, typeof(UnityEngine.Transform));
            case TweenType.ScaleX:
                return (PropType.Float, typeof(UnityEngine.Transform));
            case TweenType.ScaleY:
                return (PropType.Float, typeof(UnityEngine.Transform));
            case TweenType.ScaleZ:
                return (PropType.Float, typeof(UnityEngine.Transform));
            case TweenType.Color:
                return (PropType.Color, typeof(UnityEngine.SpriteRenderer));
            case TweenType.Alpha:
                return (PropType.Float, typeof(UnityEngine.SpriteRenderer));
            #if !UNITY_2019_1_OR_NEWER || UNITY_UGUI_INSTALLED
            case TweenType.UIPivotX:
                return (PropType.Float, typeof(UnityEngine.RectTransform));
            case TweenType.UIPivotY:
                return (PropType.Float, typeof(UnityEngine.RectTransform));
            case TweenType.UIPivot:
                return (PropType.Vector2, typeof(UnityEngine.RectTransform));
            case TweenType.UIAnchorMax:
                return (PropType.Vector2, typeof(UnityEngine.RectTransform));
            case TweenType.UIAnchorMin:
                return (PropType.Vector2, typeof(UnityEngine.RectTransform));
            case TweenType.UIAnchoredPosition3D:
                return (PropType.Vector3, typeof(UnityEngine.RectTransform));
            case TweenType.UIAnchoredPosition3DX:
                return (PropType.Float, typeof(UnityEngine.RectTransform));
            case TweenType.UIAnchoredPosition3DY:
                return (PropType.Float, typeof(UnityEngine.RectTransform));
            case TweenType.UIAnchoredPosition3DZ:
                return (PropType.Float, typeof(UnityEngine.RectTransform));
            case TweenType.UIAnchoredPosition:
                return (PropType.Vector2, typeof(UnityEngine.RectTransform));
            case TweenType.UIAnchoredPositionX:
                return (PropType.Float, typeof(UnityEngine.RectTransform));
            case TweenType.UIAnchoredPositionY:
                return (PropType.Float, typeof(UnityEngine.RectTransform));
            case TweenType.UISizeDelta:
                return (PropType.Vector2, typeof(UnityEngine.RectTransform));
            case TweenType.UIOffsetMin:
                return (PropType.Vector2, typeof(UnityEngine.RectTransform));
            case TweenType.UIOffsetMinX:
                return (PropType.Float, typeof(UnityEngine.RectTransform));
            case TweenType.UIOffsetMinY:
                return (PropType.Float, typeof(UnityEngine.RectTransform));
            case TweenType.UIOffsetMax:
                return (PropType.Vector2, typeof(UnityEngine.RectTransform));
            case TweenType.UIOffsetMaxX:
                return (PropType.Float, typeof(UnityEngine.RectTransform));
            case TweenType.UIOffsetMaxY:
                return (PropType.Float, typeof(UnityEngine.RectTransform));
            case TweenType.UIAlphaCanvasGroup:
                return (PropType.Float, typeof(UnityEngine.CanvasGroup));
            #endif
            case TweenType.MaterialColor:
                return (PropType.Color, typeof(UnityEngine.Material));
            case TweenType.MaterialAlpha:
                return (PropType.Float, typeof(UnityEngine.Material));
            case TweenType.MaterialMainTextureOffset:
                return (PropType.Vector2, typeof(UnityEngine.Material));
            case TweenType.MaterialMainTextureScale:
                return (PropType.Vector2, typeof(UnityEngine.Material));
            #if !UNITY_2019_1_OR_NEWER || AUDIO_MODULE_INSTALLED
            case TweenType.AudioVolume:
                return (PropType.Float, typeof(UnityEngine.AudioSource));
            #endif
            case TweenType.None:
                return (PropType.None, null);
            case TweenType.Delay:
                return (PropType.Float, null);
            case TweenType.Callback:
                return (PropType.Float, null);
            case TweenType.ShakeLocalPosition:
                return (PropType.Vector3, typeof(UnityEngine.Transform));
            case TweenType.ShakeLocalRotation:
                return (PropType.Quaternion, typeof(UnityEngine.Transform));
            case TweenType.ShakeScale:
                return (PropType.Vector3, typeof(UnityEngine.Transform));
            case TweenType.ShakeCustom:
                return (PropType.Vector3, typeof(UnityEngine.Transform));
            case TweenType.CustomFloat:
                return (PropType.Float, null);
            case TweenType.CustomColor:
                return (PropType.Color, null);
            case TweenType.CustomVector2:
                return (PropType.Vector2, null);
            case TweenType.CustomVector3:
                return (PropType.Vector3, null);
            case TweenType.CustomVector4:
                return (PropType.Vector4, null);
            case TweenType.CustomQuaternion:
                return (PropType.Quaternion, null);
            case TweenType.CustomRect:
                return (PropType.Rect, null);
            case TweenType.CustomDouble:
                return (PropType.Double, null);
            case TweenType.MaterialColorProperty:
                return (PropType.Color, typeof(UnityEngine.Material));
            case TweenType.MaterialProperty:
                return (PropType.Float, typeof(UnityEngine.Material));
            case TweenType.MaterialAlphaProperty:
                return (PropType.Float, typeof(UnityEngine.Material));
            case TweenType.MaterialTextureOffset:
                return (PropType.Vector2, typeof(UnityEngine.Material));
            case TweenType.MaterialTextureScale:
                return (PropType.Vector2, typeof(UnityEngine.Material));
            case TweenType.MaterialPropertyVector4:
                return (PropType.Vector4, typeof(UnityEngine.Material));
            case TweenType.LocalEulerAngles:
                return (PropType.Vector3, typeof(UnityEngine.Transform));
            case TweenType.EulerAngles:
                return (PropType.Vector3, typeof(UnityEngine.Transform));
            case TweenType.GlobalTimeScale:
                return (PropType.Float, null);
            case TweenType.MainSequence:
                return (PropType.Float, null);
            case TweenType.NestedSequence:
                return (PropType.Float, null);
            default:
                return (PropType.None, null);
        }
    }
}
