using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpriteRendererScript2Player : MonoBehaviour
{
    public Sprite[] ballSprites;
    public SpriteRenderer mySpriteRenderer;
    public ParticleSystem missParticles;
    public BallCollisions2player ballCollisions;

    private void Start()
    {
        int activeBallSkinID = GetComponent<ShopManagerScript>().GetSelectedBallID();
        mySpriteRenderer.sprite = ballSprites[activeBallSkinID];
        var psMain = missParticles.main;
        psMain.startColor = GetComponent<ShopManagerScript>().GetBallParticleColorForSelectedBall();
        ballCollisions.bounceSound = GetComponent<ShopManagerScript>().GetBounceAudioClipForSelectedBall();
    }
}