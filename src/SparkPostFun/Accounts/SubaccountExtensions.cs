using LanguageExt;

namespace SparkPostFun.Accounts
{
    public static class SubaccountExtensions
    {
        public static Either<SubaccountError, SubaccountCreateResponse> Create(SubaccountCreate subaccount)
        {
            throw new NotImplementedException();
        }

        public static SubaccountRetrieveResponse RetrieveSubaccount(uint subaccountId)
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<SubaccountRetrieveResponse> RetrieveSubaccounts(uint subaccountId)
        {
            throw new NotImplementedException();
        }

        public static Either<SubaccountError, string> Update(SubaccountUpdate subaccount)
        {
            throw new NotImplementedException();
        }

        public static SubaccountListResponse List(SubaccountOptions? options)
        {
            throw new NotImplementedException();
        }

        public static int Summary()
        {
            throw new NotImplementedException();
        }

    }
}