using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slides : MonoBehaviour
{
    public float timeBetweenSlides;
    public bool firstSlides;

    private int numSlides;
    private GameObject[] slides;
    private int curSlide;
    private bool showingSlides;
    private float curTime;
    private bool player1clicked;
    private bool player2clicked;
    private float cooldown;

    void Start()
    {
        numSlides = transform.childCount;
        slides = new GameObject[numSlides];
        cooldown = -1;
        player1clicked = false;
        player2clicked = false;

        for (int i = 0; i < numSlides; i++)
        {
            slides[i] = transform.GetChild(i).gameObject;
            slides[i].SetActive(false);
        }

        curSlide = 0;
        showingSlides = false;
        
        if(firstSlides)
            TutorialManager.Instance.next();
    }

    void Update()
    {
        // if (showingSlides)
        // {
        //     curTime += Time.deltaTime;
        //     if (curTime > timeBetweenSlides)
        //     {
        //         curTime = 0;
        //         nextSlide();
        //     }
        // }
        cooldown -= Time.deltaTime;
    }

    public void showSlides()
    {
        showingSlides = true;
        slides[curSlide].SetActive(true);
    }

    private void nextSlide()
    {
        // Make curSlide active and sum one to curSlide
        if (curSlide < numSlides - 1)
        {
            slides[curSlide].SetActive(false);
            curSlide++;

            // If there are still more slides to show, show them
            slides[curSlide].SetActive(true);
        }
        else
            TutorialManager.Instance.next();
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!showingSlides)
        {
            return ;
        }

        if(other.gameObject.CompareTag("Player"))
        {   
           
            Player playerScript = other.gameObject.GetComponent<Player>();
            int numPlayer = playerScript.numPlayer;

            if(numPlayer == 1 )
            {
                player1clicked  = true;
                SoundManager.Instance.PlayGetMaterial();
            }
            else
            {
                player2clicked = true;
                SoundManager.Instance.PlayGetMaterial();

            }
            if (player1clicked && player2clicked && cooldown <= 0)
            {
                cooldown = 1.0f;
                player1clicked = false;
                player2clicked = false;
                nextSlide();
            }
        }
        
    }
    
   
    
}

