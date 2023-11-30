using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibraryManager : MonoBehaviour
{
    public GameObject endCollider;
    [SerializeField] List<BoxCollider2D> libraryInteractiveCollider;
    public static LibraryManager instance;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {


    }
    public void DisableColliders(int index)
    {
        libraryInteractiveCollider[index].name = "DisableCollider";
    }


}
