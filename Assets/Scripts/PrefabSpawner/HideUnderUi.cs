using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class HideUnderUi : MonoBehaviour
{
    [SerializeField] private LayerMask uiLayer;
    [SerializeField] private float fadeTime = 0.25f;
    public bool Hided { get; private set; } = false;

    private void Update()
    {
        if (IsPointerOverUIElement())
        {
            DOTween.To(() => transform.localScale, x => transform.localScale = x, Vector3.zero, fadeTime);
            Hided = true;
        }
        else
        {
            DOTween.To(() => transform.localScale, x => transform.localScale = x, Vector3.one, fadeTime);
            Hided = false;
        }
    }
    private bool IsPointerOverUIElement()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
}
