using UnityEngine;
using System.Collections;

public class PlayerMarker : MonoBehaviour
{
	public GameObject JerseyCur;
	public GameObject PickedObj;

	void OnMouseDown()
	{
		Debug.Log("Clicked");
		JerseyCur.GetComponent<Jersey> ().JerseyUpdate ("Колян", "00");
	}

	void OnMouseDrag()
	{
		//подсветка слотов
		//перемещение объекта за мышкой
		gameObject.layer = 2;
		gameObject.transform.position = new Vector3(Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y, 0);
	}

	public GameObject GetDropZone( GameObject p)
	{
		p.layer
	}

	void OnMouseUp()
	{
		Ray DropRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit Hit;

		if (Physics.Raycast (DropRay, out Hit))
		{
			if(Hit.collider.tag=="FieldZone")
			{
				//place or placeback
			}
			else if(Hit.collider.tag=="FPlayer")
			{
				//swap
			}
			else if (Hit.collider.tag=="TeamRooster")
			{
				//apply or switch
			}
		}
		else
		{
			//revert
		}

		//отключение слотов
		// * тот же парент - ретурн
		// * другой маркер - свитч залинканых игроков
		// * другой парент - проверка свободынх слотов, смена позиции и парента, перестановка маркеров в стартовой зоне
		// * игрок в тимрустере - апплай или свичт залинканых игроков
		// * все прочие области - возврат вбазовый слот
		// апдейт инфы на футболке

	}

	public void Apply( FPlayer p)
	{
		//link player to marker
	}

	public void Swap( GameObject p)
	{
		//swap player links between two markers
	}

	public void RevertMovement( GameObject p


}
