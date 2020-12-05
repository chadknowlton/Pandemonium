using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetting
{
    private static float yAxisSensitivity = 1f;
    private static float xAxisSensitivity = 1f;

    private static bool xInvert = false;
    private static bool yInvert = false;

    public static float YAXISSENTITITY
    {
        get { return yAxisSensitivity; }
        set { yAxisSensitivity = value; }
    }

    public static float XAXISSENTITITY
    {
        get { return xAxisSensitivity; }
        set { xAxisSensitivity = value; }
    }

    public static float IsXInsert_f()
    {
        if(xInvert)
        {
            return -1;
        }
        else
        {
            return 1;
        }
    }

    public static float IsYInsert_f()
    {
        if (yInvert)
        {
            return 1;
        }
        else
        {
            return -1;
        }
    }

}
