using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EntityPropertyValueInputBehaviour : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI placeholderText;
    private bool _initialized;
    private EntityPropertyBehaviour _entityPropertyBehaviour;
    public void InitializeBehaviour(EntityPropertyBehaviour entityPropertyBehaviour)
    {
        _initialized = true;
        _entityPropertyBehaviour = entityPropertyBehaviour;
    }

    private void Update()
    {
        if (!_initialized) return;
        placeholderText.text = _entityPropertyBehaviour.Value.GetValue();
    }
}
