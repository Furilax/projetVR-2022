using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenduTerrain : MonoBehaviour
{
    [SerializeField]
    [Range(1, 50)]
    private int width = 10;

    [SerializeField]
    [Range(1, 50)]
    private int height = 10;

    [SerializeField]
    private float size = 1f;

    [SerializeField]
    private Transform murPrefab = null;

    [SerializeField]
    private Transform solPrefab = null;

    void Start()
    {
        var terrain = GenerateurTerrain.Generate(width, height);
        Draw(terrain);
    }

    private void Draw(MurEtat[,] terrain)
    {
        var sol = Instantiate(solPrefab, transform);
        sol.localScale = new Vector3(width, 1, height);

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                var cellule = terrain[i, j];
                var position = new Vector3(-width/2 + i, 0, -height/2 + j);

                if (cellule.HasFlag(MurEtat.HAUT))
                {
                    var topMur = Instantiate(murPrefab, transform) as Transform;
                    topMur.position = position + new Vector3(0, 0, size / 2);
                    topMur.localScale = new Vector3(size, topMur.localScale.y, topMur.localScale.z);
                }

                if(cellule.HasFlag(MurEtat.GAUCHE))
                {
                    var gaucheMur = Instantiate(murPrefab, transform) as Transform;
                    gaucheMur.position = position + new Vector3(-size / 2, 0, 0);
                    gaucheMur.localScale = new Vector3(size, gaucheMur.localScale.y, gaucheMur.localScale.z);
                    gaucheMur.eulerAngles = new Vector3(0, 90, 0);
                }

                if(i == width -1)
                {
                    if(cellule.HasFlag(MurEtat.DROITE))
                    {
                        var droiteMur = Instantiate(murPrefab, transform) as Transform;
                        droiteMur.position = position + new Vector3(+size / 2, 0, 0);
                        droiteMur.localScale = new Vector3(size, droiteMur.localScale.y, droiteMur.localScale.z);
                        droiteMur.eulerAngles = new Vector3(0, 90, 0);
                    }
                }

                if(j == 0)
                {
                    if (cellule.HasFlag(MurEtat.BAS))
                    {
                        var basMur = Instantiate(murPrefab, transform) as Transform;
                        basMur.position = position + new Vector3(0, 0, -size / 2);
                        basMur.localScale = new Vector3(size, basMur.localScale.y, basMur.localScale.z);
                    }
                }
            }
        }
    }

    void Update()
    {
        
    }
}
