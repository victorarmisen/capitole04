using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    public GameObject player;

    public static bool CameraOn;
    public static GameObject addition;

    public Vector3 offset2;
    public bool STAGE2_SCOOTER = false;
    
    private float timer = 0.0f;
    public float bobbingSpeed = 0.11f;
    public float bobbingAmount = 0.05f;
    public float midpoint = 1.0f;
    public Transform altura_player;
    private Vector3 cSharpConversion;
    public Transform target;
    public float smooth = 5.0f;
    public Vector3 pos_player;

    void Start()
    {
        addition = new GameObject();
        transform.position = target.position + new Vector3(1, 1.5f, -6.0f);
    }

    void FixedUpdate()
    {
        float waveslice = 0.0f;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        pos_player = target.position + new Vector3(1, 1.5f, -6.0f);
        Vector3 cSharpConversion = Vector3.Lerp(transform.position, pos_player, Time.deltaTime * smooth);
        if (Mathf.Abs(horizontal) == 0 && Mathf.Abs(vertical) == 0)
        {
            timer = 0.0f;
        }
        else
        {
            waveslice = Mathf.Sin(timer);
            timer = timer + bobbingSpeed;
            if (timer > Mathf.PI * 2)
            {
                timer = timer - (Mathf.PI * 2);
            }
        }
        if (waveslice != 0)
        {
            float translateChange = 1.2f * bobbingAmount;
            float totalAxes = Mathf.Abs(horizontal) + Mathf.Abs(vertical);
            totalAxes = Mathf.Clamp(totalAxes, 0.0f, 1.0f);
            translateChange = totalAxes * translateChange;
            transform.position = new Vector3(cSharpConversion.x + translateChange * 0.25f, cSharpConversion.y + translateChange * 0.25f, cSharpConversion.z);
            addition.transform.position = new Vector3(0, 1.1f, 0) + player.transform.position;
        }
        else
        {
            transform.position = new Vector3(cSharpConversion.x, cSharpConversion.y, cSharpConversion.z);
            addition.transform.position = new Vector3(0, 1.1f, 0) + player.transform.position;
        }
    }
}

