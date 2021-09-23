using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    public static int currentLevel;
    public static int ballCount;
    public static int totalCircles;
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

    private void UpgradeLevel()
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
}
