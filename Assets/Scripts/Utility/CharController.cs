using UnityEngine;

public class CharController : MonoBehaviour
{
    public Light Sun;
    public Light Torch;
    public float MaxSpeed = 50.0f;

    private bool isSunOn = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            var forward = Vector3.forward * MaxSpeed * Time.deltaTime;
            gameObject.GetComponent<CharacterController>().Move(forward);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            isSunOn = !isSunOn;
            Sun.enabled = isSunOn;
            Torch.enabled = !isSunOn;
        }
    }
}
