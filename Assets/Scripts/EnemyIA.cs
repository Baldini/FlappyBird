using UnityEngine;
using System.Collections;

public class EnemyIA : MonoBehaviour
{

    public Transform target;
    public float moveSpeed;

    private Transform _myTransform;

    void Awake()
    {
        _myTransform = transform;
    }
    // Use this for initialization
    void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Player");
        target = go.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(target.position, _myTransform.position, Color.red);

        //Se move em direção ao alvo
        _myTransform.position = new Vector3((_myTransform.position.x * (moveSpeed * Time.deltaTime)), (_myTransform.position.y * (moveSpeed * Time.deltaTime)));

    }
}
