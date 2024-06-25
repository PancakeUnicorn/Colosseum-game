using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Public : MonoBehaviour
{
    // Range for the random Y position
    public float maxY = 5f;

    // Speed of the lerp
    public float lerpSpeed = 2f;

    float _save;
    float randomY;

    private void Start()
    {
        _save = transform.localPosition.z;

        StartCoroutine(Wave()); 
    }

    private void Update()
    {
        transform.localPosition = Vector3.Slerp(transform.localPosition, new Vector3(transform.localPosition.x, transform.localPosition.y, randomY), lerpSpeed * Time.deltaTime);
    }

    IEnumerator Wave()
    {
        // Generate a random Y position within the range
        randomY = Random.Range(0, -maxY) + _save;

        // Lerp the object's Y position to the random positio

        float time = Random.Range(0.1f, 0.3f);
        yield return new WaitForSeconds(time);
        StartCoroutine(Wave());
    }
}
