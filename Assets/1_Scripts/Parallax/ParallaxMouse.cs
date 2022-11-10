using System.Collections.Generic;
using Parallax;
using UnityEngine;

public class ParallaxMouse : ParallaxController
{
    private void FixedUpdate()
    {
        foreach (var layout in Layouts)
        {
            SmoothMoveLayout(layout);
        }
    }

}

