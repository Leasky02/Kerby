using UnityEngine;

public class BallSpriteRenderScript : MonoBehaviour
{
    public SpriteRenderer ballSpriteRenderer;
    public ParticleSystem missParticles;
    public BallCollisions ballCollisions;

    private void Start()
    {
        ballSpriteRenderer.sprite = GameManager.Instance.GetBallSkinsShopManager().GetActiveBallSkinSprite();
        ParticleSystem.MainModule psMain = missParticles.main;
        psMain.startColor = GameManager.Instance.GetBallSkinsShopManager().GetActiveBallParticleColor();
        ballCollisions.bounceSound = GameManager.Instance.GetBallSkinsShopManager().GetActiveBallBounceAudioClip();
    }
}
