using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenShopUI : MonoBehaviour
{
    [SerializeField]
    private GameObject shopUI;
    // public BoxCollider2D Collider;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")){
            // Debug.Log("oioi");
            shopUI.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            shopUI.gameObject.SetActive(false);
        }
    }


    public void closeShop() {
        // Debug.Log("Close Shop Dipanggil");
        shopUI.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }


    // Start is called before the first frame update
    void Start()
    {
        // shopUI.enabled = false;
        shopUI.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
