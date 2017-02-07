using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{
    public float RotateUpSpeed = 1, RotateDownSpeed = 1;
    public float XSpeed = 1;
    public float VelocityPerJump = 3;
    public string teste;
    Vector3 birdRotation = Vector3.zero;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameController1.status == 1)
        {
            FixFlappyRotation();
            if (WasTouchedOrClicked())
            {
                BoostOnYAxis();

            }
        }
        else
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }
    }

    bool WasTouchedOrClicked()
    {
        if (Input.GetButtonUp("Jump") || Input.GetMouseButtonDown(0) ||
            (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended))
            return true;
        else
            return false;
    }
    void BoostOnYAxis()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, VelocityPerJump);
    }


    private void FixFlappyRotation()
    {
        int birdState = 0;
        var bird = GetComponent<Rigidbody2D>();
        if (bird.velocity.y > 0)
            birdState = 1;
        else
            birdState = -1;

        float degreesToAdd = 0;
        //Velocity = bird.rotation;
        switch (birdState)
        {
            case 1:
                if (bird.rotation < 18 || bird.rotation >= -20)
                    degreesToAdd = 6 * RotateUpSpeed;
                break;
            case -1:
                if (bird.rotation >= -20)
                    degreesToAdd = -3 * RotateDownSpeed;
                break;
            default:
                break;
        }

        //clamp the values so that -90<rotation<45 *always*
        birdRotation = new Vector3(0, 0, Mathf.Clamp(birdRotation.z + degreesToAdd, -90, 45));
        transform.eulerAngles = birdRotation;
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        teste = col.collider.name;
        BirdDies();
    }

    public void BirdDies()
    {
        GameController1.status = 3;
    }

}
