using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float shakeDuration;
    [SerializeField] float shakeMagnitude;

    Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    public void PlayEffect()
    {
        StartCoroutine(ShakeEffect());
    }

    IEnumerator ShakeEffect()
    {
        float elapsedTime = 0;
        while (elapsedTime < shakeDuration)
        {
            transform.position = initialPosition + (Vector3) Random.insideUnitCircle * shakeMagnitude;
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        transform.position = initialPosition;
    }
}
