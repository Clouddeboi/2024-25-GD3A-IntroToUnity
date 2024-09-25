using UnityEngine;

/// <summary>
/// Applies a sinusoidal displacement on a game object along a user-defined direction, amplitude, and frequency
/// </summary>
public class SineDisplaceBehaviour : MonoBehaviour
{
    //A*Sin(wT + phi)
    //A: Amplitude, w: angular speed, phi: phase shift
    [SerializeField]
    private Transform target;

    [SerializeField]
    private float amplitude = 1;

    [SerializeField]
    private Vector3 direction = Vector3.up;

    private Vector3 originalPosition;

    private void Start()
    {
        originalPosition = target.transform.position;
    }

    private void Update()
    {
        var displacement = amplitude * Mathf.Sin(Time.time);
        target.transform.position
            = originalPosition + direction * displacement;
    }
}