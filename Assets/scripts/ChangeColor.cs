using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    [SerializeField] Material[] altColors; // for changing color
    Material startColor;
    [SerializeField] int currentColorIndex= 0;
    [SerializeField] int numberOfColors;
    private void Start()
    {
        numberOfColors = altColors.Length; // get how many colors there are
    }

    private void IterateColor()
    {
        currentColorIndex++;
        if (currentColorIndex >= numberOfColors) {
            currentColorIndex = 0;
        }
        GetComponent<Renderer>().material = altColors[currentColorIndex];
    }

    private void OnMouseDown()
    {
        IterateColor();
    }


}
