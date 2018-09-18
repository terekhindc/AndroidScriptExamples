using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPS : MonoBehaviour {

    public static GPS Instance { get; set; }

    void Start () {
        Instance = this;
        StartCoroutine(GPSLocationInput());
    }

    public string Status
    {
        get; private set;
    }

	public float Latitude
    {
        get; private set;
    }

    public float Longitude
    {
        get; private set;
    }

    public float Altitude
    {
        get; private set;
    }

    public float HorizontalAccuracy
    {
        get; private set;
    }

    public float Timestamp
    {
        get; private set;
    }


    IEnumerator GPSLocationInput ()
    {
        // Проверка пользовательского разрешения на получение информации о местоположении
        if (!Input.location.isEnabledByUser)
            yield break;

        // Стартс службы определения местоположения
        Input.location.Start();
        Status = "Подключение...";
        
        // Ожидание инициализации
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // Если сервис не ответил в течение лимита времени
        if (maxWait < 1)
        {
            Status = "Время подключения истекло";
            yield break;
        }

        // Соединение оборвано
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Status = "Недоступна информация о местоположении устройства";
            yield break;
        }
        else
        {
            // Получение данных о местоположении и запись в соответствующие переменные
            Status = "Соединение установленно";
            Latitude = Input.location.lastData.latitude;
            Longitude = Input.location.lastData.longitude;
            Altitude = Input.location.lastData.altitude;
            HorizontalAccuracy = Input.location.lastData.horizontalAccuracy;
            Timestamp = (float)Input.location.lastData.timestamp;
        }

        // Остановка сервиса
        Input.location.Stop();
    }
}
