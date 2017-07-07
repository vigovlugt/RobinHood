using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public static class MovementTypes {

    public static float CalcMovementMultiplier(int movementType)
        {
            switch (movementType)
            {
                case 0:
                    return 1;
                case 1:
                    return 1.25f;
                case 2:
                    return 0.75f;
            }
            return 1;

        }
}
