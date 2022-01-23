using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(Collider))]
public class ClickHandler : MonoBehaviour
{
    public UnityEvent downEvent;
    public UnityEvent upEvent;

    Color originalColor;
    Renderer componentRenderer;

    private void Start()
    {
        componentRenderer = GetComponent<Renderer>();
        originalColor = componentRenderer.material.color;
    }


    void OnMouseDown()
    {
        Debug.Log("Down");
        downEvent?.Invoke();
        Highlight(true);
    }

    void OnMouseUp()
    {
        Debug.Log("Up");
        upEvent?.Invoke();
        Highlight(false);
    }

    void Highlight(bool isHighlighted)
    {
        if (isHighlighted)
        {
            componentRenderer.material.SetColor("_Color", Color.blue);
        } else
        {
            componentRenderer.material.SetColor("_Color", originalColor);
        }
    }
}
