using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectScene : MonoBehaviour
{

    [SerializeField] private bool returnMenu;
    [SerializeField] private int sceneIndex;

    public void GoToScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
