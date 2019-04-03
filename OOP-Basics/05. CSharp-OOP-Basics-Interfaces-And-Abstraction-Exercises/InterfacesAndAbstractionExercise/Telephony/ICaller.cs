using System.Collections;

namespace Telephony
{
    public interface ICaller
    {
        void Call(ICollection phoneNumbers);
    }
}
