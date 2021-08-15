using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpriteRendererDoubleKerb : MonoBehaviour
{
    public Sprite[] ballSprites;
    public SpriteRenderer mySpriteRenderer;
    private int[] activeSpriteID = new int[12];
    public ParticleSystem missParticles;
    public BallCollisionsDoubleKerb ballCollisions;

    public AudioClip rubberBounce;
    public AudioClip stoneBounce;
    public AudioClip sludgeBounce;
    public AudioClip moneyBounce;

    private void Start()
    {

        activeSpriteID[1] = GetComponent<ShopManagerScript>().IsSelected(1);
        activeSpriteID[2] = GetComponent<ShopManagerScript>().IsSelected(2);
        activeSpriteID[3] = GetComponent<ShopManagerScript>().IsSelected(3);
        activeSpriteID[4] = GetComponent<ShopManagerScript>().IsSelected(4);
        activeSpriteID[5] = GetComponent<ShopManagerScript>().IsSelected(5);
        activeSpriteID[6] = GetComponent<ShopManagerScript>().IsSelected(6);
        activeSpriteID[7] = GetComponent<ShopManagerScript>().IsSelected(7);
        activeSpriteID[8] = GetComponent<ShopManagerScript>().IsSelected(8);
        activeSpriteID[9] = GetComponent<ShopManagerScript>().IsSelected(9);
        activeSpriteID[10] = GetComponent<ShopManagerScript>().IsSelected(10);
        activeSpriteID[11] = GetComponent<ShopManagerScript>().IsSelected(11);

        if (activeSpriteID[1] == 1) // blue bball
        {
            mySpriteRenderer.sprite = ballSprites[1];
            //basketball bounce
            ballCollisions.bounceSound = rubberBounce;
            //blue
            missParticles.startColor = new Color(0.058f, 0.101f, 0.960f);
        }
        else if (activeSpriteID[2] == 1) // yellow bball
        {
            //yellow
            //basketball bounce
            ballCollisions.bounceSound = rubberBounce;

            mySpriteRenderer.sprite = ballSprites[2];
            missParticles.startColor = new Color(0.941f, 0.984f, 0.035f);
        }
        else if (activeSpriteID[3] == 1) //red bball
        {
            //red
            //basketball bounce
            ballCollisions.bounceSound = rubberBounce;

            mySpriteRenderer.sprite = ballSprites[3];
            missParticles.startColor = new Color(1f, 0.058f, 0.058f);
        }
        else if (activeSpriteID[4] == 1) //purple bball
        {
            //purple
            //basketball bounce
            ballCollisions.bounceSound = rubberBounce;

            mySpriteRenderer.sprite = ballSprites[4];
            missParticles.startColor = new Color(0, 0, 0);
        }
        else if (activeSpriteID[5] == 1) // tractor wheel
        {
            //grey
            //basketball bounce
            missParticles.startColor = new Color(0.121f, 0.121f, 0.121f);
            ballCollisions.bounceSound = rubberBounce;

            mySpriteRenderer.sprite = ballSprites[5];
        }
        else if (activeSpriteID[6] == 1) //gifuffle ball
        {
            //white
            //stone bounce
            missParticles.startColor = new Color(1, 1, 1);
            ballCollisions.bounceSound = stoneBounce;
            mySpriteRenderer.sprite = ballSprites[6];
        }
        else if (activeSpriteID[7] == 1) // donut
        {
            //donut cream colour
            //sludge bounce
            ballCollisions.bounceSound = sludgeBounce;
            mySpriteRenderer.sprite = ballSprites[7];
            missParticles.startColor = new Color(0.901f, 0.827f, 0.717f);
        }
        else if (activeSpriteID[8] == 1) //watermelon
        {
            //dark green
            //sludge bounce
            missParticles.startColor = new Color(0.184f, 0.447f, 0.133f);
            ballCollisions.bounceSound = sludgeBounce;
            mySpriteRenderer.sprite = ballSprites[8];
        }
        else if (activeSpriteID[9] == 1) //globe
        {
            //light blue
            //stone bounce
            missParticles.startColor = new Color(0.513f, 0.807f, 0.749f);
            ballCollisions.bounceSound = stoneBounce;
            mySpriteRenderer.sprite = ballSprites[9];
        }
        else if (activeSpriteID[10] == 1) // coin
        {
            //gold
            //money bounce
            missParticles.startColor = new Color(0.941f, 0.984f, 0.035f);
            ballCollisions.bounceSound = moneyBounce;
            mySpriteRenderer.sprite = ballSprites[10];
        }
        else if (activeSpriteID[11] == 1) // orange bball
        {
            //orange
            ballCollisions.bounceSound = rubberBounce;
            mySpriteRenderer.sprite = ballSprites[11];
            missParticles.startColor = new Color(0.972f, 0.564f, 0f);
        }
    }
}
