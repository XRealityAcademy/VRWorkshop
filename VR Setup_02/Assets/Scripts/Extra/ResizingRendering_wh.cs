using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ResizingRendering_wh : MonoBehaviour
{
    //get the video player
    public VideoPlayer videoplayer;
    // get a mesh renderer for the video
    public MeshRenderer videoQuadRenderer;
    // get a quad for the video
    public GameObject videoQuad;
    //scale zero out
    private Vector3 previousVideoQuadScale = Vector3.zero;
    //get a video rendering texture
    private RenderTexture videoTexture;
    

    // Test out if the video is being resized. If yes, then return true (resized).
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
        //if the video quad is being resized, then if the hight is 256, then the width is the height * ratio
        if (isVideoQuadResized())
        {
            //using the height as 1
            if (previousVideoQuadScale.x / previousVideoQuadScale.y >= 568 / 320)
            {
                int height = 320;
                int width =  (int) (320 * previousVideoQuadScale.x / previousVideoQuadScale.y);
                //videoTexture.Release();
                videoTexture = new RenderTexture(width, height, 0);
                videoplayer.targetTexture = videoTexture;
                videoQuadRenderer.material.mainTexture = videoTexture;
                var videoAspectRatio = VideoAspectRatio.FitVertically;
            }
            else
            {
                //using the width as 1
                int width = 568;
                int height =  (int) (568 * previousVideoQuadScale.y / previousVideoQuadScale.x);
                //videoTexture.Release();
                videoTexture = new RenderTexture(width, height, 0);
                videoplayer.targetTexture = videoTexture;
                videoQuadRenderer.material.mainTexture = videoTexture;
                var videoAspectRatio = VideoAspectRatio.FitHorizontally;
            }

        }
    }
}

