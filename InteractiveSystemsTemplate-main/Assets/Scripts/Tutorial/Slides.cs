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

    void Start()
    {
        numSlides = transform.childCount;
        slides = new GameObject[numSlides];

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
        if (showingSlides)
        {
            curTime += Time.deltaTime;
            if (curTime > timeBetweenSlides)
            {
                curTime = 0;
                nextSlide();
            }
        }
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
}
