using System;
using System.Collections;
using PrimeTween;
using Sirenix.OdinInspector;
#if UNITY_EDITOR
using Sirenix.OdinInspector.Editor;
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.Serialization;

[ExecuteInEditMode]
public class TweenAnimation : MonoBehaviour
{
    [ValueDropdown(nameof(tweenTypes), DoubleClickToConfirm = true)]
#if UNITY_EDITOR
    [OnValueChanged(nameof(OnTweenTypeChanged))]
#endif
    public TweenType AnimType;
    
    [SerializeField]
    [PropertyOrder(100)]
    bool PlayOnAwake;
    
    [SerializeField]
    [HideInInspector]
     public UnityEngine.Object TargetObject;
    [SerializeField]
    [PropertyOrder(100)]
    ValueContainerStartEnd StartEndVal;
    [PropertyOrder(100)]
    [SerializeField]
    TweenSettings TweenSettings;

    Type unityObjType;
    

    private void Start()
    {
        if (!Application.isPlaying) return;
        if (PlayOnAwake)
        {
            Play();
        }
    }
    
#if UNITY_EDITOR

    private ValueDropdownList<TweenType> tweenTypes;
    
    private void OnEnable()
    {
        OnTweenTypeChanged();
        InitTweenTypes();
    }

    private void OnTweenTypeChanged()
    {
        StartEndVal.tweenType = AnimType;
        unityObjType = Utils.TweenTypeToTweenData(AnimType).Item2;
        if (TargetObject != null && TargetObject.GetType() != unityObjType)
        {
            TargetObject = null;
        }

        if (TargetObject == null && unityObjType != null)
        {
            TargetObject = gameObject.GetComponent(unityObjType);
        }
    }

    private void InitTweenTypes()
    {
        if(tweenTypes != null) return;
        tweenTypes = new ValueDropdownList<TweenType>();
        foreach (string val in Enum.GetNames(typeof(TweenType)))
        {
            if (Enum.TryParse(val, out TweenType tweenType))
            {
                var field = typeof(TweenType).GetField(val);
                var isHide = field.IsDefined(typeof(HideInInspector), false);
                if (isHide)
                {
                    continue;
                }

                var type = Utils.TweenTypeToTweenData(tweenType).Item2;
                if (type == null) continue;
                tweenTypes.Add(type.Name + $"/{val}", tweenType);
            }
        }
    }

    [OnInspectorGUI]
    private void OnInspectorGUI()
    {
        TargetObject = EditorGUILayout.ObjectField("Target",TargetObject, unityObjType);
    }
#endif

    public void Play()
    {
        DoPlay();
    }

