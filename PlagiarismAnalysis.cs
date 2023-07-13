using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem
{
    public static class PlagiarismAnalysis
    {
        public static float AnalyzeMatchingScore(string[] vertices, Tuple<string, string, float>[] edges, string startVertex)
        {
            float sum = 0.0f;
            float edge = 0.0f;
            float average_score = 0.0f;

            Queue<string> graph_Queue = new Queue<string>();

            Dictionary<string, List<KeyValuePair<string, float>>> vertix = new Dictionary<string, List<KeyValuePair<string, float>>>(vertices.Length);
            Dictionary<string, char> ver_color = new Dictionary<string, char>(vertices.Length);
          
            KeyValuePair<string, float> keyValuePair;

            for (int i = 0; i < vertices.Length; i++)
            {
                vertix[vertices[i]] = new List<KeyValuePair<string, float>>();
            }

            for (int i = 0; i < edges.Length; i++)
            {
                keyValuePair = new KeyValuePair<string, float>(edges[i].Item2, edges[i].Item3);
                vertix[edges[i].Item1].Add(keyValuePair);
                keyValuePair = new KeyValuePair<string, float>(edges[i].Item1, edges[i].Item3);
                vertix[edges[i].Item2].Add(keyValuePair);
            }

            for (int i = 0; i < vertices.Length; i++)
            {
                // ver_color[vertices[i]] = 'w';
                ver_color.Add(vertices[i], 'w');
            }

            ver_color[startVertex] = 'g'; //make color of start_vertice gery
            graph_Queue.Enqueue(startVertex);
            string x = " ";
            while (graph_Queue.Count > 0)
            {
                x = graph_Queue.Dequeue();
                foreach (var v in vertix[x])
                {

                    if (ver_color[v.Key] == 'w') //white
                    {
                        graph_Queue.Enqueue(v.Key);
                        ver_color[v.Key] = 'g'; //make color of vertice gery
                        sum += v.Value;
                        edge++;
                    }
                    else if (ver_color[v.Key] == 'g') 
                    {
                        sum += v.Value;
                        edge++;

                    }
                }
                ver_color[x] = 'b'; //make color of vertice black
            }

            average_score = sum / edge;
            return average_score;
        }
    }

}