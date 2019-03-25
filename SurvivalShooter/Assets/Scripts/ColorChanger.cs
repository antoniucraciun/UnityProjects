using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChanger : MonoBehaviour {

    public Color startColor, endColor;
    public float speed = 1.0f;

    private float startTime;

    private void Start()
    {
        startTime = Time.time;
    }

    void Update () {

        float t = Mathf.Sin((Time.time - startTime) * speed);
        GetComponent<Image>().color = Color.Lerp(endColor, startColor, t);

    }
}
