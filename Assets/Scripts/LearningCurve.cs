using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearningCurve : MonoBehaviour
{
    public GameObject directionalLight;

    private Transform camTransform;
    private Transform lightTransform;
    void Start()
    {
        camTransform = this.GetComponent<Transform>();
        Debug.Log(camTransform.localPosition);

        //directionalLight = GameObject.Find("Directional Light");
        lightTransform = GameObject.Find("Directional Light").GetComponent<Transform>();
        Debug.Log(lightTransform.localPosition);

        Weapon spear = new Weapon("Spear", 105, 3f); // describes name, damage and range of weapon
        spear.PrintWeaponStats();

        Paladin knight = new Paladin("Sir Sousage", spear);
        knight.PrintStatsInfo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
