using UnityEngine;

public class BallHandler : MonoBehaviour
{
    public static float rotationSpeed = 130f;
    public static float rotationTime = 3f;
    public static Color oneColor = Color.cyan;
    public GameObject ball;

    private float speed = 100f;

    private int ballCount;
    private int circleNo = 0;
    void Start()
    {
        GameObject gameObject2 = Instantiate(Resources.Load("Round" + Random.Range(1, 6))) as GameObject;
        gameObject2.transform.position = new Vector3(0, 20, 23);
        gameObject2.name = "Circle" + circleNo;

        ballCount = LevelHandler.ballCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HitBall();
        }
    }

    private void HitBall()
    {
        if(ballCount <= 1)
        {
            base.Invoke("MakeANewCircle", 0.4f);
            //Disable button
        }

        ballCount--;

        GameObject gameObject1 = Instantiate<GameObject>(ball, new Vector3(0, 0, -8), Quaternion.identity);
        gameObject1.GetComponent<MeshRenderer>().material.color = oneColor;
        gameObject1.GetComponent<Rigidbody>().AddForce(Vector3.forward * speed, ForceMode.Impulse);

    }

    void MakeANewCircle()
    {
        GameObject[] array = GameObject.FindGameObjectsWithTag("circle");
        GameObject gameObject3 = GameObject.Find("Circle" + circleNo);
        for (int i = 0; i < 24; i++)
        {
            gameObject3.transform.GetChild(i).gameObject.SetActive(false);
        }
        gameObject3.transform.GetChild(24).gameObject.GetComponent<MeshRenderer>().material.color = BallHandler.oneColor;

        if (gameObject3.GetComponent<iTween>())
        {
            gameObject3.GetComponent<iTween>().enabled = false;
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

        GameObject gameObject2 = Instantiate(Resources.Load("Round" + Random.Range(1, 6))) as GameObject;
        gameObject2.transform.position = new Vector3(0, 20, 23);
        gameObject2.name = "Circle" + circleNo;

        ballCount = LevelHandler.ballCount;
    }
}