    private void DoPlay()
    {
        switch (AnimType)
        {
            case TweenType.EulerAngles:
                Tween.EulerAngles(TargetObject as Transform,
                    StartEndVal.startFromCurrent
                        ? new TweenSettings<Vector3>(StartEndVal.endValue.Vector3Val, TweenSettings)
                        : new TweenSettings<Vector3>(StartEndVal.startValue.Vector3Val, StartEndVal.endValue.Vector3Val,
                            TweenSettings));
                break;
            case TweenType.LocalEulerAngles:
                Tween.LocalEulerAngles(TargetObject as Transform,
                    StartEndVal.startFromCurrent
                        ? new TweenSettings<Vector3>(StartEndVal.endValue.Vector3Val, TweenSettings)
                        : new TweenSettings<Vector3>(StartEndVal.startValue.Vector3Val, StartEndVal.endValue.Vector3Val,
                            TweenSettings));
                break;
            // CODE GENERATOR BEGIN
            case TweenType.LightIntensity:
                Tween.LightIntensity(TargetObject as UnityEngine.Light,
                    StartEndVal.startFromCurrent
                        ? new TweenSettings<float>(StartEndVal.endValue.FloatVal, TweenSettings)
                        : new TweenSettings<float>(StartEndVal.startValue.FloatVal, StartEndVal.endValue.FloatVal,
                            TweenSettings));
                break;

            case TweenType.LightColor:
                Tween.LightColor(TargetObject as UnityEngine.Light,
                    StartEndVal.startFromCurrent
                        ? new TweenSettings<UnityEngine.Color>(StartEndVal.endValue.ColorVal, TweenSettings)
                        : new TweenSettings<UnityEngine.Color>(StartEndVal.startValue.ColorVal, StartEndVal.endValue.ColorVal,
                            TweenSettings));
                break;

            case TweenType.CameraOrthographicSize:
                Tween.CameraOrthographicSize(TargetObject as UnityEngine.Camera,
                    StartEndVal.startFromCurrent
                        ? new TweenSettings<float>(StartEndVal.endValue.FloatVal, TweenSettings)
                        : new TweenSettings<float>(StartEndVal.startValue.FloatVal, StartEndVal.endValue.FloatVal,
                            TweenSettings));
                break;

            case TweenType.CameraFieldOfView:
                Tween.CameraFieldOfView(TargetObject as UnityEngine.Camera,
                    StartEndVal.startFromCurrent
                        ? new TweenSettings<float>(StartEndVal.endValue.FloatVal, TweenSettings)
                        : new TweenSettings<float>(StartEndVal.startValue.FloatVal, StartEndVal.endValue.FloatVal,
                            TweenSettings));
                break;

            case TweenType.LocalRotation:
                Tween.LocalRotation(TargetObject as UnityEngine.Transform,
                    StartEndVal.startFromCurrent
                        ? new TweenSettings<UnityEngine.Vector3>(StartEndVal.endValue.Vector3Val, TweenSettings)
                        : new TweenSettings<UnityEngine.Vector3>(StartEndVal.startValue.Vector3Val, StartEndVal.endValue.Vector3Val,
                            TweenSettings));
                break;

            case TweenType.Rotation:
                Tween.Rotation(TargetObject as UnityEngine.Transform,
                    StartEndVal.startFromCurrent
                        ? new TweenSettings<UnityEngine.Vector3>(StartEndVal.endValue.Vector3Val, TweenSettings)
                        : new TweenSettings<UnityEngine.Vector3>(StartEndVal.startValue.Vector3Val, StartEndVal.endValue.Vector3Val,
                            TweenSettings));
                break;

            case TweenType.Position:
                Tween.Position(TargetObject as UnityEngine.Transform,
                    StartEndVal.startFromCurrent
                        ? new TweenSettings<UnityEngine.Vector3>(StartEndVal.endValue.Vector3Val, TweenSettings)
                        : new TweenSettings<UnityEngine.Vector3>(StartEndVal.startValue.Vector3Val, StartEndVal.endValue.Vector3Val,
                            TweenSettings));
                break;

            case TweenType.PositionX:
                Tween.PositionX(TargetObject as UnityEngine.Transform,
                    StartEndVal.startFromCurrent
                        ? new TweenSettings<float>(StartEndVal.endValue.FloatVal, TweenSettings)
                        : new TweenSettings<float>(StartEndVal.startValue.FloatVal, StartEndVal.endValue.FloatVal,
                            TweenSettings));
                break;

            case TweenType.PositionY:
                Tween.PositionY(TargetObject as UnityEngine.Transform,
                    StartEndVal.startFromCurrent
                        ? new TweenSettings<float>(StartEndVal.endValue.FloatVal, TweenSettings)
                        : new TweenSettings<float>(StartEndVal.startValue.FloatVal, StartEndVal.endValue.FloatVal,
                            TweenSettings));
                break;

            case TweenType.PositionZ:
                Tween.PositionZ(TargetObject as UnityEngine.Transform,
                    StartEndVal.startFromCurrent
                        ? new TweenSettings<float>(StartEndVal.endValue.FloatVal, TweenSettings)
                        : new TweenSettings<float>(StartEndVal.startValue.FloatVal, StartEndVal.endValue.FloatVal,
                            TweenSettings));
                break;

            case TweenType.LocalPosition:
                Tween.LocalPosition(TargetObject as UnityEngine.Transform,
                    StartEndVal.startFromCurrent
                        ? new TweenSettings<UnityEngine.Vector3>(StartEndVal.endValue.Vector3Val, TweenSettings)
                        : new TweenSettings<UnityEngine.Vector3>(StartEndVal.startValue.Vector3Val, StartEndVal.endValue.Vector3Val,
                            TweenSettings));
                break;

            case TweenType.LocalPositionX:
                Tween.LocalPositionX(TargetObject as UnityEngine.Transform,
                    StartEndVal.startFromCurrent
                        ? new TweenSettings<float>(StartEndVal.endValue.FloatVal, TweenSettings)
                        : new TweenSettings<float>(StartEndVal.startValue.FloatVal, StartEndVal.endValue.FloatVal,
                            TweenSettings));
                break;

            case TweenType.LocalPositionY:
                Tween.LocalPositionY(TargetObject as UnityEngine.Transform,
                    StartEndVal.startFromCurrent
                        ? new TweenSettings<float>(StartEndVal.endValue.FloatVal, TweenSettings)
                        : new TweenSettings<float>(StartEndVal.startValue.FloatVal, StartEndVal.endValue.FloatVal,
                            TweenSettings));
                break;

            case TweenType.LocalPositionZ:
                Tween.LocalPositionZ(TargetObject as UnityEngine.Transform,
                    StartEndVal.startFromCurrent
                        ? new TweenSettings<float>(StartEndVal.endValue.FloatVal, TweenSettings)
                        : new TweenSettings<float>(StartEndVal.startValue.FloatVal, StartEndVal.endValue.FloatVal,
                            TweenSettings));
                break;

            case TweenType.RotationQuaternion:
                Tween.Rotation(TargetObject as UnityEngine.Transform,
                    StartEndVal.startFromCurrent
                        ? new TweenSettings<UnityEngine.Quaternion>(StartEndVal.endValue.QuaternionVal, TweenSettings)
                        : new TweenSettings<UnityEngine.Quaternion>(StartEndVal.startValue.QuaternionVal, StartEndVal.endValue.QuaternionVal,
                            TweenSettings));
                break;

            case TweenType.LocalRotationQuaternion:
                Tween.LocalRotation(TargetObject as UnityEngine.Transform,
                    StartEndVal.startFromCurrent
                        ? new TweenSettings<UnityEngine.Quaternion>(StartEndVal.endValue.QuaternionVal, TweenSettings)
                        : new TweenSettings<UnityEngine.Quaternion>(StartEndVal.startValue.QuaternionVal, StartEndVal.endValue.QuaternionVal,
                            TweenSettings));
                break;

            case TweenType.Scale:
                Tween.Scale(TargetObject as UnityEngine.Transform,
                    StartEndVal.startFromCurrent
                        ? new TweenSettings<UnityEngine.Vector3>(StartEndVal.endValue.Vector3Val, TweenSettings)
                        : new TweenSettings<UnityEngine.Vector3>(StartEndVal.startValue.Vector3Val, StartEndVal.endValue.Vector3Val,
                            TweenSettings));
                break;

            case TweenType.ScaleX:
                Tween.ScaleX(TargetObject as UnityEngine.Transform,
                    StartEndVal.startFromCurrent
                        ? new TweenSettings<float>(StartEndVal.endValue.FloatVal, TweenSettings)
                        : new TweenSettings<float>(StartEndVal.startValue.FloatVal, StartEndVal.endValue.FloatVal,
                            TweenSettings));
                break;

            case TweenType.ScaleY:
                Tween.ScaleY(TargetObject as UnityEngine.Transform,
                    StartEndVal.startFromCurrent
                        ? new TweenSettings<float>(StartEndVal.endValue.FloatVal, TweenSettings)
                        : new TweenSettings<float>(StartEndVal.startValue.FloatVal, StartEndVal.endValue.FloatVal,
                            TweenSettings));
                break;

            case TweenType.ScaleZ:
                Tween.ScaleZ(TargetObject as UnityEngine.Transform,
                    StartEndVal.startFromCurrent
                        ? new TweenSettings<float>(StartEndVal.endValue.FloatVal, TweenSettings)
                        : new TweenSettings<float>(StartEndVal.startValue.FloatVal, StartEndVal.endValue.FloatVal,
                            TweenSettings));
                break;

            case TweenType.Color:
                Tween.Color(TargetObject as UnityEngine.SpriteRenderer,
                    StartEndVal.startFromCurrent
                        ? new TweenSettings<UnityEngine.Color>(StartEndVal.endValue.ColorVal, TweenSettings)
                        : new TweenSettings<UnityEngine.Color>(StartEndVal.startValue.ColorVal, StartEndVal.endValue.ColorVal,
                            TweenSettings));
                break;

            case TweenType.Alpha:
                Tween.Alpha(TargetObject as UnityEngine.SpriteRenderer,
                    StartEndVal.startFromCurrent
                        ? new TweenSettings<float>(StartEndVal.endValue.FloatVal, TweenSettings)
                        : new TweenSettings<float>(StartEndVal.startValue.FloatVal, StartEndVal.endValue.FloatVal,
                            TweenSettings));
                break;
#if !UNITY_2019_1_OR_NEWER || UNITY_UGUI_INSTALLED

            case TweenType.UIPivotX:
                Tween.UIPivotX(TargetObject as UnityEngine.RectTransform,
                    StartEndVal.startFromCurrent
                        ? new TweenSettings<float>(StartEndVal.endValue.FloatVal, TweenSettings)
                        : new TweenSettings<float>(StartEndVal.startValue.FloatVal, StartEndVal.endValue.FloatVal,
                            TweenSettings));
                break;

            case TweenType.UIPivotY:
                Tween.UIPivotY(TargetObject as UnityEngine.RectTransform,
                    StartEndVal.startFromCurrent
                        ? new TweenSettings<float>(StartEndVal.endValue.FloatVal, TweenSettings)
                        : new TweenSettings<float>(StartEndVal.startValue.FloatVal, StartEndVal.endValue.FloatVal,
                            TweenSettings));
                break;

            case TweenType.UIPivot:
                Tween.UIPivot(TargetObject as UnityEngine.RectTransform,
                    StartEndVal.startFromCurrent
                        ? new TweenSettings<UnityEngine.Vector2>(StartEndVal.endValue.Vector2Val, TweenSettings)
                        : new TweenSettings<UnityEngine.Vector2>(StartEndVal.startValue.Vector2Val, StartEndVal.endValue.Vector2Val,
                            TweenSettings));
                break;

            case TweenType.UIAnchorMax:
                Tween.UIAnchorMax(TargetObject as UnityEngine.RectTransform,
                    StartEndVal.startFromCurrent
                        ? new TweenSettings<UnityEngine.Vector2>(StartEndVal.endValue.Vector2Val, TweenSettings)
                        : new TweenSettings<UnityEngine.Vector2>(StartEndVal.startValue.Vector2Val, StartEndVal.endValue.Vector2Val,
                            TweenSettings));
                break;

            case TweenType.UIAnchorMin:
                Tween.UIAnchorMin(TargetObject as UnityEngine.RectTransform,
                    StartEndVal.startFromCurrent
                        ? new TweenSettings<UnityEngine.Vector2>(StartEndVal.endValue.Vector2Val, TweenSettings)
                        : new TweenSettings<UnityEngine.Vector2>(StartEndVal.startValue.Vector2Val, StartEndVal.endValue.Vector2Val,
                            TweenSettings));
                break;

            case TweenType.UIAnchoredPosition3D:
                Tween.UIAnchoredPosition3D(TargetObject as UnityEngine.RectTransform,
                    StartEndVal.startFromCurrent
                        ? new TweenSettings<UnityEngine.Vector3>(StartEndVal.endValue.Vector3Val, TweenSettings)
                        : new TweenSettings<UnityEngine.Vector3>(StartEndVal.startValue.Vector3Val, StartEndVal.endValue.Vector3Val,
                            TweenSettings));
                break;

            case TweenType.UIAnchoredPosition3DX:
                Tween.UIAnchoredPosition3DX(TargetObject as UnityEngine.RectTransform,
                    StartEndVal.startFromCurrent
                        ? new TweenSettings<float>(StartEndVal.endValue.FloatVal, TweenSettings)
                        : new TweenSettings<float>(StartEndVal.startValue.FloatVal, StartEndVal.endValue.FloatVal,
                            TweenSettings));
                break;

            case TweenType.UIAnchoredPosition3DY:
                Tween.UIAnchoredPosition3DY(TargetObject as UnityEngine.RectTransform,
                    StartEndVal.startFromCurrent
                        ? new TweenSettings<float>(StartEndVal.endValue.FloatVal, TweenSettings)
                        : new TweenSettings<float>(StartEndVal.startValue.FloatVal, StartEndVal.endValue.FloatVal,
                            TweenSettings));
                break;

            case TweenType.UIAnchoredPosition3DZ:
                Tween.UIAnchoredPosition3DZ(TargetObject as UnityEngine.RectTransform,
                    StartEndVal.startFromCurrent
                        ? new TweenSettings<float>(StartEndVal.endValue.FloatVal, TweenSettings)
                        : new TweenSettings<float>(StartEndVal.startValue.FloatVal, StartEndVal.endValue.FloatVal,
                            TweenSettings));
                break;

            case TweenType.UIAnchoredPosition:
                Tween.UIAnchoredPosition(TargetObject as UnityEngine.RectTransform,
                    StartEndVal.startFromCurrent
                        ? new TweenSettings<UnityEngine.Vector2>(StartEndVal.endValue.Vector2Val, TweenSettings)
                        : new TweenSettings<UnityEngine.Vector2>(StartEndVal.startValue.Vector2Val, StartEndVal.endValue.Vector2Val,
                            TweenSettings));
                break;

            case TweenType.UIAnchoredPositionX:
                Tween.UIAnchoredPositionX(TargetObject as UnityEngine.RectTransform,
                    StartEndVal.startFromCurrent
                        ? new TweenSettings<float>(StartEndVal.endValue.FloatVal, TweenSettings)
                        : new TweenSettings<float>(StartEndVal.startValue.FloatVal, StartEndVal.endValue.FloatVal,
                            TweenSettings));
                break;

            case TweenType.UIAnchoredPositionY:
                Tween.UIAnchoredPositionY(TargetObject as UnityEngine.RectTransform,
                    StartEndVal.startFromCurrent
                        ? new TweenSettings<float>(StartEndVal.endValue.FloatVal, TweenSettings)
                        : new TweenSettings<float>(StartEndVal.startValue.FloatVal, StartEndVal.endValue.FloatVal,
                            TweenSettings));
                break;

            case TweenType.UISizeDelta:
                Tween.UISizeDelta(TargetObject as UnityEngine.RectTransform,
                    StartEndVal.startFromCurrent
                        ? new TweenSettings<UnityEngine.Vector2>(StartEndVal.endValue.Vector2Val, TweenSettings)
                        : new TweenSettings<UnityEngine.Vector2>(StartEndVal.startValue.Vector2Val, StartEndVal.endValue.Vector2Val,
                            TweenSettings));
                break;

            case TweenType.UIOffsetMin:
                Tween.UIOffsetMin(TargetObject as UnityEngine.RectTransform,
                    StartEndVal.startFromCurrent
                        ? new TweenSettings<UnityEngine.Vector2>(StartEndVal.endValue.Vector2Val, TweenSettings)
                        : new TweenSettings<UnityEngine.Vector2>(StartEndVal.startValue.Vector2Val, StartEndVal.endValue.Vector2Val,
                            TweenSettings));
                break;

            case TweenType.UIOffsetMinX:
                Tween.UIOffsetMinX(TargetObject as UnityEngine.RectTransform,
                    StartEndVal.startFromCurrent
                        ? new TweenSettings<float>(StartEndVal.endValue.FloatVal, TweenSettings)
                        : new TweenSettings<float>(StartEndVal.startValue.FloatVal, StartEndVal.endValue.FloatVal,
                            TweenSettings));
                break;

            case TweenType.UIOffsetMinY:
                Tween.UIOffsetMinY(TargetObject as UnityEngine.RectTransform,
                    StartEndVal.startFromCurrent
                        ? new TweenSettings<float>(StartEndVal.endValue.FloatVal, TweenSettings)
                        : new TweenSettings<float>(StartEndVal.startValue.FloatVal, StartEndVal.endValue.FloatVal,
                            TweenSettings));
                break;

            case TweenType.UIOffsetMax:
                Tween.UIOffsetMax(TargetObject as UnityEngine.RectTransform,
                    StartEndVal.startFromCurrent
                        ? new TweenSettings<UnityEngine.Vector2>(StartEndVal.endValue.Vector2Val, TweenSettings)
                        : new TweenSettings<UnityEngine.Vector2>(StartEndVal.startValue.Vector2Val, StartEndVal.endValue.Vector2Val,
                            TweenSettings));
                break;

            case TweenType.UIOffsetMaxX:
                Tween.UIOffsetMaxX(TargetObject as UnityEngine.RectTransform,
                    StartEndVal.startFromCurrent
                        ? new TweenSettings<float>(StartEndVal.endValue.FloatVal, TweenSettings)
                        : new TweenSettings<float>(StartEndVal.startValue.FloatVal, StartEndVal.endValue.FloatVal,
                            TweenSettings));
                break;

            case TweenType.UIOffsetMaxY:
                Tween.UIOffsetMaxY(TargetObject as UnityEngine.RectTransform,
                    StartEndVal.startFromCurrent
                        ? new TweenSettings<float>(StartEndVal.endValue.FloatVal, TweenSettings)
                        : new TweenSettings<float>(StartEndVal.startValue.FloatVal, StartEndVal.endValue.FloatVal,
                            TweenSettings));
                break;

            case TweenType.UIAlphaCanvasGroup:
                Tween.UIAlpha(TargetObject as UnityEngine.CanvasGroup,
                    StartEndVal.startFromCurrent
                        ? new TweenSettings<float>(StartEndVal.endValue.FloatVal, TweenSettings)
                        : new TweenSettings<float>(StartEndVal.startValue.FloatVal, StartEndVal.endValue.FloatVal,
                            TweenSettings));
                break;
#endif

            case TweenType.MaterialColor:
                Tween.MaterialColor(TargetObject as UnityEngine.Material,
                    StartEndVal.startFromCurrent
                        ? new TweenSettings<UnityEngine.Color>(StartEndVal.endValue.ColorVal, TweenSettings)
                        : new TweenSettings<UnityEngine.Color>(StartEndVal.startValue.ColorVal, StartEndVal.endValue.ColorVal,
                            TweenSettings));
                break;

            case TweenType.MaterialAlpha:
                Tween.MaterialAlpha(TargetObject as UnityEngine.Material,
                    StartEndVal.startFromCurrent
                        ? new TweenSettings<float>(StartEndVal.endValue.FloatVal, TweenSettings)
                        : new TweenSettings<float>(StartEndVal.startValue.FloatVal, StartEndVal.endValue.FloatVal,
                            TweenSettings));
                break;

            case TweenType.MaterialMainTextureOffset:
                Tween.MaterialMainTextureOffset(TargetObject as UnityEngine.Material,
                    StartEndVal.startFromCurrent
                        ? new TweenSettings<UnityEngine.Vector2>(StartEndVal.endValue.Vector2Val, TweenSettings)
                        : new TweenSettings<UnityEngine.Vector2>(StartEndVal.startValue.Vector2Val, StartEndVal.endValue.Vector2Val,
                            TweenSettings));
                break;

            case TweenType.MaterialMainTextureScale:
                Tween.MaterialMainTextureScale(TargetObject as UnityEngine.Material,
                    StartEndVal.startFromCurrent
                        ? new TweenSettings<UnityEngine.Vector2>(StartEndVal.endValue.Vector2Val, TweenSettings)
                        : new TweenSettings<UnityEngine.Vector2>(StartEndVal.startValue.Vector2Val, StartEndVal.endValue.Vector2Val,
                            TweenSettings));
                break;
#if !UNITY_2019_1_OR_NEWER || AUDIO_MODULE_INSTALLED

            case TweenType.AudioVolume:
                Tween.AudioVolume(TargetObject as UnityEngine.AudioSource,
                    StartEndVal.startFromCurrent
                        ? new TweenSettings<float>(StartEndVal.endValue.FloatVal, TweenSettings)
                        : new TweenSettings<float>(StartEndVal.startValue.FloatVal, StartEndVal.endValue.FloatVal,
                            TweenSettings));
                break;
#endif
// CODE GENERATOR END
        }
    }

}