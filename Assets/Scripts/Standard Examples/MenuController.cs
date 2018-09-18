using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

    public Text GPSText;

	// Use this for initialization
	void Start () {
        InvokeRepeating("SetGPSCoordinates", 1, 2);
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    void SetGPSCoordinates ()
    {
        GPSText.text = "";
        GPSText.text += "\n";
        GPSText.text += "Статус подключения: " + GPS.Instance.Status;
        GPSText.text += "\n";
        GPSText.text += "Широта: " + GPS.Instance.Latitude.ToString();
        GPSText.text += "\n";
        GPSText.text += "Долгота: " + GPS.Instance.Longitude.ToString();
        GPSText.text += "\n";
        GPSText.text += "Высота над уровнем моря: " + GPS.Instance.Altitude.ToString();
    }
}
