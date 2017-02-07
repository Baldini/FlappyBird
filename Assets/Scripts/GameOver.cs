using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController1.status == 3)
        {
            gameObject.SetActive(true);
        }

    }
}
