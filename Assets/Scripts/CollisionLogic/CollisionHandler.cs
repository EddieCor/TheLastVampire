using HighlightPlus;
using System;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] GameObject _interactionText;
    [SerializeField] HighlightEffect _highlightEffect;

    void OnTriggerEnter(Collider other)
    {
        _interactionText.SetActive(true);
        SetHighlight(true);
    }

    void OnTriggerExit(Collider other)
    {
        _interactionText.SetActive(false);
        SetHighlight(false);
    }

    public void SetHighlight(bool isHighlighted)
    {
        if (_highlightEffect != null) _highlightEffect.highlighted = isHighlighted;
    }
}
