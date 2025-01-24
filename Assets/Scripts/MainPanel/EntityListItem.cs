using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class EntityListItem : MonoBehaviour
{
    public EntitySelectable Entity { get; set; }

    [SerializeField] private TextMeshProUGUI identifierTextMesh;

    public void GoToEntity()
    {
        if(!Entity) return;
        TeleportManager.Instance.Teleport(Entity.transform.position);
        Entity.SelectThis();
    }

    private void Update()
    {
        identifierTextMesh.text = Entity.GetPropertyValue("Name").GetValue();
    }
}
