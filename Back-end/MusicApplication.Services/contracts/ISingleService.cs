using MusicApplication.Data;

namespace MusicApplication.Services.contracts
{
    public interface ISingleService
    {
        Single GetById(int id);

        Single CreateSingle(Single album);

        Single UpdateSingle(int id, Single album);

        bool DeleteSingle(int id);
    }
}
