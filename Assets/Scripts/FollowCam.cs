using UnityEngine;

public class FollowCam : MonoBehaviour
{
    static public GameObject POI;

    [Header("Set in Inspector")]
    public float easign = 2f;

    [Header("Set Dynamically")]
    public float camZ;

    public Vector2 minXY = Vector2.zero;
    void Awake()
    {
        camZ = transform.position.z;

    }

    void FixedUpdate()
    {
        Vector3 destination;
        if (POI == null)
        {
            destination = Vector3.zero;
        }
        else
        {
            destination = POI.transform.position;
            if (POI.tag == "Projectile")
            {
                if (POI.GetComponent<Rigidbody>().IsSleeping())
                {
                    POI = null;
                    return;
                }
            }
        }

        destination.x = Mathf.Max(destination.x, minXY.x);
        destination.y = Mathf.Max(destination.y, minXY.y);

        destination = Vector3.Lerp(transform.position, destination, easign);
        destination.z = camZ;
        transform.position = destination;
        Camera.main.orthographicSize = destination.y + 10;
    }
}
