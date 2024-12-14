using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeVisible : MonoBehaviour
{
    [SerializeField] GameObject setting;
    [SerializeField] GameObject bulletin;
    [SerializeField] GameObject gameManagerHolder;
    [SerializeField] Material settingMaterial;
    [SerializeField] Material bulletinMaterial;
    Material startingMaterial;
    [SerializeField] Material visibleMaterial;
    bool isVisible;
    GameManager gameManager;
    // Start is called before the first frame update

    void Start()
    {
        startingMaterial = GetComponent<Material>();
        gameManager = gameManagerHolder.GetComponent<GameManager>();

    }
    void Update()
    {
        settingMaterial = setting.GetComponent<Renderer>().material;
        bulletinMaterial = bulletin.GetComponent<Renderer>().material;
        if (settingMaterial.name == bulletinMaterial.name) // if their names match (because they are instances)
        {
            GetComponent<Renderer>().material = visibleMaterial; //apply selected visible material
            isVisible = true;
        }
        else
        {
            GetComponent<Renderer>().material = startingMaterial;
            isVisible = false;
        }
    }

    void OnMouseDown()
    {
        if (isVisible)
        {
            gameManager.WinGame();   
        }
    }
}
