using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    // variables that'd be used as multipliers
    public float moveSpeed = 10f;
    public float rotateSpeed = 75f;
    public float jumpVelocity = 5f;
    public float distanceToGround = 0.1f;
    public float bulletSpeed = 100f;

    public LayerMask groundLayer;
    public GameObject bullet;

    // variables that will hold input for the player
    private float vInput;
    private float hInput;

    private Rigidbody _rb;
    private CapsuleCollider _col;
    private GameBehaviour _gameManager;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _col = GetComponent<CapsuleCollider>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameBehaviour>();
    }

    void Update()
    {
        vInput = Input.GetAxis("Vertical") * moveSpeed;
        hInput = Input.GetAxis("Horizontal") * rotateSpeed;

        if (isGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
        }
        //this.transform.Translate(Vector3.forward * vInput * Time.deltaTime);
        //this.transform.Rotate(Vector3.up * hInput * Time.deltaTime);
    }
    private void FixedUpdate()
    {
        //declaring variable to store rotation
        Vector3 rotation = Vector3.up * hInput;
        // calculating angle of rotation in Euler angles
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);

        // moving player
        _rb.MovePosition(this.transform.position + this.transform.forward * vInput * Time.fixedDeltaTime); // fixedDeltaTime for FixedUpdate
        //rotating player
        _rb.MoveRotation(_rb.rotation * angleRot);
        
        // shooting bullets 
        if (Input.GetMouseButtonDown(0))
        {
            GameObject newBullet = Instantiate(bullet, new Vector3(this.transform.position.x + .5f, 
                                    this.transform.position.y, this.transform.position.z +.5f), this.transform.rotation) 
                                    as GameObject;
            Rigidbody bulletRB = newBullet.GetComponent<Rigidbody>();
            bulletRB.velocity = this.transform.forward * bulletSpeed;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Enemy")
        {
            _gameManager.HP -= 1;
        }
    }
    private bool isGrounded()
    {
        Vector3 capsuleBottom = new Vector3(_col.bounds.center.x, _col.bounds.min.y, _col.bounds.center.z);
        bool grounded = Physics.CheckCapsule(_col.bounds.center, capsuleBottom, distanceToGround, 
                                            groundLayer, QueryTriggerInteraction.Ignore);
        return grounded;
    }

}
