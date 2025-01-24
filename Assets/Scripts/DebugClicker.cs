using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DebugClicker : MonoBehaviour
{
    public UnityEvent OnClick;
    
    [EditorCools.Button]
    private void Click() => OnClick.Invoke();
}
