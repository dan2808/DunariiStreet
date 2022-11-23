using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    private CharacterAnimation player_Animation;
    private Rigidbody myBody;

    public float walk_Speed = 2f;
    public float z_Speed = 1f;

    private float rotation_Y = -90f;
    private float rotation_speed = 15f;


    // Start is called before the first frame update
    void Awake()
    {
        myBody = GetComponent<Rigidbody>();
        player_Animation = GetComponentInChildren<CharacterAnimation>();
    }
    /// <summary>
    /// Update is called once per frame // moving with transform
    /// </summary>
    void Update()
    {
        RotatePlayer();
        AnimatePlayerWalk();
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// Any code that has to do with physics calculation
    /// </summary>
    void FixedUpdate()
    {
        DetectMovement();
    }

    void DetectMovement()
    {
        // getting velocity vector input // velocity(x,y,z) = (speedX * direction.x, SpeedY * direction.y[= 0 ->in this case] , speedZ * direction.z )
        Vector3 input = new Vector3(
            Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) * (-walk_Speed),
            myBody.velocity.y,
            Input.GetAxisRaw(Axis.VERTICAL_AXIS) * (-z_Speed));

        // magnitude = sqrt (x^2 + y^2 + z^2)
        // to tackle the horizontal speed problem that would makes it greater that speedX or speedZ 
        // clamping to the max between speedX and speedZ since the speedY = 0
        myBody.velocity = Vector3.ClampMagnitude(input, Mathf.Max(z_Speed, walk_Speed));

        //Debug.Log($"{myBody.velocity.magnitude}");
        //Debug.Log($"HORIZONTAL_AXIS : {Input.GetAxisRaw(Axis.HORIZONTAL_AXIS)} VERTICAL_AXIS : {Input.GetAxisRaw(Axis.VERTICAL_AXIS)}");
    } //movement

    void RotatePlayer()
    {
        if (Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) > 0)
        {
            transform.rotation = Quaternion.Euler(0f, -Mathf.Abs(rotation_Y), 0f);

        }
        else if (Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) < 0)
        {
            transform.rotation = Quaternion.Euler(0f, Mathf.Abs(rotation_Y), 0f);
        }
    } //rotation

    void AnimatePlayerWalk()
    {
        if (Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) != 0 || Input.GetAxisRaw(Axis.VERTICAL_AXIS) != 0)
        {
            player_Animation.Walk(true);
        }
        else
        {
            player_Animation.Walk(false);

        }
    } //animate player walk

} // class
