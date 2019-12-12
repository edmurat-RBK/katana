using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShurikenBarUI : MonoBehaviour
{
    //private Image imageComponant;
    private Player player;
    public GameObject firstShuriken;
    public GameObject secondShuriken;
    public GameObject thirdShuriken;
    public Sprite[] shurikenSprite;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
         *  Bon... Je vous dois quelques explications pour la suite
         *  A l'heure où j'écris ces lignes, nous sommes le 12 décembre, les vacances
         *  sont dans 7 jours, c'est également notre deadline pour finir le dev de KATANA
         *  sinon on va être trop short.
         *  Et puis, il y a eu cette histoire d'animation dans l'UI qui n'est pas simple à
         *  faire dans Unity, mais nos GA avaient produit quand même la barre de chargement
         *  des shurikens en animation pour l'UI
         *  Je voulais l'interger, c'etait galère, du coup je me retrouve à coder une animation
         *  
         *  Alors oui... Oui c'est profondément degeulasse, je pèse mes mots... J'ai assez honte
         *  de la manière de faire. Mais, je vous rappele que je suis en train de rush la fin du
         *  projet. Néanmoins, je vous dois des excuses, à tous. C'est laid, je vous inflige ce
         *  code immonde. C'est vraiment pas un bon exemple pour la jeunesse mais que voulez vous...
         *  J'ai besoin de quelque chose qui marche avant tout.
         *  
         *  Alors, vraiment, pardon... J'aurais certainement du réflechir plus et sortir une
         *  solution plus élégante. Pardon, pardon, pardon.
         *  Nous sommes tous victime de cela, croyez moi, je dois souffir autant que vous en 
         *  relisant ce code très mauvais.
         *  
         *  Merci pour votre compassion. Et encore désolé pour la suite.
         */

        if(0 <= player.heldTimer && player.heldTimer < 0.6)
        {
            firstShuriken.GetComponent<Image>().sprite = shurikenSprite[0];
            secondShuriken.GetComponent<Image>().sprite = shurikenSprite[0];
            thirdShuriken.GetComponent<Image>().sprite = shurikenSprite[0];
        }
        else if (0.6 <= player.heldTimer && player.heldTimer < 0.6+0.032)
        {
            firstShuriken.GetComponent<Image>().sprite = shurikenSprite[1];
            secondShuriken.GetComponent<Image>().sprite = shurikenSprite[0];
            thirdShuriken.GetComponent<Image>().sprite = shurikenSprite[0];
        }
        else if (0.6+0.032 <= player.heldTimer && player.heldTimer < 0.6 + 0.032*2)
        {
            firstShuriken.GetComponent<Image>().sprite = shurikenSprite[2];
            secondShuriken.GetComponent<Image>().sprite = shurikenSprite[0];
            thirdShuriken.GetComponent<Image>().sprite = shurikenSprite[0];
        }
        else if (0.6 + 0.032*2 <= player.heldTimer && player.heldTimer < 0.6 + 0.032 * 3)
        {
            firstShuriken.GetComponent<Image>().sprite = shurikenSprite[3];
            secondShuriken.GetComponent<Image>().sprite = shurikenSprite[0];
            thirdShuriken.GetComponent<Image>().sprite = shurikenSprite[0];
        }
        else if (0.6 + 0.032*3 <= player.heldTimer && player.heldTimer < 0.6 + 0.032 * 4)
        {
            firstShuriken.GetComponent<Image>().sprite = shurikenSprite[4];
            secondShuriken.GetComponent<Image>().sprite = shurikenSprite[0];
            thirdShuriken.GetComponent<Image>().sprite = shurikenSprite[0];
        }
        else if (0.6 + 0.032 *4 <= player.heldTimer && player.heldTimer < 0.6 + 0.032 *5 )
        {
            firstShuriken.GetComponent<Image>().sprite = shurikenSprite[5];
            secondShuriken.GetComponent<Image>().sprite = shurikenSprite[0];
            thirdShuriken.GetComponent<Image>().sprite = shurikenSprite[0];
        }



        else if (0.6 + 0.032*5 <= player.heldTimer && player.heldTimer < 1.2)
        {
            firstShuriken.GetComponent<Image>().sprite = shurikenSprite[5];
            secondShuriken.GetComponent<Image>().sprite = shurikenSprite[0];
            thirdShuriken.GetComponent<Image>().sprite = shurikenSprite[0];
        }
        else if (1.2 <= player.heldTimer && player.heldTimer < 1.2 + 0.032)
        {
            firstShuriken.GetComponent<Image>().sprite = shurikenSprite[5];
            secondShuriken.GetComponent<Image>().sprite = shurikenSprite[1];
            thirdShuriken.GetComponent<Image>().sprite = shurikenSprite[0];
        }
        else if (1.2 + 0.032 <= player.heldTimer && player.heldTimer < 1.2 + 0.032 * 2)
        {
            firstShuriken.GetComponent<Image>().sprite = shurikenSprite[5];
            secondShuriken.GetComponent<Image>().sprite = shurikenSprite[2];
            thirdShuriken.GetComponent<Image>().sprite = shurikenSprite[0];
        }
        else if (1.2 + 0.032 * 2 <= player.heldTimer && player.heldTimer < 1.2 + 0.032 * 3)
        {
            firstShuriken.GetComponent<Image>().sprite = shurikenSprite[5];
            secondShuriken.GetComponent<Image>().sprite = shurikenSprite[3];
            thirdShuriken.GetComponent<Image>().sprite = shurikenSprite[0];
        }
        else if (1.2 + 0.032 * 3 <= player.heldTimer && player.heldTimer < 1.2 + 0.032 * 4)
        {
            firstShuriken.GetComponent<Image>().sprite = shurikenSprite[5];
            secondShuriken.GetComponent<Image>().sprite = shurikenSprite[4];
            thirdShuriken.GetComponent<Image>().sprite = shurikenSprite[0];
        }
        else if (1.2 + 0.032 * 4 <= player.heldTimer && player.heldTimer < 1.2 + 0.032 * 5)
        {
            firstShuriken.GetComponent<Image>().sprite = shurikenSprite[5];
            secondShuriken.GetComponent<Image>().sprite = shurikenSprite[5];
            thirdShuriken.GetComponent<Image>().sprite = shurikenSprite[0];
        }



        else if (1.2 + 0.032 * 5 <= player.heldTimer && player.heldTimer < 1.8)
        {
            firstShuriken.GetComponent<Image>().sprite = shurikenSprite[5];
            secondShuriken.GetComponent<Image>().sprite = shurikenSprite[5];
            thirdShuriken.GetComponent<Image>().sprite = shurikenSprite[0];
        }
        else if (1.8 <= player.heldTimer && player.heldTimer < 1.8 + 0.032)
        {
            firstShuriken.GetComponent<Image>().sprite = shurikenSprite[5];
            secondShuriken.GetComponent<Image>().sprite = shurikenSprite[5];
            thirdShuriken.GetComponent<Image>().sprite = shurikenSprite[1];
        }
        else if (1.8 + 0.032 <= player.heldTimer && player.heldTimer < 1.8 + 0.032 * 2)
        {
            firstShuriken.GetComponent<Image>().sprite = shurikenSprite[5];
            secondShuriken.GetComponent<Image>().sprite = shurikenSprite[5];
            thirdShuriken.GetComponent<Image>().sprite = shurikenSprite[2];
        }
        else if (1.8 + 0.032 * 2 <= player.heldTimer && player.heldTimer < 1.8 + 0.032 * 3)
        {
            firstShuriken.GetComponent<Image>().sprite = shurikenSprite[5];
            secondShuriken.GetComponent<Image>().sprite = shurikenSprite[5];
            thirdShuriken.GetComponent<Image>().sprite = shurikenSprite[3];
        }
        else if (1.8 + 0.032 * 3 <= player.heldTimer && player.heldTimer < 1.8 + 0.032 * 4)
        {
            firstShuriken.GetComponent<Image>().sprite = shurikenSprite[5];
            secondShuriken.GetComponent<Image>().sprite = shurikenSprite[5];
            thirdShuriken.GetComponent<Image>().sprite = shurikenSprite[4];
        }
        else if (1.8 + 0.032 * 4 <= player.heldTimer)
        {
            firstShuriken.GetComponent<Image>().sprite = shurikenSprite[5];
            secondShuriken.GetComponent<Image>().sprite = shurikenSprite[5];
            thirdShuriken.GetComponent<Image>().sprite = shurikenSprite[5];
        }
    }
}
