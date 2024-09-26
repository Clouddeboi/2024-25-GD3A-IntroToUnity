using GD;
using UnityEngine;

/// <summary>
/// Applies a sinusoidal displacement on a game object along a user-defined direction, amplitude, and frequency
/// </summary>
public class SharedSineDisplaceBehaviour : MonoBehaviour
{
    #region Fields

    //A*Sin(wT + phi)
    //A: Amplitude, w: angular speed, phi: phase shift
    [SerializeField]
    [Tooltip("D&D the target object for this behaviour")]
    private Transform target;

    //[SerializeField]
    //[Range(0, 10)]
    //[Tooltip("Min/max range of the movement (caution: 0 = no movement")]
    //private float amplitude = 1;

    [SerializeField]
    [Tooltip("Min/max range of the movement (caution: 0 = no movement")]
    private FloatVariable amplitude;

    //TODO - ALL - Replace float with FloatParameter, FloatVariable, FloatReference

    [SerializeField]
    private Vector3Reference direction;

    [SerializeField]
    [Range(0, 10)]
    [Tooltip("Increase speed (>1), decrease (>1), no movement (=0)")]
    private float freqMultiplier = 1;

    [SerializeField]
    [Range(-180, 180)]
    [Tooltip("Positive shifts movement forward, negative shifts backwards")]
    private float phaseAngleDegrees = 0;

    #endregion Fields

    #region Internal variables

    private Vector3 originalPosition;
    private float elapsedTimeSecs;

    #endregion Internal variables

    private void Start()
    {
        originalPosition = target.transform.position;
    }

    private void Update()
    {
        //  Debug.Log($"Delta time: {Time.deltaTime}");
        elapsedTimeSecs += Time.deltaTime;
        var displacement = amplitude.Value * Mathf.Sin(freqMultiplier * elapsedTimeSecs
            + GD.GDMathf.ToRadians(phaseAngleDegrees));
        target.transform.position = originalPosition + direction.Value * displacement;
    }

    //private float ToRadians(float degrees)
    //{
    //    //return degrees * Mathf.Deg2Rad;
    //    //180 degs = Mathf.PI
    //    return Mathf.PI * degrees / 180f;
    //}
}