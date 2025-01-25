using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(SpriteRenderer))]
public class SelectionFrame : MonoBehaviour
{
    private static readonly int Select = Animator.StringToHash("Select");
    private static readonly int Deselect = Animator.StringToHash("Deselect");
    [SerializeField] private SpriteRenderer selectedSpriteRenderer;
    [SerializeField] private float selectCooldown = 0.5f;
    private SpriteRenderer _frameSpriteRenderer;
    private Animator _animator;
    private float _lastTime;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _frameSpriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        InitializeSize();
    }
    private void InitializeSize()
    {
        // get size of sprite
        var size = selectedSpriteRenderer.bounds.size;
        _frameSpriteRenderer.size = size;
        // set position to center
        _frameSpriteRenderer.transform.localPosition = Vector3.zero;
    }

    public void SetSelected(bool selected)
    {
        if(_lastTime + selectCooldown > Time.time) return;
        _lastTime = Time.time;
        _animator.SetTrigger(selected ? Select : Deselect);
    }
}
