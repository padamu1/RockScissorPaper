using SimulFactory.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulFactory.System.Common
{
    public class PopupBase : BaseObject
    {

        public virtual void SpawnPopup(PopupManager.PopupInfo popupInfo)
        {

            gameObject.SetActive(true);
        }
    }
}
