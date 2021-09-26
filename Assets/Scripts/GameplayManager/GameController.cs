using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    int currentCarID;
    int povInt;
    public PovState currentPovState;
    public PovState GetPovState()
    {
        switch (povInt)
        {
            case 0:
                return PovState.FPS;
            case 1:
                return PovState.TPS;
        }
        return PovState.FPS;
    }
    public List<GameObject> carPrefabs;
    [SerializeField] private CameraSwitch startPov;
    private PlayerRespawn playerRespawn;
    [SerializeField] private TileManager tileManager;
    [SerializeField] private TimeControl timeControl;
    public GameObject currentCar;
    [SerializeField] private Transform startPonit;
    public GameObject collectAble;
    public GameObject ready;
    public GameObject go;
    public GameObject resultscoreManager;
    // Start is called before the first frame update
    void Start()
    {
        currentCarID = PlayerPrefs.GetInt("carID");
        povInt = PlayerPrefs.GetInt("PovState");
        currentPovState = GetPovState();
        playerRespawn = GetComponent<PlayerRespawn>();
        timeControl = GetComponent<TimeControl>();
        InstantiateCar();
        timeControl.carController = currentCar.GetComponent<CarController>();
        timeControl.scoreManager = currentCar.GetComponent<ScoreManager>();
        collectAble.SetActive(true);
        resultscoreManager.SetActive(true);
        StartCoroutine(DelayStart(3));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void InstantiateCar()
    {
            for (int i = 0; i < carPrefabs.Count; i++)
            {
                if (i == currentCarID)
                {
                   // startPov = carPrefabs[i].GetComponent<CameraSwitch>();
                   // carPrefabs[i].SetActive(true);
                GameObject newCar = Instantiate(carPrefabs[i],startPonit.transform.position,Quaternion.identity);
                    currentCar = newCar;
                CarCamera carCam = newCar.GetComponent<CarCamera>();
                startPov.FPS_cam = carCam.fpsTranfrom;
                startPov.TPS_cam = carCam.tpsTransform;
                startPov.target = carCam.LookAtTranform;
                startPov.offset = carCam.tpsTransform.position;
                startPov.cameraState = GetPovState();
                playerRespawn.playerTransform = newCar.GetComponent<Transform>();
                playerRespawn.playerController = newCar.GetComponent<CarController>();
                tileManager.playerTransform = newCar.GetComponent<Transform>();
                }
              /*  else
                {
                    carPrefabs[i].SetActive(false);
                }*/
            }
    }
    private IEnumerator DelayStart(float waitTime)
    {
            playerRespawn.playerController.enabled = false;
            timeControl.enabled = false;
            ready.SetActive(true);
            yield return new WaitForSeconds(waitTime);
            playerRespawn.playerController.enabled = true;
            timeControl.enabled = true;
            ready.SetActive(false);
            go.SetActive(true);
            yield return new WaitForSeconds(waitTime / waitTime);
            go.SetActive(false);
    }
}
