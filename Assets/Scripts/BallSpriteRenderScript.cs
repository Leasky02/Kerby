using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpriteRenderScript : MonoBehaviour
{
    public Sprite[] ballSprites;
    public SpriteRenderer mySpriteRenderer;
    private int[] activeSpriteID = new int[12];
    public ParticleSystem missParticles;
    public BallCollisions ballCollisions;

    private void Start()
    {
        int activeBallSkinID = GetComponent<ShopManagerScript>().GetSelectedBallID();
        mySpriteRenderer.sprite = ballSprites[activeBallSkinID];
        var psMain = missParticles.main;
        psMain.startColor = GetComponent<ShopManagerScript>().GetBallParticleColorForSelectedBall();
        ballCollisions.bounceSound = GetComponent<ShopManagerScript>().GetBounceAudioClipForSelectedBall();
    }
}
