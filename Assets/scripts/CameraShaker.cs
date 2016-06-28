using UnityEngine;
using System.Collections;

public class CameraShaker : MonoBehaviour {

    // Transform of the camera to shake. Grabs the gameObject's transform
    // if null.
    public Transform camTransform;

    // How long the object should shake for.
    public float shakeDuration = 0f;

    // Amplitude of the shake. A larger value shakes the camera harder.
    [SerializeField] float shakeStartAmount = 0.7f;
    [SerializeField]
    float decreaseFactor = 1.0f;

    float currentShake;

    Vector3 originalPos;

    void Awake()
    {
        if (camTransform == null)
        {
            camTransform = GetComponent(typeof(Transform)) as Transform;
        }

        currentShake = shakeStartAmount;
    }

    void OnEnable()
    {
        originalPos = camTransform.localPosition;
    }

    public void ShakeScreen()
    {
        if (shakeDuration == 0)
        {
            shakeDuration = 0.2f;
            currentShake = shakeStartAmount;
        }

        else {
            shakeDuration = 0.2f;
            currentShake += 0.5f;
        }
        
    }

    void Update()
    {

        
        if (shakeDuration > 0)
        {
            camTransform.localPosition = originalPos + Random.insideUnitSphere * currentShake * 100 * Time.deltaTime;

            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shakeDuration = 0f;
            camTransform.localPosition = originalPos;
        }
    }
}
