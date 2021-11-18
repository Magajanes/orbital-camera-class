using UnityEngine;

public class OrbitalCameraMovement : CameraMovement
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private float smoothness;
    [SerializeField]
    private float mouseSensitivity;

    private Vector3 cameraHeight;
    private Vector3 cameraRadius;
    private Vector3 nextPosition;

    private float fixedRadius;
    private float angle = 3.89f;

    public override void SetInitialValues()
    {
        Vector3 cameraDistanceToPlayer = transform.position - target.position;
        cameraHeight = cameraDistanceToPlayer.y * Vector3.up;
        cameraRadius = cameraDistanceToPlayer - cameraHeight;
        fixedRadius = cameraRadius.magnitude;
        transform.forward = -cameraDistanceToPlayer.normalized;
    }

    public override void SetParametersValues()
    {
        angle -= Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
    }

    public override void SetParametricPosition()
    {
        cameraRadius.x = fixedRadius * Mathf.Cos(angle);
        cameraRadius.z = fixedRadius * Mathf.Sin(angle);
    }

    public override void SetCameraPosition()
    {
        nextPosition = target.position + cameraHeight + cameraRadius;
        transform.position = Vector3.Lerp(transform.position, nextPosition, smoothness * Time.deltaTime);
        transform.forward = (target.position - transform.position).normalized;
    }
}
