using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    public string Name;
    protected SceneController gameSceneController;
    protected float halfWidht;
    protected float halfHeight;

    private SpriteRenderer spriteRenderer;

    protected virtual void Start()
    {
        gameSceneController = FindObjectOfType<SceneController>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        halfWidht = spriteRenderer.bounds.extents.x;
        halfHeight = spriteRenderer.bounds.extents.y;
    }

    public void SetColor(Color newColor)
    {
        spriteRenderer.color = newColor;
    }

    public void SetColor(float red, float green, float blue)
    {
        var newColor = new Color(red, green, blue);

    }
}
