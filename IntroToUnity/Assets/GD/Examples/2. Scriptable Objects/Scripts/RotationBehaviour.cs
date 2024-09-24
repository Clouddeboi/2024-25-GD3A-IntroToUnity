using UnityEngine;

public class RotationBehaviour : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private Vector3 axis = Vector3.up;

    [SerializeField]
    private float angleInDegrees = 1;

    private void Update()
    {
        Debug.Log($"Time between: {Time.deltaTime}");
        target.transform.Rotate(axis, angleInDegrees);
    }
}