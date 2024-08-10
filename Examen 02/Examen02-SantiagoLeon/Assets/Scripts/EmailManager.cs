using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro; // Asegúrate de incluir la referencia a TextMeshPro

public class EmailManager : MonoBehaviour
{
    public GameObject rightText; // El texto "Right"
    public GameObject wrongText; // El texto "Wrong"
    private bool checkmarkPressed; // Para verificar si el botón de check fue presionado
    private bool crossPressed; // Para verificar si el botón de cross fue presionado
    private GameObject selectedEmail; // Para almacenar el correo seleccionado

    // Método para seleccionar un correo
    public void SelectEmail(GameObject email)
    {
        selectedEmail = email; // Almacena el correo seleccionado
        Debug.Log("Email escogido: " + email.name);
    }

    // Método para seleccionar un correo y mostrar las opciones
    public void CheckIfPhishing(GameObject email)
    {
        string tag = email.tag; // Obtiene el tag del correo seleccionado

        if (checkmarkPressed && tag == "PhishingMail")
        {
            rightText.SetActive(true);
            wrongText.SetActive(false);
            checkmarkPressed = false;
            crossPressed = false;
        }
        else if (crossPressed && tag == "RealMail")
        {
            rightText.SetActive(true);
            wrongText.SetActive(false);
            checkmarkPressed = false;
            crossPressed = false;
        }
        else
        {
            rightText.SetActive(false);
            wrongText.SetActive(true);
            checkmarkPressed = false;
            crossPressed = false;
        }

        ShowDescription(email.name);
    }

    // Este método debe ser llamado cuando el botón de checkmark es presionado
    public void OnCheckmarkPressed()
    {
        checkmarkPressed = true;
        crossPressed = false;
        Debug.Log("Checkmark pressed");

        // Llama a CheckIfPhishing solo si hay un correo seleccionado
        if (selectedEmail != null)
        {
            CheckIfPhishing(selectedEmail);
        }
    }

    // Este método debe ser llamado cuando el botón de cross es presionado
    public void OnCrossPressed()
    {
        crossPressed = true;
        checkmarkPressed = false;
        Debug.Log("Cross pressed");

        // Llama a CheckIfPhishing solo si hay un correo seleccionado
        if (selectedEmail != null)
        {
            CheckIfPhishing(selectedEmail);
        }
    }

    private void ShowDescription(string emailName)
    {
        // Busca el objeto MailSelectedX
        GameObject mailSelected = GameObject.Find(emailName);
        if (mailSelected == null)
        {
            Debug.LogError("MailSelected object not found: " + emailName);
            return;
        }

        // Busca el objeto MailX dentro de MailSelectedX
        Transform mail = mailSelected.transform.Find("Mail" + emailName.Replace("MailSelected", ""));
        if (mail == null)
        {
            Debug.LogError("Mail object not found: Mail" + emailName.Replace("MailSelected", "") + " under: " + emailName);
            return;
        }

        // Busca el objeto DescriptionX dentro de MailX usando TextMeshProUGUI
        TextMeshProUGUI description = mail.Find("Description" + emailName.Replace("MailSelected", ""))?.GetComponent<TextMeshProUGUI>();
        if (description == null)
        {
            Debug.LogError("Description object not found: Description" + emailName.Replace("MailSelected", "") + " under: " + mail.name);
            return;
        }

        // Activa la descripción correspondiente
        description.gameObject.SetActive(true);
    }
}
