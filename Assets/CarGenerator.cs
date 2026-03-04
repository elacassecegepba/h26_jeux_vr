using UnityEngine;

public class CarGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject carPrefab;

    private Car currentCar;
    [SerializeField]
    GameObject Spawnpoint;

    [SerializeField]
    Transform PumpLocation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        currentCar = FindAnyObjectByType<Car>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currentCar == null || currentCar.DrivingOff) {
            Color random = Random.ColorHSV();
            currentCar = Instantiate(carPrefab, Spawnpoint.transform.position, Spawnpoint.transform.rotation).GetComponent<Car>();
            currentCar.Target = PumpLocation;
            foreach (Renderer renderer in currentCar.GetComponentsInChildren<Renderer>(true))
            {
                Material[] mats = renderer.materials;

                for (int i = 0; i < mats.Length; i++)
                {
                    if (mats[i].name.StartsWith("Car"))
                    {
                       
                        mats[i].SetColor("_BaseColor", random);
                        
                    }
                }

                renderer.materials = mats;
            }
        }
    }
}
