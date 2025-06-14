using UnityEngine;

public class Paralax : MonoBehaviour
{
    [SerializeField] private Transform cameraPosition;
    [SerializeField] private Vector3 cameraStartPosition;
    [SerializeField] private float distance;

    [SerializeField] private GameObject[] backgrounds;
    [SerializeField] private Material[] materials;
    [SerializeField] private float[] backVelocity;
    [SerializeField] private float farthesback;

    [Range(0.01f, 0.05f)]
    public float parallaxVelocity;

    void Start()
    {
        cameraPosition = Camera.main.transform;
        cameraStartPosition = cameraPosition.position;

        int backCount = transform.childCount;
        materials = new Material[backCount];
        backVelocity = new float[backCount];
        backgrounds = new GameObject[backCount];

        for (int i = 0; i < backCount; i++)
        {
            backgrounds[i] = transform.GetChild(i).gameObject;
            materials[i] = backgrounds[i].GetComponent<Renderer>().material;
        }
        BackSpeedCalculate(backCount);
    }
    private void LateUpdate()
    {
        distance = cameraPosition.position.x - cameraStartPosition.x;
        transform.position = new Vector3(cameraPosition.position.x - 1, transform.position.y, 3f);
        for (int i = 0; i < backgrounds.Length; i++)
        {
            float speed = backVelocity[i] * (-parallaxVelocity);
            materials[i].SetTextureOffset("_MainTex", new Vector2(distance, 0) * speed);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void BackSpeedCalculate(int backCount)
    {
        for (int i = 0; i < backCount; i++)
        {
            if ((backgrounds[i].transform.position.z - cameraPosition.position.z) > farthesback)
            {
                farthesback = backgrounds[i].transform.position.z - cameraPosition.position.z;
            }
        }

        for (int i = 0; i < backCount; i++)
        {
            backVelocity[i] = i - (backgrounds[i].transform.position.z - cameraPosition.position.z) / farthesback;
        }
    }
}
