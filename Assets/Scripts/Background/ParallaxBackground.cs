using System.Collections.Generic;
using UnityEngine;
 
[ExecuteInEditMode]
public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] ParallaxCamera parallaxCamera;
    [SerializeField] bool startAtCameraPosition;
    private List<ParallaxLayer> parallaxLayers;
 
    void Start()
    {
        if (parallaxCamera == null)
            if (Camera.main != null)
                parallaxCamera = Camera.main.GetComponent<ParallaxCamera>();

        if (parallaxCamera != null)
            parallaxCamera.onCameraTranslate += Move;
 
        SetLayers();
    }
 
    void SetLayers()
    {
        parallaxLayers = new();
 
        for (var i = 0; i < transform.childCount; i++)
        {
            var layer = transform.GetChild(i).GetComponent<ParallaxLayer>();

            if (layer == null) continue;
            layer.name = "Layer-" + i;
            parallaxLayers.Add(layer);
        }
        if(startAtCameraPosition) SetBackgroundPosition();
    }
 
    void Move(Vector2 delta)
    {
        foreach (ParallaxLayer layer in parallaxLayers)
        {
            layer.Move(delta);
        }
    }

    public void SetBackgroundPosition()
    {
        for (var i = 0; i < transform.childCount; i++)
        {
            var layer = transform.GetChild(i).GetComponent<ParallaxLayer>();

            if (layer == null) continue;
            layer.transform.position = (Vector2)parallaxCamera.transform.position;
        }
    }
}