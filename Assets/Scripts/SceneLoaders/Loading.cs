using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    public static int sceneIndex = 1;

    [SerializeField]
    float timeToLoad = 3;
    private float time = 0;

    private Slider loadingBar;
    // Start is called before the first frame update
    void Start()
    {
        loadingBar = GetComponentInChildren<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(time < timeToLoad)
        {
            time += Time.deltaTime;
            loadingBar.value = time / timeToLoad;
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("Bell");
            FindObjectOfType<SceneLoader>().LoadLevel(sceneIndex);
        }
    }
}
