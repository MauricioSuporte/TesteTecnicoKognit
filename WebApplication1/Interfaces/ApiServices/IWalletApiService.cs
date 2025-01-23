using UserWalletAPI.DTOs;

namespace UserWalletAPI.Interfaces.ApiServices
{
    public interface IWalletApiService
    {
        WalletResponse CreateWallet(WalletRequest walletRequest);
        IEnumerable<WalletResponse> GetWalletsByUser(int userId);
    }
}
