using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* TODO:  Мне пришла идея эта с тем, чтобы сделать наложение интерактивным. Но после я уже заметил 
что можно просто было сделать 2 тайлмепа с разными частями статую той же и положить их на разные уровни 
и получить тот же эффект. 
Но тут же поднялся вопрос эффективности такого решения, потому что этот не самый замысловатый код хоть и странный
но имеет право на существование где-нибудь ещё я думаю

Идея зародилась из-за деревьев
типа можно ведь быть за кроной и быть перед кроной и как понять когда надо накладывать сверху а когда снизу 
поэтому этот код здесь

Но он не так актуален для 

*/
public class OrderInLayer : MonoBehaviour
{

  public SpriteRenderer playerSpriteRenderer;
  public Renderer tileRenderer;

  public Transform playerTransform;
  public Transform tileTransform;

  void Update()
  {
    if (tileTransform.position.y < playerTransform.position.y)
    {
      tileRenderer.sortingOrder = playerSpriteRenderer.sortingOrder + 1;
    }
    else
    {
      tileRenderer.sortingOrder = playerSpriteRenderer.sortingOrder - 1;
    }
  }
}
