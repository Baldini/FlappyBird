using UnityEngine;

public class MoveOffset : MonoBehaviour
{

    public int speed;

    private float _offset;

    private Material _currentMaterial;

    // Use this for initialization
    void Start()
    {
        _currentMaterial = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        _offset = 0.01f * Time.time;

        _currentMaterial.SetTextureOffset("_MainTex", new Vector2(_offset * speed, 0));
    }
}
