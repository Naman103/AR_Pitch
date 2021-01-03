using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SwipeManager : MonoBehaviour
{
    public Swipe swipeCheck;
   
    
    public GameObject[] pages;
    public GameObject sideMenu;

    public int curPage = 0;



    void Awake()
    {
        sideMenu.SetActive(true);
    }        
        

    void Update()
    {
        if (swipeCheck.swipeUp || swipeCheck.swipeLeft)
        {
            
            //load next slide
            //don't work in last slide
            if(curPage!=pages.Length-1)
            {
                curPage++;
                pages[curPage].SetActive(true);
                pages[curPage - 1].SetActive(false);

            }
        }
        if(swipeCheck.swipeDown || swipeCheck.swipeRight)
        {
            //load previous slide
            //don't work in first slide
            if (curPage != 0)
            {
                curPage--;
                pages[curPage].SetActive(true);
                pages[curPage + 1].SetActive(false);
            }

        }

    }
    public void loadPageOnButton(int pageToLoad)
    {
        pages[curPage].SetActive(false);
        curPage = pageToLoad;
        pages[curPage].SetActive(true);
    }
}
