using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    public Image BG;
    public Sprite[] spr;

    void Start()
    {
        BG.sprite = spr[Random.Range(0, 4)];
    }
}
