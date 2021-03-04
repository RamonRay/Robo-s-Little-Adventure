using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowingbodyParts : MonoBehaviour
{
    public Renderer m_renderer;
    private Material[] materials;
    private Color[] colors;
    private bool isGlowing = true;
    // Start is called before the first frame update
    void Start()
    {
        materials = m_renderer.materials;
        colors = new Color[materials.Length];
        isGlowing = true;
        for (int i=0;i<colors.Length;i++)
        {
            colors[i] = materials[i].color;
            Debug.Log(colors[i]);
        }
        StartCoroutine("GlowingEffect");
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    IEnumerator GlowingEffect()
    {
        int i = 0;
        float t = 0;
        while (true)
        {
            while (t < 1)
            {
                for (i = 0; i < colors.Length; i++)
                {
                    materials[i].SetColor("_Color", Color.Lerp(colors[i], Color.white, t));
                }
                t += 0.01f;
                yield return new WaitForSeconds(0.01f);
            }
            while (t > 0)
            {
                for (i = 0; i < colors.Length; i++)
                {
                    materials[i].SetColor("_Color", Color.Lerp(colors[i], Color.white, t));
                }
                t -= 0.01f;
                yield return new WaitForSeconds(0.01f);
            }
        }

    }
}
