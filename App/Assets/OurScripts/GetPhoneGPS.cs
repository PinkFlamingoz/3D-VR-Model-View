using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPhoneGPS : MonoBehaviour
{
    public static GetPhoneGPS Instance { set; get; }

    public float latitudel;
    public float longitude;

    // Start is called before the first frame update
    private void Start()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        StartCoroutine(StartLocationService());
    }

    private IEnumerator StartLocationService()
    {
        if (!Input.location.isEnabledByUser)
        {
            Debug.Log("User has not enabled GPS");
            yield break;
        }

        Input.location.Start();
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        if (maxWait <= 0)
        {
            Debug.Log("Timed out");
            yield break;
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("Unable to determin device location");
            yield break;
        }

        latitudel = Input.location.lastData.latitude;
        longitude = Input.location.lastData.longitude;

        yield break;
    }

    // Update is called once per frame
    void Update()
    {

    }
}