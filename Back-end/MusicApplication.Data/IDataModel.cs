using System.Data;

namespace MusicApplication.Data
{
    public interface IDataModel
    {
        void CastFromReader(IDataReader reader);
    }
}
