using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MainScript : MonoBehaviour {

    public static MainScript Instance;

    void Awake() {

        Instance = this;

    }

    public float KraftX(float rho, float r, Vector3 omega, Vector3 v0, bool luft){

        float A = Mathf.PI * r * r;
        Vector3 norm = Vector3.Normalize(v0);

        if(luft){

            return -rho * A * norm.x * 0.14f * v0.x / 2 + rho * A * 0.16f * Vector3.Cross(omega, v0).x;

        }else{ 

            return  rho * A * 0.16f * Vector3.Cross(omega, v0).x;

        }
    }

    public float KraftY(float rho, float r, Vector3 omega, Vector3 v0, bool luft, float massa){

        float A = Mathf.PI * r * r;
        Vector3 norm = Vector3.Normalize(v0);

        if(luft){

            return massa * Physics.gravity.y -rho * A * norm.y * 0.14f * v0.y / 2 + rho * A * 0.16f * Vector3.Cross(omega, v0).y;

        }else { 

            return  massa * Physics.gravity.y + rho * A * 0.16f * Vector3.Cross(omega, v0).y;

        }
    }

    public float KraftZ(float rho, float r, Vector3 omega, Vector3 v0, bool luft){

        float A = Mathf.PI * r * r;
        Vector3 norm = Vector3.Normalize(v0);

        if(luft){

            return -rho * A * norm.z * 0.14f * v0.z / 2 + rho * A * 0.16f * Vector3.Cross(omega, v0).z;

        }else { 

            return  rho * A * 0.16f * Vector3.Cross(omega, v0).z;

        }
    }

}
