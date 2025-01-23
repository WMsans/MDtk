using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class HideUnderUi : MonoBehaviour
{
    [SerializeField] private LayerMask uiLayer;
    [SerializeField] private float fadeTime = 0.25f;

    private void Update()
    {
        if (IsPointerOverUIElement())
        {
            DOTween.To(() => transform.localScale, x => transform.localScale = x, Vector3.zero, fadeTime);
        }
        else
        {
            DOTween.To(() => transform.localScale, x => transform.localScale = x, Vector3.one, fadeTime);
        }
    }
    private bool IsPointerOverUIElement()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
}
