using UnityEngine;

public class WinPlatform : MonoBehaviour
{
   [SerializeField] private GameObject winPanel;

   private void OnTriggerEnter(Collider other)
   {
      // Si el player colisiona con la win platform
      if (other.gameObject.CompareTag("Enemy"))
      {
         // Deshabilitamos el PlayerController
         other.gameObject.GetComponentInParent<PlayerController>().enabled = false;
         
         // Mostramos el panel de win
         winPanel.SetActive(true);
      }
   }
}
