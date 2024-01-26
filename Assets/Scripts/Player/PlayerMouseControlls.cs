using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouseControlls : MonoBehaviour
{
	Ray ray;
	RaycastHit hit;
	ItemController item;
	ItemController curitem;

	private SmartSwitch raySwitch;

	void Update()
	{
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		raySwitch.Update(Physics.Raycast(ray, out hit) && hit.collider.gameObject.TryGetComponent<ItemController>(out item) == true);

		if(raySwitch.OnPress())
        {
				item.OnViewd();
			curitem = item;
		}
		if (raySwitch.OnRelese())
		{
			if(curitem != null)
            {
				curitem.OnReleced();
				curitem = null;
            }
		}

		if (raySwitch.OnHold())
		{
			if (Input.GetMouseButtonDown(0) && curitem != null)
				item.OnSelected();
		}
	}
}
