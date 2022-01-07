using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ResizingRendering_only : MonoBehaviour
{
    public VideoPlayer videoplayer;
    public MeshRenderer videoQuadRenderer;
    public GameObject videoQuad;
    private Vector3 previousVideoQuadScale = Vector3.zero;
    private RenderTexture videoTexture;
    


    public bool isVideoQuadResized()
    {
        bool resized = false;
        if (previousVideoQuadScale != videoQuad.transform.localScale)
        {
            previousVideoQuadScale = videoQuad.transform.localScale;
            resized = true;

        }

        return resized;

    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    
    // Get the aspect ratio of the videoplayer from videopalyer.
    
    void Update()
    {
        
        if (isVideoQuadResized())
        {
            int height = 256;
            int width =  (int) (256 * previousVideoQuadScale.x / previousVideoQuadScale.y);
            //videoTexture.Release();
            videoTexture = new RenderTexture(width, height, 0);
            videoplayer.targetTexture = videoTexture;
            videoQuadRenderer.material.mainTexture = videoTexture;
        }
    }
}

