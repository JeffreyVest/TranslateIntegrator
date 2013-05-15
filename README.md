TranslateIntegrator
===================

Create a Secrets sub folder.

Add an AccountInfo class in the Secrets folder.

    namespace TranslateIntegrator.Secrets
    {
        class AccountInfo
        {
            public string AccountKey
            {
                get { return "{youracctkey}"; }
            }
            public static AccountInfo Instance = new AccountInfo();
        }
    }
