using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolable {

    void ResetObject ();

    void Destroy ();
}
