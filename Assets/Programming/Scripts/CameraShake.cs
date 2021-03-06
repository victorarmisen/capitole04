using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
	// Transform of the camera to shake. Grabs the gameObject's transform
	// if null.
	public Transform camTransform;
	
	// How long the object should shake for.
	public float shakeDuration = 1.25f;

    // Amplitude of the shake. A larger value shakes the camera harder.
    public float shakeAmount = 0.5f;
	
	Vector3 originalPos;
	
	void Awake()
	{
		if (camTransform == null)
		{
			camTransform = GetComponent(typeof(Transform)) as Transform;
		}

	}
	
	void OnEnable()
	{
		originalPos = camTransform.localPosition;     
    }

	void LateUpdate()
    {
        if (shakeAmount > 0)
        {
            camTransform.localPosition = originalPos + Random.insideUnitSphere * (shakeAmount / 5);

            shakeAmount -= Time.deltaTime;

        }
        else
        {
            Destroy(this);

        }
    }
}
