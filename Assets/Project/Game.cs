using System.Collections.Generic;
using UnityEngine;

namespace Assets
{
    public class Game : MonoBehaviour {
        public int N;
        public GameObject Cube;
        private readonly List<List<List<GameObject>>> _goList = new List<List<List<GameObject>>>();
        private GameOfLife _gol;
        private float _time;
        void Awake()
        {
            _time = Time.time;
            _gol = new GameOfLife(N);
            InitCubes();
            Draw();
        }

        void Update()
        {
            if (_time + 0.25f < Time.time)
            {
                _gol.Next();
                Draw();
                _time = Time.time;
            }
        }
        

        void InitCubes()
        {
            for (int i = 0; i < N; i++)
            {
                _goList.Add(new List<List<GameObject>>());
                for (int j = 0; j < N; j++)
                {
                    _goList[i].Add(new List<GameObject>());
                    for (int k = 0; k < N; k++)
                    {
                        var go = Instantiate(Cube);
                        go.transform.position = new Vector3(i, j, k);
                        _goList[i][j].Add(go);
                    }
                }
            }
        }

        void Draw()
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    for (int k = 0; k < N; k++)
                    {
                        var mr = _goList[i][j][k].GetComponent<MeshRenderer>();
                        mr.enabled = _gol.Grid[i][j][k] == 1;
                    }
                }
            }
        }
    }
}
