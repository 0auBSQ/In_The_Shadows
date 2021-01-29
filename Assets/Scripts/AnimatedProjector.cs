using UnityEngine;
using System.Collections;

public class AnimatedProjector : MonoBehaviour
{
    public float fps = 30.0f;
    public Texture2D[] frames;
    private double frameIndex;
    private Projector projector;
 
    void Awake()
    {
        projector = GetComponent<Projector>();
    }
 
    void Update()
    {
        projector.material.SetTexture("_MainTex", frames[(int)frameIndex]);
        frameIndex = (frameIndex + 0.4) % frames.Length;
    }
}