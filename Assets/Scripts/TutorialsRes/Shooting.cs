using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject projectileObj;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            Instantiate(projectileObj, this.transform.position, this.transform.rotation);
    }
}
