using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ToiletScript : MonoBehaviour, IMinigame
{
    public CanScript canPrefab;
    public GameObject canArea;
    public GameObject background;
    public Texture2D clawGrab;
    public Texture2D clawSpray;
    public Texture2D clawPressEmpty;
    public Texture2D clawPressFull;

    public ThrowCanAnimation throwCan;

    public bool canMode = false;
    public int noCans=5;
    private List<CanScript> cans = new List<CanScript>();

    private bool isFull;

    public MinigameType minigame { get; set; }
    public Action<IMinigame, bool> OnMinigameFinished { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        SpawnCan(noCans);
        UnityEngine.Cursor.SetCursor(clawGrab, Vector2.zero, CursorMode.ForceSoftware);
    }

    // Update is called once per frame
    void Update()
    {
        if (canMode)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (isFull)
                {
                    UnityEngine.Cursor.SetCursor(clawPressFull, Vector2.zero, CursorMode.ForceSoftware);
                }
                else
                {
                    UnityEngine.Cursor.SetCursor(clawPressEmpty, Vector2.zero, CursorMode.ForceSoftware);
                }
            }
            else if (Input.GetMouseButtonUp(0))
                UnityEngine.Cursor.SetCursor(clawSpray, Vector2.zero, CursorMode.ForceSoftware);
        }
    }

    void SpawnCan(int noCans)
    {
        RectTransform rt = canArea.GetComponent<RectTransform>();
        UnityEngine.Random rnd = new UnityEngine.Random();
        Vector3[] v = new Vector3[4];
        rt.GetWorldCorners(v);

        int random1 = UnityEngine.Random.Range(0, noCans);
        int random2 = UnityEngine.Random.Range(0, noCans);

        for (int i = 0; i < noCans; i++)
        {
            Vector3 spawnPoint = new Vector3(UnityEngine.Random.Range(v[0].x, v[3].x), UnityEngine.Random.Range(v[0].y, v[2].y), 0);
            CanScript spawnObject = Instantiate(canPrefab, spawnPoint, Quaternion.identity, rt);
            spawnObject.GetComponent<CanScript>().game = this;

            if (i == random1 || i == random2)
                spawnObject.isFull = true;
            cans.Add(spawnObject);
        }
    }

    public void TakeCan(CanScript can)
    {
        if (!canMode)
        {
            isFull = can.isFull;
            cans.Remove(can);
            Destroy(can.gameObject);
            UnityEngine.Cursor.SetCursor(clawSpray, Vector2.zero, CursorMode.ForceSoftware);

            canMode = true;
        }
    }

    public void ThrowCan()
    {
        canMode = false;

        UnityEngine.Cursor.SetCursor(clawGrab, Vector2.zero, CursorMode.ForceSoftware);
        throwCan.PlayAnimation();


    }

    public void SprayToilet()
    {
        if (isFull)
        {
            //MINIGAME
            //IS
            //FINISHED
            OnMinigameFinished(this, true);
        }
    }

    public void DestroyMinigame()
    {
        throw new NotImplementedException();
    }
}
