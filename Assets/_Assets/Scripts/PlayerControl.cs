using System.IO;
using UnityEngine;
using TMPro;

public class PlayerControl : MonoBehaviour
{
    private string savePath;
    private Color _color;
    [SerializeField] private KeyCode moveUp;
    [SerializeField] private KeyCode moveDown;
    public Vector3 position;
    [SerializeField] private float speed;
    private Rigidbody _rigidbody;
    public TextMeshProUGUI positionText;

    // Start is called before the first frame update
    void Start()
    {
        savePath = Application.persistentDataPath + "/playerPosition.json";
        _rigidbody = GetComponent<Rigidbody>();
        _color = GetComponent<MeshRenderer>().material.color;
        Debug.Log("Game Started");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPosition = GetCurrentPosition();
        PlayerMovement();
    }

    void PlayerMovement()
    {
        bool pressedUp = Input.GetKey(this.moveUp);
        bool pressedDown = Input.GetKey(this.moveDown);

        
        if (pressedUp)
        {
            _rigidbody.velocity = Vector3.forward * speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (pressedDown)
        {
            _rigidbody.velocity = Vector3.back * speed;
        }
        if(!pressedDown && !pressedUp)
        {
            _rigidbody.velocity = Vector3.zero;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pos"))
        {
            other.GetComponent<Renderer>().material.color = Color.red;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pos"))
        {
            other.GetComponent<Renderer>().material.color = Color.white;
        }
    }

    public Vector3 GetCurrentPosition()
    {
        // Return the player's current position
        return transform.position;
    }
    
    public void SavePosition()
    {
        position = transform.position;
        string json = JsonUtility.ToJson(position);
        File.WriteAllText(savePath, json);
        Debug.Log("Position Saved: " + json);
    }

    public void LoadPosition()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            position = JsonUtility.FromJson<Vector3>(json);
            transform.position = position;
            DataPersistence.Instance.playerPosition = position;
            Debug.Log("Position Loaded: " + json);
        }
        else
        {
            Debug.Log("Save file not found!");
        }
    }
    
    void OnEnable()
    {
        if (DataPersistence.Instance != null)
        {
            transform.position = DataPersistence.Instance.playerPosition;
        }
    }
}
