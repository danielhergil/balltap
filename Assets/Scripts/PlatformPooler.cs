using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPooler : MonoBehaviour
{
    public GameObject[] platforms;

    public BallController theBall;
    private int theBallPasses = 0;
    private int platformActive;

    // Update is called once per frame
    void Update()
    {
        if(theBall.isFirstTouch && theBallPasses == theBall.passes)
        {
            StartCoroutine(SetPlatforms());
        }
    }

    private IEnumerator SetPlatforms()
    {
        theBallPasses++;
        yield return new WaitForSeconds(0.2f);
        platforms[platformActive].SetActive(false);
        float oldPosition = platforms[platformActive].transform.localPosition.y;
        platformActive = Random.Range(0, 8);
        Vector3 newPos = platforms[platformActive].transform.localPosition;
        if(oldPosition < 2.0f)
        {
            newPos.y = Random.Range(3.0f, 13.5f);
        }
        if (oldPosition > 11.0f)
        {
            newPos.y = Random.Range(0.15f, 10.0f);
        }
        if (oldPosition > 2.0f && oldPosition < 11.0f)
        {
            switch(Random.Range(0, 2))
            {
                case 0:
                    newPos.y = Random.Range(0.15f, oldPosition - 2.0f);
                    break;
                case 1:
                    newPos.y = Random.Range(oldPosition + 2.0f, 13.5f);
                    break;
            }
        }
        //newPos.y = Random.Range(0.15f, 13.5f);
        platforms[platformActive].transform.localPosition = newPos;
        platforms[platformActive].SetActive(true);
    }
}
