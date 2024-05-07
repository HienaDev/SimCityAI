using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using static UnityEngine.Timeline.AnimationPlayableAsset;

public class MoveCamera : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float shiftSpeedScale;
    private float shiftSpeed;
    private float defaultSpeed;

    [SerializeField] private KeyCode left;
    [SerializeField] private KeyCode right;
    [SerializeField] private KeyCode down;
    [SerializeField] private KeyCode up;
    [SerializeField] private KeyCode back;
    [SerializeField] private KeyCode foward;

    [SerializeField] private float verticalMouseSensitivity;
    [SerializeField] private float horizontalMouseSensitivity;

    private Vector3 velocity;

    private Rigidbody rb;

    private Transform cam;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        cam = Camera.main.transform;

        shiftSpeed = speed * shiftSpeedScale;
        defaultSpeed = speed;

    }

    // Update is called once per frame
    void Update()
    {

        Move();
        RotateCamera();

    }

    private void Move()
    {
        velocity = Vector3.zero;

        if (Input.GetKey(KeyCode.LeftShift)) speed = shiftSpeed;
        else speed = defaultSpeed;

        if (Input.GetKey(left)) velocity.x = -speed;
        if (Input.GetKey(right)) velocity.x = speed;


        if (Input.GetKey(back)) velocity.z = -speed;
        if (Input.GetKey(foward)) velocity.z = speed;


        if (Input.GetKey(up)) velocity.y = speed;
        if (Input.GetKey(down)) velocity.y = -speed;

        transform.position += cam.TransformDirection(velocity) * Time.deltaTime;

        //rb.velocity = cam.TransformDirection(velocity);
    }

    private void RotateCamera()
    {
        if (Input.GetMouseButton(1))
        {
            HideCursor();

            Vector3 rotation = cam.localEulerAngles;
   

            rotation.x -= Input.GetAxis("Mouse Y") * verticalMouseSensitivity;
            rotation.y += Input.GetAxis("Mouse X") * horizontalMouseSensitivity;

       

            cam.localEulerAngles = rotation;
        }
        else
        {
            ShowCursor();
        }
    }




    private void HideCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ShowCursor()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void LockCursorCenter()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }
}
