using System;
using UnityEngine;

public class CopyLimb : MonoBehaviour
{
    [SerializeField] private Transform _targetLimb;
    [SerializeField] private ConfigurableJoint _configurableJoint;

    private Quaternion _targetInitialRotation;
    private Vector3 _targetInitialPosition;
    
    private void OnEnable()
    {
        _targetInitialRotation = _targetLimb.transform.localRotation;//offset
        _targetInitialPosition = _targetLimb.transform.localPosition;
    }

    private void FixedUpdate()
    {
        _configurableJoint.targetRotation = CopyQuaternion();
        _configurableJoint.targetPosition = _targetInitialPosition;
    }

    private Quaternion CopyQuaternion()
    {
        
        return Quaternion.Inverse(_targetLimb.localRotation) * _targetInitialRotation;
    }
}
