using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class LoadImages : MonoBehaviour
{
    public string path = @"";
    private string directory = @"\ChG\Wallpaper\Images";
    public string fullPath = @"";
    public string[] files;

    Texture2D[] textures;
    Sprite[] sprites;
    public GameObject wallpaperBack;
    public GameObject wallpaperFront;
    Image imgBack;
    Image imgFront;

    IEnumerator coroutineToStart;
    bool changeToFront = true;
    bool changingTofront = true;
    bool changingToBack = false;

    public float imageOnScreen = 5f;
    float duration = 2f;
    float smoothness = 0.02f;

    private void Awake()
    {
        path += System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
        fullPath += path + directory;
        imgBack = wallpaperBack.GetComponent<Image>();
        imgFront = wallpaperFront.GetComponent<Image>();
        LoadAllImages();
    }
    
    void LoadAllImages()
    {
        if (Directory.Exists(fullPath))
        {
            files = Directory.GetFiles(fullPath, "*.jpg");
            StartCoroutine(Load());
        }
        else
        {
            CreateDirectory();
        }
    }

    void CreateDirectory()
    {
        Directory.CreateDirectory(fullPath);
        Debug.Log("Directory created");
    }

    public IEnumerator Load()
    {
        textures = new Texture2D[files.Length];
        sprites = new Sprite[files.Length];

        int i = 0;
        foreach (string textString in files)
        {
            byte[] fileData = File.ReadAllBytes(textString);
            yield return new WaitForEndOfFrame();
            Texture2D tempTexture = new Texture2D(1920, 1080);
            tempTexture.LoadImage(fileData);
            textures[i] = tempTexture;
            sprites[i] = Sprite.Create(tempTexture, new Rect(0, 0, 1920, 1080), new Vector2(0, 0));
            i++;
        }
        if (sprites.Length > 1)
        {
            wallpaperBack.GetComponent<Image>().sprite = sprites[0];
            wallpaperFront.GetComponent<Image>().sprite = sprites[1];
        }
        yield return null;
    }

    private void Update()
    {
        if (changeToFront && changingTofront)
        {
            changingTofront = false;
            IEnumerator change = ChangeToImageFront();
            StartCoroutine(change);
        }
        else if (!changeToFront && changingToBack)
        {
            changingToBack = false;
            StartCoroutine(ChangeToImageBack());
        }
    }

    public IEnumerator ChangeToImageFront()
    {
        yield return new WaitForSeconds(imageOnScreen);
        float progress = 0;
        float increment = smoothness / duration;
        while (progress < 1)
        {
            imgBack.color = Color.Lerp(new Color(imgBack.color.r,
                                                    imgBack.color.g,
                                                    imgBack.color.b,
                                                    1),
                                        new Color(imgBack.color.r,
                                                    imgBack.color.g,
                                                    imgBack.color.b,
                                                    0),
                                        progress);

            imgFront.color = Color.Lerp(new Color(imgFront.color.r,
                                                    imgFront.color.g,
                                                    imgFront.color.b,
                                                    0),
                                        new Color(imgFront.color.r,
                                                    imgFront.color.g,
                                                    imgFront.color.b,
                                                    1),
                                                    progress);
            progress += increment;
            yield return new WaitForSeconds(smoothness);
        }
        changeToFront = false;
        changingToBack = true;
        Debug.Log("end change to front");
        yield return new WaitForEndOfFrame();
    }

    public IEnumerator ChangeToImageBack()
    {
        yield return new WaitForSeconds(imageOnScreen);
        float progress = 0;
        float increment = smoothness / duration;
        while (progress < 1)
        {
            imgFront.color =
                Color.Lerp(new Color(imgFront.color.r,
                                        imgFront.color.g,
                                        imgFront.color.b,
                                        1),
                            new Color(imgFront.color.r,
                                        imgFront.color.g,
                                        imgFront.color.b,
                                        0),
                            progress);

            imgBack.color =
                Color.Lerp(new Color(imgBack.color.r,
                                        imgBack.color.g,
                                        imgBack.color.b,
                                        0),
                            new Color(imgBack.color.r,
                                        imgBack.color.g,
                                        imgBack.color.b,
                                        1),
                            progress);
            progress += increment;
            yield return new WaitForSeconds(smoothness);
        }
        changeToFront = true;
        changingTofront = true;
        Debug.Log("end change to back");
        yield return new WaitForEndOfFrame();
    }
}
