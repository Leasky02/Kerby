using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpriteRendererDoubleKerb : MonoBehaviour
{
    public SpriteRenderer ballSpriteRenderer;
    public ParticleSystem missParticles;
    public BallCollisionsDoubleKerb ballCollisions;

    private void Start()
    {
        ballSpriteRenderer.sprite = GetComponent<ShopManagerScript>().GetBallSpriteForSelectedBall();
        var psMain = missParticles.main;
        psMain.startColor = GetComponent<ShopManagerScript>().GetBallParticleColorForSelectedBall();
        ballCollisions.bounceSound = GetComponent<ShopManagerScript>().GetBounceAudioClipForSelectedBall();
    }
}