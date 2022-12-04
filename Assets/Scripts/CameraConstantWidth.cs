using UnityEngine;

/// <summary>
/// Keeps constant camera width instead of height, works for both Orthographic & Perspective cameras
/// Made for tutorial https://youtu.be/0cmxFjP375Y
/// </summary>
public class CameraConstantWidth : MonoBehaviour {
    public Vector2 DefaultResolution = new Vector2(1920,1080);
    [Range(0f, 1f)] public float WidthOrHeight = 0;

    private Camera _componentCamera;

    private float _initialSize;
    private float _targetAspect;


    private void Start() {
        _componentCamera = GetComponent<Camera>();
        _initialSize = _componentCamera.orthographicSize;

        _targetAspect = DefaultResolution.x / DefaultResolution.y;
    }
    private void Update() {
        if (_componentCamera.orthographic) {
            float constantWidthSize = _initialSize * (_targetAspect / _componentCamera.aspect);
            _componentCamera.orthographicSize = Mathf.Lerp(constantWidthSize, _initialSize, WidthOrHeight);
        } 
    }

}