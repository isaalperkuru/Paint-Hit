using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    public static int currentLevel;
    public static int ballCount;
    public static int totalCircles;
    public static Color currentColor;
    void Awake()
    {
        if(PlayerPrefs.GetInt("firstTime1", 0) == 0)
        {
            PlayerPrefs.SetInt("firstTime1", 1);
            PlayerPrefs.SetInt("C_Level", 1);
            //Add more to it
        }
        UpgradeLevel();
    }

    public void UpgradeLevel()
    {
        currentLevel = PlayerPrefs.GetInt("C_Level", 1);

        if(currentLevel == 1)
        {
            ballCount = 3;
            totalCircles = 2;
        }
        if (currentLevel == 2)
        {
            ballCount = 3;
            totalCircles = 3;
        }
        if (currentLevel == 3)
        {
            ballCount = 3;
            totalCircles = 4;
        }
        if (currentLevel >= 4 && currentLevel <= 7)
        {
            ballCount = 3;
            totalCircles = 5;
        }
        if (currentLevel <= 8 && currentLevel >= 13)
        {
            ballCount = 4;
            totalCircles = 6;
        }
        if (currentLevel <= 14 && currentLevel >= 20)
        {
            ballCount = 4;
            totalCircles = 6;
            BallHandler.rotationSpeed = 150;
            BallHandler.rotationTime = 2;
        }
        if (currentLevel >= 21)
        {
            ballCount = 5;
            totalCircles = 7;
            BallHandler.rotationSpeed = 170;
            BallHandler.rotationTime = 1.5f;
        }
    }

    public void MakeHurdles()
    {
        GameObject gameObject1 = GameObject.Find("Circle" + BallHandler.currentCircleNo);

        int index = UnityEngine.Random.Range(1, 3);

        gameObject1.transform.GetChild(index).gameObject.GetComponent<MeshRenderer>().enabled = true;
        gameObject1.transform.GetChild(index).gameObject.GetComponent<MeshRenderer>().material.color = currentColor;
        gameObject1.transform.GetChild(index).gameObject.tag = "red";


    }
    public void MakeHurdles2()
    {
        GameObject gameObject1 = GameObject.Find("Circle" + BallHandler.currentCircleNo);

        int[] array = new int[]
        {
            UnityEngine.Random.Range(1,3),
            UnityEngine.Random.Range(15,17)
        };

        for (int i = 0; i < array.Length; i++)
        {
            gameObject1.transform.GetChild(array[i]).gameObject.GetComponent<MeshRenderer>().enabled = true;
            gameObject1.transform.GetChild(array[i]).gameObject.GetComponent<MeshRenderer>().material.color = currentColor;
            gameObject1.transform.GetChild(array[i]).gameObject.tag = "red";
        }
    }

    public void MakeHurdles3()
    {
        GameObject gameObject1 = GameObject.Find("Circle" + BallHandler.currentCircleNo);

        int[] array = new int[]
        {
            UnityEngine.Random.Range(1,3),
            UnityEngine.Random.Range(4,6),
            UnityEngine.Random.Range(18,20)
        };

        for (int i = 0; i < array.Length; i++)
        {
            gameObject1.transform.GetChild(array[i]).gameObject.GetComponent<MeshRenderer>().enabled = true;
            gameObject1.transform.GetChild(array[i]).gameObject.GetComponent<MeshRenderer>().material.color = currentColor;
            gameObject1.transform.GetChild(array[i]).gameObject.tag = "red";
        }
    }

    public void MakeHurdles4()
    {
        GameObject gameObject1 = GameObject.Find("Circle" + BallHandler.currentCircleNo);

        int[] array = new int[]
        {
            UnityEngine.Random.Range(1,3),
            UnityEngine.Random.Range(4,6),
            UnityEngine.Random.Range(15,17),
            UnityEngine.Random.Range(22,24)
        };

        for (int i = 0; i < array.Length; i++)
        {
            gameObject1.transform.GetChild(array[i]).gameObject.GetComponent<MeshRenderer>().enabled = true;
            gameObject1.transform.GetChild(array[i]).gameObject.GetComponent<MeshRenderer>().material.color = currentColor;
            gameObject1.transform.GetChild(array[i]).gameObject.tag = "red";
        }
    }

    public void MakeHurdles5()
    {
        GameObject gameObject1 = GameObject.Find("Circle" + BallHandler.currentCircleNo);

        int[] array = new int[]
        {
            UnityEngine.Random.Range(1,3),
            UnityEngine.Random.Range(4,6),
            UnityEngine.Random.Range(11,13),
            UnityEngine.Random.Range(8,10),
            UnityEngine.Random.Range(15,17)
        };

        for (int i = 0; i < array.Length; i++)
        {
            gameObject1.transform.GetChild(array[i]).gameObject.GetComponent<MeshRenderer>().enabled = true;
            gameObject1.transform.GetChild(array[i]).gameObject.GetComponent<MeshRenderer>().material.color = currentColor;
            gameObject1.transform.GetChild(array[i]).gameObject.tag = "red";
        }
    }
    public void MakeHurdles6()
    {
        GameObject gameObject1 = GameObject.Find("Circle" + BallHandler.currentCircleNo);

        int[] array = new int[]
        {
            UnityEngine.Random.Range(1,3),
            UnityEngine.Random.Range(4,6),
            UnityEngine.Random.Range(11,13),
            UnityEngine.Random.Range(8,10),
            UnityEngine.Random.Range(15,17),
            UnityEngine.Random.Range(7,9)
        };

        for (int i = 0; i < array.Length; i++)
        {
            gameObject1.transform.GetChild(array[i]).gameObject.GetComponent<MeshRenderer>().enabled = true;
            gameObject1.transform.GetChild(array[i]).gameObject.GetComponent<MeshRenderer>().material.color = currentColor;
            gameObject1.transform.GetChild(array[i]).gameObject.tag = "red";
        }
    }

}
