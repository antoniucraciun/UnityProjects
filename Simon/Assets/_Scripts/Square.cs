using UnityEngine;

public class Square : MonoBehaviour
{
    public Material mat;
    public GameManager gm;
    public Colors c;
    
    void Start()
    {
        mat = this.GetComponent<Renderer>().material;
        gm = GameManager.instance;
    }

    private void OnMouseOver()
    {
        if (gm.gp == GamePhase.Playing)
            mat.SetFloat("_Smoothness", 0.5f);
    }

    private void OnMouseExit()
    {
        if (gm.gp == GamePhase.Playing)
            mat.SetFloat("_Smoothness", 0f);
    }

    public void ShowColor()
    {
        mat.SetFloat("_Smoothness", 0.5f);
    }

    public void NormalColor()
    {
        mat.SetFloat("_Smoothness", 0f);
    }

    private void OnMouseUp()
    {
        if (gm.gp == GamePhase.Playing)
            gm.colorsGuessed.Add(this);
    }
}
