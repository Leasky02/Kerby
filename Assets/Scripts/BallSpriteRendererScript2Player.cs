using UnityEngine;

public class BallSpriteRendererScript2Player : MonoBehaviour
{
    public SpriteRenderer ballSpriteRenderer;
    public ParticleSystem missParticles;
    public BallCollisions2player ballCollisions;

    private void Start()
    {
        ballSpriteRenderer.sprite = GetComponent<ShopManagerBallSkins>().GetActiveBallSkinSprite();
        ParticleSystem.MainModule psMain = missParticles.main;
        psMain.startColor = GetComponent<ShopManagerBallSkins>().GetActiveBallParticleColor();
        ballCollisions.bounceSound = GetComponent<ShopManagerBallSkins>().GetActiveBallBounceAudioClip();
    }
}