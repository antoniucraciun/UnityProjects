using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Hints : MonoBehaviour
{
    public List<string> hints = new List<string>();
    public TMP_Text hintsText;

    private void Awake()
    {
        hintsText = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        hintsText.text = hints[Random.Range(0, hints.Capacity)];
    }
}
