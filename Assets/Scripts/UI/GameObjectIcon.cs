using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameObjectIcon : MonoBehaviour
{
    [SerializeField]
    Image image;

    private MiniMap miniMap;

    // Start is called before the first frame update
    void Start()
    {
        miniMap = FindObjectOfType<MiniMap>();
        miniMap.AddMapIconModel(gameObject, image);        
    }

    private void OnDestroy()
    {
        miniMap.RemoveGameObjectIcon(gameObject);
    }
}
