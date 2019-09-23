using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour
{
    public Color color = new Color(1, 1, 1);
    public Image image;
    public Material ghostBlockMaterial;

    public int imageNum = 0;
    public int imageMaxNum;

    void Start()
    {
        image.color = color;
        ghostBlockMaterial.mainTexture = Resources.Load<Texture>(imageNum.ToString());
    }

    void Update()
    {
        ChangeBlockColor();
        ChangeBlockImage();
    }

    public void ChangeBlockImage()
    {
        float scroll = Input.GetAxisRaw("Mouse ScrollWheel");

        if (scroll != 0)
        {
            if (scroll > 0)
            {
                if (imageNum < imageMaxNum)
                    imageNum++;
                else
                    imageNum = 0;
            }
            if (scroll < 0)
            {
                if (imageNum > 0)
                    imageNum--;
                else
                    imageNum = imageMaxNum;
            }

            image.sprite = Resources.Load<Sprite>(imageNum.ToString());
            ghostBlockMaterial.mainTexture = Resources.Load<Texture>(imageNum.ToString());
        }
    }
    public void ChangeBlockColor()
    {
        if (Input.GetKey(KeyCode.Insert))
            if (color.r < 1)
                color += new Color(1f / 255, 0, 0);
        if (Input.GetKey(KeyCode.Delete))
            if (color.r > 0)
                color += new Color(-1f / 255, 0, 0);

        if (Input.GetKey(KeyCode.Home))
            if (color.g < 1)
                color += new Color(0, 1f / 255, 0);
        if (Input.GetKey(KeyCode.End))
            if (color.g > 0)
                color += new Color(0, -1f / 255, 0);

        if (Input.GetKey(KeyCode.PageUp))
            if (color.b < 1)
                color += new Color(0, 0, 1f / 255);
        if (Input.GetKey(KeyCode.PageDown))
            if (color.b > 0)
                color += new Color(0, 0, -1f / 255);

        image.color = color;
    }
}
