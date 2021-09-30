using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpriteRendererGoldenKerb : MonoBehaviour
{
    public Sprite[] ballSprites;
    public SpriteRenderer mySpriteRenderer;
    private int[] activeSpriteID = new int[12];
    public ParticleSystem missParticles;
    public BallCollisionsGoldenKerb ballCollisions;

    public AudioClip rubberBounce;
    public AudioClip stoneBounce;
    public AudioClip sludgeBounce;
    public AudioClip moneyBounce;

    private void Start()
    {
        int activeBallSkinID = GetComponent<ShopManagerScript>().GetSelectedBallID();
        
        var psMain = missParticles.main;

        switch (activeBallSkinID)
        {
            case 1: // blue ball
            {
                mySpriteRenderer.sprite = ballSprites[activeBallSkinID];
                //basketball bounce
                ballCollisions.bounceSound = rubberBounce;
                //blue
                psMain.startColor = new Color(0.058f, 0.101f, 0.960f);
                break;
            }
            case 2: // yellow ball
            {
                //yellow
                //basketball bounce
                ballCollisions.bounceSound = rubberBounce;

                mySpriteRenderer.sprite = ballSprites[activeBallSkinID];
                psMain.startColor = new Color(0.941f, 0.984f, 0.035f);
                break;
            }
            case 3: //red ball
            {
                //red
                //basketball bounce
                ballCollisions.bounceSound = rubberBounce;

                mySpriteRenderer.sprite = ballSprites[activeBallSkinID];
                psMain.startColor = new Color(1f, 0.058f, 0.058f);
                break;
            }
            case 4: //purple ball
            {
                //purple
                //basketball bounce
                ballCollisions.bounceSound = rubberBounce;

                mySpriteRenderer.sprite = ballSprites[activeBallSkinID];
                psMain.startColor = new Color(0.549f, 0.086f, 0.552f);
                break;
            }
            case 5: // tractor wheel
            {
                //grey
                //basketball bounce
                psMain.startColor = new Color(0, 0, 0);
                ballCollisions.bounceSound = rubberBounce;

                mySpriteRenderer.sprite = ballSprites[activeBallSkinID];
                break;
            }
            case 6: //gifuffle ball
            {
                //white
                //stone bounce
                psMain.startColor = new Color(1, 1, 1);
                ballCollisions.bounceSound = stoneBounce;
                mySpriteRenderer.sprite = ballSprites[activeBallSkinID];
                break;
            }
            case 7: // donut
            {
                //donut cream colour
                //sludge bounce
                ballCollisions.bounceSound = sludgeBounce;
                mySpriteRenderer.sprite = ballSprites[activeBallSkinID];
                psMain.startColor = new Color(0.901f, 0.827f, 0.717f);
                break;
            }
            case 8: //watermelon
            {
                //dark green
                //sludge bounce
                psMain.startColor = new Color(0.184f, 0.447f, 0.133f);
                ballCollisions.bounceSound = sludgeBounce;
                mySpriteRenderer.sprite = ballSprites[activeBallSkinID];
                break;
            }
            case 9: //globe
            {
                //light blue
                //stone bounce
                psMain.startColor = new Color(0.513f, 0.807f, 0.749f);
                ballCollisions.bounceSound = stoneBounce;
                mySpriteRenderer.sprite = ballSprites[activeBallSkinID];
                break;
            }
            case 10: // coin
            {
                //gold
                //money bounce
                psMain.startColor = new Color(0.941f, 0.984f, 0.035f);
                ballCollisions.bounceSound = moneyBounce;
                mySpriteRenderer.sprite = ballSprites[activeBallSkinID];
                break;
            }
            case 11: // orange ball
            default:
            {
                //orange
                ballCollisions.bounceSound = rubberBounce;
                mySpriteRenderer.sprite = ballSprites[activeBallSkinID];
                psMain.startColor = new Color(0.972f, 0.564f, 0f);
                break;
            }
        }
    }
}
