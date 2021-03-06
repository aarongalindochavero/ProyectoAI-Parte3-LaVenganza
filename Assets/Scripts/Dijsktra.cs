﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dijsktra : MonoBehaviour
{

    Queue<BSNode> qv = new Queue<BSNode>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool DSuperSearch(BSNode start, BSNode end)
    {
        Stack<BSNode> ss = new Stack<BSNode>();
        BSNode tmp = start;
        ss.Push(tmp);
        while (tmp)
        {
            //cout << tmp.visitado << endl;
            if (tmp.getData() == end.getData())
            {
                resetVisitados();
                return true;
            }
            else if (tmp.visitado != true)
            {
                tmp.visitado = true;
                qv.Enqueue(tmp);
                ss.Pop();
                for (int i = 0; i < tmp.adyacentes.Count; i++)
                {
                    if (tmp.adyacentes[i].visitado != true)
                    {
                        ss.Push(tmp.adyacentes[i]);
                    }
                }
            }
            else
            {
                ss.Pop();
            }
            if (ss.Peek() == null)
            {
                resetVisitados();
                //cout << "nop" << endl;
                return false;
            }
            tmp = ss.Peek();
        }
        resetVisitados();
        return false;
    }

    public List<BSNode> Dijkstra(BSNode start, BSNode end)
    {
        List<BSNode> pathToVictory = new List<BSNode>();
        if (start != null && end != null)
        {
            if (DSuperSearch(start, end))
            {
                Queue<BSNode> qd = new Queue<BSNode>();
                BSNode tmp = start;
                start.val = 0;
                qd.Enqueue(tmp);
                while (qd.Count > 0)
                {
                    for (int i = 0; i < tmp.adyacentes.Count; i++)
                    {
                        int costeConexion = (int)(tmp.costoAdyacentes[i] + tmp.val);

                        if (tmp.adyacentes[i].val > costeConexion)
                        {
                            tmp.adyacentes[i].val = costeConexion;
                            tmp.adyacentes[i].padre = tmp;
                        }
                        if (tmp.adyacentes[i].visitado == false)
                        {
                            tmp.adyacentes[i].visitado = true;
                            qv.Enqueue(tmp.adyacentes[i]);
                            qd.Enqueue(tmp.adyacentes[i]);
                        }
                        //cout << tmp.adyacentes.at(i).getData() << endl;
                    }
                    tmp = qd.Peek();
                    qd.Dequeue();
                }

                tmp = end;
                do
                {
                    print(tmp.getData());
                    pathToVictory.Add(tmp);
                    tmp = tmp.padre;
                    //cout << tmp.getData() << endl;
                } while (tmp != start);
                print(tmp.getData());
                resetVisitados();
                //cout << end.val << endl;

                return pathToVictory;
            }
        }
        print("no se pudo encontrar un camino");
        return pathToVictory;

    }

    void resetVisitados()
    {
        while (qv.Count > 0)
        {
            qv.Peek().visitado = false;
            qv.Dequeue();
        }
    }
}
