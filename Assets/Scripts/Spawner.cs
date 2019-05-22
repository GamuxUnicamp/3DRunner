using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //CONSTANTES
    public const float MIN_WAIT = 0.4f;
    public const float MAX_WAIT = 1.4f;
    // INTS
    public static Spawner instance;
    public GameObject[] smallObstacle;
    public GameObject[] mediumObstacle;
    public GameObject[] bigObstacle;
    public Transform[] smallPos;
    public Transform[] mediumPos;
    public Transform[] bigPos;

    public float speed = 30;
    float speedIncrement = 0.5f;
    public List<GameObject> obstacles = new List<GameObject> ();

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    private void Start(){
        StartCoroutine(SpawnAtTime());
    }

    public void Spawn() {
        int smallIndex = Random.Range(0, smallPos.Length);
        int mediumIndex = Random.Range(0, mediumPos.Length);
        int bigIndex = Random.Range(0, bigPos.Length);
        int randSize = Random.Range(1,9);
        /*
        AQUI SE CUIDA EM DECIDIR QUAL OBJETO SERA SPAWNADO DA NOSSA LISTA PRE FABRICADOS. OS OBJETOS PODEM SER PEQUENOS,
        MEDIOS E GRANDES. OS CASOS SAO LIDADOS NOS CASES. EXISTEM CASOS EM QUE SE SPAWNA APENAS UM OBSTACULO OU DOIS OBSTACULOS,
        UM MEDIO E OUTRO PEQUENO. TAMBEM PODE SER SPAWNADO UM OBSTACULO GRANDE, APENAS.
        */
        speed += speedIncrement * Time.deltaTime;
        if (randSize <= 3) {
            int randObstacle = Random.Range(0, smallObstacle.Length);
            obstacles.Add(Instantiate(smallObstacle[randObstacle], smallPos[smallIndex].position, Quaternion.identity) as GameObject);
            randObstacle = Random.Range(0, smallObstacle.Length);
            int newIndex = smallIndex;
            while(newIndex == smallIndex){
                newIndex = Random.Range(0,3);
            }
            smallIndex = newIndex;
            int willSpawnMore = Random.Range(0,2);
            if (willSpawnMore == 1) {
                obstacles.Add(Instantiate(smallObstacle[randObstacle], smallPos[smallIndex].position, Quaternion.identity) as GameObject);
            }
        } else if (randSize <= 6) {
            int randObstacle = Random.Range(0, mediumObstacle.Length);
            obstacles.Add(Instantiate(mediumObstacle[randObstacle], mediumPos[mediumIndex].position, Quaternion.identity) as GameObject);
        } else {
            int randObstacle = Random.Range(0, bigObstacle.Length);
            obstacles.Add(Instantiate(bigObstacle[randObstacle], bigPos[bigIndex].position, Quaternion.identity) as GameObject);
        }
    }

    public void DestroyAll() {
        foreach (GameObject _obstacles in obstacles)
        {
            Destroy(_obstacles);
        }
        obstacles.Clear();
    }

    public void DestroyObstacle(GameObject _obstacle) {
        if (obstacles.Contains(_obstacle)) {
            obstacles.Remove(_obstacle);
            Destroy(_obstacle);
        }
        else {
            return;
        }
    }

    private IEnumerator SpawnAtTime(){
        while(true) {
            float waitTime = Random.Range(MIN_WAIT,MAX_WAIT);
            Spawn();
            yield return new WaitForSeconds(waitTime);
        }
    }

}
