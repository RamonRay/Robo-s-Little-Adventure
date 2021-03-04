using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YawRollPitcherFinder : MonoBehaviour
{

    public float roll, yaw, pitch;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var x = transform.rotation.x;
        var y = transform.rotation.y;
        var z = transform.rotation.z;
        var w = transform.rotation.w;


        //Classic roll/pitch/yaw value calculation algorithm found at https://answers.unity.com/questions/416169/finding-pitchrollyaw-from-quaternions.html
        roll = Mathf.Atan2(2 * y * w + 2 * x * z, 1 - 2 * y * y - 2 * z * z)  / Mathf.PI * 180;
        pitch = Mathf.Atan2(2 * x * w + 2 * y * z, 1 - 2 * x * x - 2 * z * z) / Mathf.PI * 180;
        yaw = Mathf.Asin(2 * x * y + 2 * z * w) / Mathf.PI * 180;
    }
}
