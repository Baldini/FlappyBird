using UnityEngine;

public class ObstacleController : MonoBehaviour
{

    public int speed;


    void Start()
    {

    }


    void Update()
    {
        transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        if (transform.position.x < -18.07f)
        {
            gameObject.SetActive(false);
        }
    }
}
