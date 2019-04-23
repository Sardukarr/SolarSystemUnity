using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlanetMenager : MonoBehaviour
{
    public GameObject planet;
    public List<GameObject> planets;
    public Transform Sun;
    public Transform SolarSystem;
    public float spawnTime = 1f;
    public float MaxPosition=100f;
 //   public float MaxEllipseX = 100f;
  //  public float MaxEllipseY = 100f;
  //  public float MaxPeriod = 20f;
 //   public float MinPeriod = 5f;

    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }


    void Spawn()
    {
        //float PosX = Random.Range(Sun.localScale.x, MaxPosition);
        //float PosZ = Random.Range(Sun.localScale.y, MaxPosition);

        //float EllipseX = Random.Range(Sun.localScale.x, MaxEllipseX);
        //float EllipseY = Random.Range(Sun.localScale.y, MaxEllipseY);

        var newPlanet = Instantiate(planet, new Vector3(0,0,0), new Quaternion(0,0,0,0));
        planets.Add(newPlanet);
        //newPlanet.transform.parent = SolarSystem;
    }
    private void Update()
    {
        foreach(GameObject item in planets)
        {
            //item.
          //  if(item.)
        }
    }
}
