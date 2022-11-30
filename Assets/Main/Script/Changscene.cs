using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Changscene : MonoBehaviour
{
    public Sprite SoundON;
    public Sprite SoundOFF;

    public Button SoundControllButton;
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void LoadScene(string TargetScene)
    {
        SceneManager.LoadScene(TargetScene, LoadSceneMode.Single);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);


    }

    public void SoundONorOFF(GameObject BGM)
    {
        if (!BGM.GetComponent<AudioSource>().mute) 
        {
            BGM.GetComponent<AudioSource>().mute=true;
            SoundControllButton.GetComponent<Image>().sprite = SoundON;

        }
        else
        {
            BGM.GetComponent<AudioSource>().mute = false;
            SoundControllButton.GetComponent<Image>().sprite = SoundOFF ;

        }
     

    }
    public void Exit()
    {
        Application.Quit();
    }
}
