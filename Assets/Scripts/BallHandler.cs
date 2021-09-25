using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BallHandler : MonoBehaviour
{
    public static float rotationSpeed = 130f;
    public static float rotationTime = 3f;
    public static int currentCircleNo;
    private static int CircleCount;
    public static Color oneColor;

    public GameObject ball;
    public GameObject dummyBall;
    public GameObject btn;
    public GameObject levelComplete;
    public GameObject failScreen;
    public GameObject startGameScreen;
    public GameObject circleEffect;
    public GameObject completeEffect;

    public SpriteRenderer spr;
    public Material splashMat;

    private Color[] changingColors;

    private float speed = 100f;

    private int ballCount;
    private int circleNo = 0;
    private int heartsNo;

    private bool gameFail;

    public Image[] balls;
    public GameObject[] Hearts;

    public Text total_balls_text;
    public Text count_balls_text;
    public Text levelCompleteText;

    public AudioSource completeSound;
    public AudioSource gameFailSound;


    void Start()
    {
        ResetGame();
    }

    void ResetGame()
    {
        CircleCount = 1;
        changingColors = ColorScript.colorArray;
        print(changingColors);
        oneColor = changingColors[0];
        spr.color = oneColor;
        splashMat.color = oneColor;

        ChangeBallsCount();

        GameObject gameObject2 = Instantiate(Resources.Load("round" + Random.Range(1, 6))) as GameObject;
        gameObject2.transform.position = new Vector3(0, 20, 23);
        gameObject2.name = "Circle" + circleNo;

        ballCount = LevelHandler.ballCount;

        currentCircleNo = circleNo;
        LevelHandler.currentColor = oneColor;
        heartsNo = PlayerPrefs.GetInt("hearts");
        if (heartsNo == 0)
            PlayerPrefs.SetInt("hearts", 1);
        heartsNo = PlayerPrefs.GetInt("hearts");
        for (int i = 0; i < heartsNo; i++)
        {
            Hearts[i].SetActive(true);
        }

        MakeHurdles();
    }
    public void FailGame()
    {
        gameFailSound.Play();
        gameFail = true;
        Invoke("FailScreen", 1);
        btn.SetActive(false);
        StopCircle();
    }
    void StopCircle()
    {
        GameObject gameObject = GameObject.Find("Circle" + circleNo);
        gameObject.transform.GetComponent<MonoBehaviour>().enabled = false;
        if (gameObject.GetComponent<iTween>())
            gameObject.GetComponent<iTween>().enabled = false;
    }

    void FailScreen()
    {
        failScreen.SetActive(true);
    }
    public void DeleteAllCircles()
    {
        GameObject[] array = GameObject.FindGameObjectsWithTag("circle");
        foreach (GameObject gameObject in array)
        {
            Destroy(gameObject.gameObject);
        }
        gameFail = false;
        FindObjectOfType<LevelHandler>().UpgradeLevel();
        ResetGame();
    }
    public void HeartsLow()
    {
        heartsNo--;
        PlayerPrefs.SetInt("hearts", heartsNo);
        Hearts[heartsNo].SetActive(false);
    }
    public void HitBall()
    {
        if(ballCount <= 1)
        {
            StartCoroutine(HideBtn());
            base.Invoke("MakeANewCircle", 0.4f);
        }
        ballCount--;
        if (ballCount >= 0)
            balls[ballCount].enabled = false;


        GameObject gameObject1 = Instantiate<GameObject>(ball, new Vector3(0, 0, -8), Quaternion.identity);
        gameObject1.GetComponent<MeshRenderer>().material.color = oneColor;
        gameObject1.GetComponent<Rigidbody>().AddForce(Vector3.forward * speed, ForceMode.Impulse);

    }
    void ChangeBallsCount()
    {
        ballCount = LevelHandler.ballCount;
        dummyBall.GetComponent<MeshRenderer>().material.color = oneColor;

        total_balls_text.text = string.Empty + LevelHandler.totalCircles;
        count_balls_text.text = string.Empty + CircleCount;

        for (int i = 0; i < balls.Length; i++)
        {
            balls[i].enabled = false;
        }

        for (int j = 0; j < ballCount; j++)
        {
            balls[j].enabled = true;
            balls[j].color = oneColor;
        }

    }

    void MakeANewCircle()
    {
        if (CircleCount >= LevelHandler.totalCircles && !gameFail)
        {
            completeSound.Play();
            StartCoroutine(LevelCompleteScreen());
        }
        else
        {
            StartCoroutine(CircleEffect());
            GameObject[] array = GameObject.FindGameObjectsWithTag("circle");
            GameObject gameObject = GameObject.Find("Circle" + this.circleNo);
            for (int i = 0; i < 24; i++)
            {
                gameObject.transform.GetChild(i).gameObject.SetActive(false);
            }
            gameObject.transform.GetChild(24).gameObject.GetComponent<MeshRenderer>().material.color = BallHandler.oneColor;
            if (gameObject.GetComponent<iTween>())
            {
                gameObject.GetComponent<iTween>().enabled = false;
            }
            foreach (GameObject target in array)
            {
                iTween.MoveBy(target, iTween.Hash(new object[]
                {
                    "y",
                    -2.98f,
                    "easetype",
                    iTween.EaseType.spring,
                    "time",
                    0.5
                }));
            }
            this.circleNo++;
            currentCircleNo = circleNo;

            GameObject gameObject2 = Instantiate(Resources.Load("round" + Random.Range(1, 6))) as GameObject;
            gameObject2.transform.position = new Vector3(0, 20, 23);
            gameObject2.name = "Circle" + circleNo;

            ballCount = LevelHandler.ballCount;

            oneColor = changingColors[Mathf.Clamp(circleNo, 0, 7)];
            spr.color = oneColor;
            splashMat.color = oneColor;

            LevelHandler.currentColor = oneColor;
            MakeHurdles();
            CircleCount++;
            ChangeBallsCount();

        }
    }
    void MakeHurdles()
    {
        if (circleNo == 1)
            FindObjectOfType<LevelHandler>().MakeHurdles();
        if (circleNo == 2)
            FindObjectOfType<LevelHandler>().MakeHurdles2();
        if (circleNo == 3)
            FindObjectOfType<LevelHandler>().MakeHurdles3();
        if (circleNo == 4)
            FindObjectOfType<LevelHandler>().MakeHurdles4();
        if (circleNo == 5)
            FindObjectOfType<LevelHandler>().MakeHurdles5();
        if (circleNo == 6)
            FindObjectOfType<LevelHandler>().MakeHurdles6();
    }

    IEnumerator LevelCompleteScreen()
    {
        gameFail = true;

        completeEffect.SetActive(true);

        if (GameObject.Find("Circle0"))
        {
            completeEffect.transform.position = GameObject.Find("Circle0").transform.position;
        }
        else if (GameObject.Find("Circle1"))
        {
            completeEffect.transform.position = GameObject.Find("Circle1").transform.position;
        }
        else if (GameObject.Find("Circle2"))
        {
            completeEffect.transform.position = GameObject.Find("Circle2").transform.position;
        }

        GameObject oldCirlce = GameObject.Find("Circle" + circleNo);
        for (int i = 0; i < 24; i++)
        {
            oldCirlce.transform.GetChild(i).GetComponent<MeshRenderer>().enabled = false;
        }
        oldCirlce.transform.GetChild(24).gameObject.GetComponent<MeshRenderer>().material.color = oneColor;
        oldCirlce.transform.GetComponent<MonoBehaviour>().enabled = false;
        if (oldCirlce.GetComponent<iTween>())
            oldCirlce.GetComponent<iTween>().enabled = false;
        btn.SetActive(false);
        yield return new WaitForSeconds(2);
        levelComplete.SetActive(true);
        levelCompleteText.text = string.Empty + LevelHandler.currentLevel;
        yield return new WaitForSeconds(1);
        GameObject[] oldCirlces = GameObject.FindGameObjectsWithTag("circle");
        foreach (GameObject gameObject in oldCirlces)
        {
            Destroy(gameObject.gameObject);
        }
        yield return new WaitForSeconds(1);
        completeEffect.SetActive(false);
        int currentLevel = PlayerPrefs.GetInt("C_Level");
        currentLevel++;
        PlayerPrefs.SetInt("C_Level", currentLevel);
        GameObject.FindObjectOfType<LevelHandler>().UpgradeLevel();
        ResetGame();
        levelComplete.SetActive(false);
        startGameScreen.SetActive(true);
        gameFail = false;
    }
    IEnumerator CircleEffect()
    {
        yield return new WaitForSeconds(.4f);
        circleEffect.SetActive(true);
        yield return new WaitForSeconds(.8f);
        circleEffect.SetActive(false);
    }

    IEnumerator HideBtn()
    {
        if (!gameFail)
        {
            btn.SetActive(false);
            yield return new WaitForSeconds(1);
            btn.SetActive(true);
        }
    }
}
