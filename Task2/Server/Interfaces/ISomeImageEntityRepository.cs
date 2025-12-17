namespace Server.Interfaces
{
    public interface ISomeImageEntityRepository
    {
        Uri? GetImageUrl(Guid id);
        void SetImageUrl(Guid id, Uri imageUrl);
    }
}
