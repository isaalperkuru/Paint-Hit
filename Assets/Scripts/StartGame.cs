using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartGame : MonoBehaviour
{
    public Text levelNo;
    public Text targetText;
    void OnEnable()
    {
        levelNo.text = LevelHandler.currentLevel + string.Empty;
        targetText.text = LevelHandler.totalCircles + string.Empty;
        StartCoroutine(DelayedRemoval());
    }
    
    IEnumerator DelayedRemoval()
    {
        yield return new WaitForSeconds(1);
        base.gameObject.SetActive(false);
    }
}
