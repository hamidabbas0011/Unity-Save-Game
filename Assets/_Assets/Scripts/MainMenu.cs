using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private PlayerControl _playerControl;
    // Start is called before the first frame update
    private void Start()
    {
        PlayerControl _playerControl = GetComponent<PlayerControl>();
    }

    public void OnClickPlay()
    {
        SceneManager.LoadScene(1);
    }

    public void OnCLickLoad()
    {
        if (File.Exists(Application.persistentDataPath + "/playerPosition.json"))
        {
            string json = File.ReadAllText(Application.persistentDataPath + "/playerPosition.json");
            DataPersistence.Instance.playerPosition = JsonUtility.FromJson<Vector3>(json);
        }
        SceneManager.LoadScene(1); 
        
    }
}
