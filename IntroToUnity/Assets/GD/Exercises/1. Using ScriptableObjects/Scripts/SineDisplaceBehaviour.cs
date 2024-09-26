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

    //TODO - ALL - Replace float with FloatParameter, FloatVariable, FloatReference

    [SerializeField]
    private Vector3 direction = Vector3.up;

    [SerializeField]
    [Range(0, 10)]
    private float freqMultiplier = 1;

    [SerializeField]
    [Range(-180, 180)]
    private float phaseAngleDegrees = 0;

    private Vector3 originalPosition;
    private float elapsedTimeSecs;

    private void Start()
    {
        originalPosition = target.transform.position;
    }

    private void Update()
    {
        elapsedTimeSecs += Time.deltaTime;
        var displacement = amplitude
            * Mathf.Sin(freqMultiplier * elapsedTimeSecs
            + ToRadians(phaseAngleDegrees));
        target.transform.position
            = originalPosition + direction * displacement;
    }

    private float ToRadians(float degrees)
    {
        //180 degs = Mathf.PI
        return Mathf.PI * degrees / 180f;
    }
}