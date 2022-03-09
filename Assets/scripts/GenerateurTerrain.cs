using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MurEtat
{
    //0000 = Pas de mur
    //1111 = gauche, droite, haut, bas
    GAUCHE = 1, // 0001
    DROITE = 2, // 0010
    HAUT = 4, // 0100
    BAS = 8, // 1000

    VISITE = 128, 
}

public struct Position
{
    public int X;
    public int Y;
}

public struct Voisin
{
    public Position Position;
    public MurEtat MurPartage;
}

public static class GenerateurTerrain
{
    private static MurEtat[,] AppliquerBacktracker(MurEtat[,] terrain, int width, int height)
    {
        // here we make changes
        var rng = new System.Random(/*seed*/);
        var positionStack = new Stack<Position>();
        var position = new Position { X = rng.Next(0, width), Y = rng.Next(0, height) };

        terrain[position.X, position.Y] |= MurEtat.VISITE;
        positionStack.Push(position);

        while (positionStack.Count > 0)
        {
            var current = positionStack.Pop();
            var voisins = TrouverVoisinNonVisite(current, terrain, width, height);

            if (voisins.Count > 0)
            {
                positionStack.Push(current);

                var randIndex = rng.Next(0, voisins.Count);
                var voisinHasard = voisins[randIndex];

                var nPosition = randomNeighbour.Position;
                maze[current.X, current.Y] &= ~randomNeighbour.SharedWall;
                maze[nPosition.X, nPosition.Y] &= ~GetOppositeWall(randomNeighbour.SharedWall);
                maze[nPosition.X, nPosition.Y] |= WallState.VISITED;

                positionStack.Push(nPosition);
            }
        }

    private static List<Voisin> TrouverVoisinNonVisite(Position p, MurEtat[,] terrain, int width, int height)
    {
        var list = new List<Voisin>();

        if(p.X > 0) // Gauche
        {
            if(!terrain[p.X - 1, p.Y].HasFlag(MurEtat.VISITE))
            {
                list.Add(new Voisin
                {
                    Position = new Position
                    {
                        X = p.X - 1,
                        Y = p.Y
                    },
                    MurPartage = MurEtat.GAUCHE
                });
            }
        }

        if (p.Y > 0) // Bas
        {
            if (!terrain[p.X, p.Y - 1].HasFlag(MurEtat.VISITE))
            {
                list.Add(new Voisin
                {
                    Position = new Position
                    {
                        X = p.X,
                        Y = p.Y - 1
                    },
                    MurPartage = MurEtat.BAS
                });
            }
        }

        if (p.Y < height - 1) // Haut
        {
            if (!terrain[p.X, p.Y + 1].HasFlag(MurEtat.VISITE))
            {
                list.Add(new Voisin
                {
                    Position = new Position
                    {
                        X = p.X,
                        Y = p.Y + 1
                    },
                    MurPartage = MurEtat.HAUT
                });
            }
        }

        if (p.X < width -1) // DROITE
        {
            if (!terrain[p.X + 1, p.Y].HasFlag(MurEtat.VISITE))
            {
                list.Add(new Voisin
                {
                    Position = new Position
                    {
                        X = p.X + 1,
                        Y = p.Y
                    },
                    MurPartage = MurEtat.DROITE
                });
            }
        }

        return list;
    }

    public static MurEtat[,] Generate(int width, int height)
    {
        MurEtat[,] terrain = new MurEtat[width, height];
        MurEtat initial = MurEtat.DROITE | MurEtat.GAUCHE | MurEtat.HAUT | MurEtat.BAS;

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                terrain[i, j] = initial;
            }
        }

        return terrain;
    }
}
