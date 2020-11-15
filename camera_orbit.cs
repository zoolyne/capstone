using UnityEngine;

public class camera_orbit : MonoBehaviour
{

    private Transform xCamera;
    private Transform xParent;

    private Vector3 localRotation;

    public float mouseSensitivity = 4f;
    public float orbitDampen = 10f;

    public bool camDisabled = false;
    
    // Start is called before the first frame update
    void Start()
    {
        this.xCamera = this.transform;
        this.xParent = this.transform.parent;
    }

    // Late update allows the scene to render before the camera captures it
    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            camDisabled = !camDisabled;
        }

        if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
        {
            localRotation.x += Input.GetAxis("Mouse X") * mouseSensitivity;
            localRotation.y -= Input.GetAxis("Mouse Y") * mouseSensitivity;

            //prevent the camera from going through the floor or flipping on itself
            localRotation.y = Mathf.Clamp(localRotation.y, 5f, 90f);
        }

        Quaternion QT = Quaternion.Euler(localRotation.y, localRotation.x, 0);
        this.xParent.rotation = Quaternion.Lerp(this.xParent.rotation, QT, Time.deltaTime * orbitDampen);


    }
}
