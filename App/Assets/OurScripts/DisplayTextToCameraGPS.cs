using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayTextToCameraGPS : MonoBehaviour
{
    public Text coordinates;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        coordinates.text = "Lat:" + GetPhoneGPS.Instance.latitudel.ToString() + "\nLon:" + GetPhoneGPS.Instance.longitude.ToString();
    }
}
