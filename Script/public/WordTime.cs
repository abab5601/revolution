using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordTime : MonoBehaviour
{
    float Time_;

    public World world;
    public void Awake()
    {
        Time_ = world.Time;
    }
    // Update is called once per frame
    void Update()
    {
        this.Time_ += (Time.deltaTime * world.Time_x);
        gameObject.transform.rotation = Quaternion.Euler((Time_ - 360) / 1440 * 360, 0, 0);
        while (Time_ >= 1440) Time_ -= 1440;
        world.Time = (int)Time_;
    }
}
