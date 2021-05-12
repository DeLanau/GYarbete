using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
    
public class ball_2 : MonoBehaviour {

    /**
    Konstanter för vidare berakningar
    **/

    private static float Vx = 20f;
    private static float Vy = 20f; 
    private static float Vz = 5f;

    private static Vector3 v0 = new Vector3(Vx, Vy, Vz); 
    private static Vector3 omega = new Vector3(0f, 5f, 5f);

    private static float radius = 0.105f; //0.105
    private static float massa = 0.3056f; //0.3056
    private static float rho = 1.2f; //1.2

    private float dt = 0.01f;
    private float x = 0f;
    private float y = 0f;
    private float z = 0f;

    private static List<float> maxY = new List<float>();
    private static bool luft = true; //luftmotsånd
    private static List<float> averageV = new List<float>();


    private float timeStart;

    void Start() {

        gameObject.transform.position = new Vector3(0, 0, 0);

        maxY.Clear();
        averageV.Clear();
        timeStart = Time.time;
    }

    // Uppdatering kallas en gång per ram
    void Update() {
        
        if (gameObject.transform.position.y >= 0) {
            
            /**
            Eulers stegmetod användas för att berakna hastighet per axel och sedan få position på bollen. F = a * m
            a = F / massa 
            **/

            Vx += MainScript.Instance.KraftX(rho, radius, omega, v0, luft) /massa * dt;
            Vy += MainScript.Instance.KraftY(rho, radius, omega, v0, luft, massa) / massa * dt;
            Vz += MainScript.Instance.KraftZ(rho, radius, omega, v0, luft) /massa * dt; 

            x += Vx * dt;
            y += Vy * dt;
            z += Vz * dt;

            maxY.Add(y);

            float v = Mathf.Pow(Vx, 2) + Mathf.Pow(Vy, 2) + Mathf.Pow(Vz, 2);
            averageV.Add(Mathf.Sqrt(v));

            gameObject.transform.position = new Vector3(x, y, z);

        } else {

            enabled = false; 
            gameObject.transform.position = new Vector3(x, y, z);
    
        }
    }

    void OnDisable() {
        
        float flygtid = Time.time - timeStart;

        Debug.Log("<color=red>Boll nr2 har flygtid: " + flygtid.ToString("0.##") + " Max höjden: " + maxY.Max().ToString("0.##") + " Sträckan: " + x.ToString("0.##") + " MedelHastighet: " + averageV.Average() + "</color>");
        timeStart = 0;
    }
}