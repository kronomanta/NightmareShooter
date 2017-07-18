using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Transform _target;
    public float Smoothing = 5;

    private Transform _transform;
    private Vector3 _offset;
    private void Start()
    {
        _transform = transform;
        _offset = transform.position - _target.position;
    }

    private void FixedUpdate()
    {
        Vector3 targetCamPos = _target.position + _offset;
        _transform.position = Vector3.Lerp(_transform.position, targetCamPos, Smoothing * Time.deltaTime);
    }
}
