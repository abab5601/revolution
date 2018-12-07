using UnityEngine;
using System.Collections;

/// MouseLook rotates the transform based on the mouse delta.
/// Minimum and Maximum values can be used to constrain the possible rotation

/// To make an FPS style character:
/// - Create a capsule.
/// - Add the MouseLook script to the capsule.
///   -> Set the mouse look to use LookX. (You want to only turn character but not tilt it)
/// - Add FPSInputController script to the capsule
///   -> A CharacterMotor and a CharacterController component will be automatically added.

/// - Create a camera. Make the camera a child of the capsule. Reset it's transform.
/// - Add a MouseLook script to the camera.
///   -> Set the mouse look to use LookY. (You want the camera to tilt up and down like a head. The character already turns.)
[AddComponentMenu("Camera-Control/Mouse Look")]
public class MouseLook : MonoBehaviour
{

    public enum RotationAxes {  MouseX = 1, MouseY = 2 }
    public RotationAxes axes ;
    public User User;
    public World world;
    public float minimumX = -360F;
    public float maximumX = 360F;

    public float minimumY = -60F;
    public float maximumY = 60F;
    [Header("第一人稱模式?")]
    public bool First_person=false;
     float rotationX = 0F;


    private int mouse = -1;
    private void Start()
    {
        if (!First_person && axes == RotationAxes.MouseX)
        {
            transform.localPosition = new Vector3
                           (
                          0,/*x*/
                         -world.Lens_distance * (float)System.Math.Sin(-User.XY.Camera * 3.14 / 180)+5,/*y*/
                         -world.Lens_distance * (float)System.Math.Cos(-User.XY.Camera * 3.14 / 180)/*z*/
                          );
            transform.rotation = Quaternion.LookRotation(transform.parent.position - transform.position+new Vector3(0,2,0));
        }
    }

    void Update()
    {

        if (mouse != -1)
        {
            Debug.Log(true);
            if (axes == RotationAxes.MouseX)
            {

                if (First_person)//第一人稱模式
                {
                    User.XY.Camera += (Input.GetTouch(mouse).deltaPosition.y * (world.Sensitivity * Time.deltaTime));
                    User.XY.Camera = Mathf.Clamp(User.XY.Camera, minimumY, maximumY);

                    transform.localEulerAngles=(new Vector3(-User.XY.Camera, transform.localEulerAngles.y, 0));
                }
                else //第三人稱模式
                {
                    User.XY.Camera += (-Input.GetTouch(mouse).deltaPosition.y * (world.Sensitivity * Time.deltaTime));
                    User.XY.Camera = Mathf.Clamp(User.XY.Camera, minimumY + 10, maximumY - 10);
                    transform.localPosition = new Vector3
                        (
                       0,/*x*/
                      - world.Lens_distance * (float)System.Math.Sin(-User.XY.Camera * 3.14 / 180+5),/*y*/
                      - world.Lens_distance * (float)System.Math.Cos(-User.XY.Camera * 3.14 / 180)/*z*/
                       );
                    transform.rotation = Quaternion.LookRotation(transform.parent.position - transform.position + new Vector3(0, 2, 0));

                }
            }
            else
            {

                transform.rotation = Quaternion.Euler(new Vector3
                    (
                    transform.localEulerAngles.x,
                   rotationX += (Input.GetTouch(mouse).deltaPosition.x * (world.Sensitivity * Time.deltaTime)),
                     transform.localEulerAngles.z

                    ));


            }
           

        }



    }
    // 冻结刚体的旋转功能


    void stare()
    {
        // Make the rigid body not change rotation
        if (GetComponent<Rigidbody>())
        {
            GetComponent<Rigidbody>().freezeRotation = true;

        }

    }
    public void Bool(bool Bool)
    {
        
        if (Bool && mouse == -1)
            mouse = Input.touchCount - 1;
        else if(!Bool)

            mouse = -1;


        
    }
    
}
