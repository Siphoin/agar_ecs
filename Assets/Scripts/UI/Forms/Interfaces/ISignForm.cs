using UnityEngine.Events;

namespace AgarMirror.UI.Forms.Interfaces
{
    public interface ISignForm
    {
        event UnityAction<string> OnSubmit;
    }
}
