using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    public int blueberries = 0;
    public int acorns = 0;
    public int mushrooms = 0;

    public Text blueberryText;
    public Text acornText;
    public Text mushroomText;

    private void UpdateText()
    {
        blueberryText.text = "Blueberries:  " + blueberries.ToString() + "/3";
        acornText.text = "Acorns:  " + acorns.ToString() + "/8";
        mushroomText.text = "Mushrooms:  " + mushrooms.ToString() + "/5";
    }

    public void CollectItem(string tag)
    {
        switch (tag)
        {
            case "Blueberry":
                blueberries++;
                break;
            case "Acorn":
                acorns++;
                break;
            case "Mushroom":
                mushrooms++;
                break;
        }
        UpdateText();
    }
}
