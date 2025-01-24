using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    public GameObject prefab;
    private HideUnderUi _hideUnderUi;
    private SpriteRenderer _spriteRenderer;
    private void Awake()
    {
        _hideUnderUi = GetComponent<HideUnderUi>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        if(prefab) SetPrefab(prefab);
    }
    private void Spawn()
    {
        if(!prefab) return;
        var obj = Instantiate(prefab);
        obj.transform.position = transform.position;
    }

    private void Update()
    {
        if (_hideUnderUi.Hided) return;
        if(Input.GetMouseButtonDown(0) && prefab)
        {
            Spawn();
        }
    }

    public void SetPrefab(GameObject prefab)
    {
        this.prefab = prefab;
        var spriteRenderer = prefab.GetComponent<SpriteRenderer>();
        if (spriteRenderer)
        {
            _spriteRenderer.sprite = spriteRenderer.sprite;
        }
    }
}
