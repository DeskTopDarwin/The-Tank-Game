using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSelfDestroy : MonoBehaviour
{
    public float timeBeforSelfDestroy;
    private float currentTimeBeforDestoy;


    // Start is called before the first frame update
    void Start()
    {
        currentTimeBeforDestoy = timeBeforSelfDestroy;
    }

    // Update is called once per frame
    void Update()
    {
        currentTimeBeforDestoy -= Time.deltaTime;

        if (currentTimeBeforDestoy <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
