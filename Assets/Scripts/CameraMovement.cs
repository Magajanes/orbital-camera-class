using UnityEngine;

public abstract class CameraMovement : MonoBehaviour
{
    public abstract void SetInitialValues();
    public abstract void SetParametersValues();
    public abstract void SetParametricPosition();
    public abstract void SetCameraPosition();
    
    protected virtual void Start()
    {
        SetInitialValues();
        SetParametricPosition();
    }

    protected virtual void Update()
    {
        if (Input.GetMouseButton(1))
        {
            SetParametersValues();
            SetParametricPosition();
        }
    }

    protected virtual void LateUpdate()
    {
        SetCameraPosition();
    }
}
