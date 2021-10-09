using UnityEngine;

public class BallSpriteRendererDoubleKerb : MonoBehaviour
{
    public SpriteRenderer ballSpriteRenderer;
    public ParticleSystem missParticles;
    public BallCollisionsDoubleKerb ballCollisions;

    private void Start()
    {
        ballSpriteRenderer.sprite = GetComponent<ShopManagerBallSkins>().GetActiveBallSkinSprite();
        ParticleSystem.MainModule psMain = missParticles.main;
        psMain.startColor = GetComponent<ShopManagerBallSkins>().GetActiveBallParticleColor();
        ballCollisions.bounceSound = GetComponent<ShopManagerBallSkins>().GetActiveBallBounceAudioClip();
    }
}