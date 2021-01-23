using UnityEngine;

public class testInteractable : Interactable
{
    
    public GameController GC;
    public override string GetDescription()
    {
      if(GC.AvailableActions <= 0)
      {
          return "";
      }
      else 
      
      return "<color=green>Actions remaining: </color>" + GC.AvailableActions;
    }
    public override void Interact()
    {
        //isOn = !isOn;
        GC.AvailableActions -=1;
        return;
    }
}
